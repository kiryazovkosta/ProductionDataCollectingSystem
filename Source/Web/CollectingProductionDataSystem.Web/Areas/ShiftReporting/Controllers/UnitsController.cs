﻿namespace CollectingProductionDataSystem.Web.Areas.ShiftReporting.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Transactions;
    using System.Web.Mvc;
    using AutoMapper;
    using CollectingProductionDataSystem.Application.Contracts;
    using CollectingProductionDataSystem.Application.ProductionDataServices;
    using CollectingProductionDataSystem.Data.Contracts;
    using CollectingProductionDataSystem.Infrastructure.Extentions;
    using CollectingProductionDataSystem.Models.Productions;
    using CollectingProductionDataSystem.Web.Areas.ShiftReporting.ViewModels;
    using CollectingProductionDataSystem.Web.Infrastructure.Extentions;
    using CollectingProductionDataSystem.Web.Infrastructure.Filters;
    using CollectingProductionDataSystem.Web.InputModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Resources = App_GlobalResources.Resources;
using CollectingProductionDataSystem.Infrastructure.Contracts;

    [Authorize]
    public class UnitsController : AreaBaseController
    {
        private readonly IUnitsDataService shiftServices;
        private readonly IUnitDailyDataService dailyServices;
        private readonly IProductionDataCalculatorService productionDataCalculator;
        private readonly ILogger logger;

        public UnitsController(IProductionData dataParam, IUnitsDataService shiftServicesParam, IUnitDailyDataService dailyServicesParam, IProductionDataCalculatorService productionDataCalcParam, ILogger loggerParam)
            : base(dataParam)
        {
            this.shiftServices = shiftServicesParam;
            this.dailyServices = dailyServicesParam;
            this.productionDataCalculator = productionDataCalcParam;
            this.logger = loggerParam;
        }

        [HttpGet]
        public ActionResult UnitsData()
        {
            // ToDo: It's very importaint to set manual data indicator which sets different process of entering data (water-meter, flow-meter, electro-meter, etc.)
            ViewBag.ManualIndicator = "MD";
            ViewBag.ManualCalcumated = "MC";
            ViewBag.ManualSelfCalculated = "MS";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFactory]
        public JsonResult ReadUnitsData([DataSourceRequest]
                                        DataSourceRequest request, DateTime? date, int? processUnitId, int? shiftId)
        {
            ValidateModelState(date, processUnitId, shiftId);
            if (ModelState.IsValid)
            {
                var dbResult = this.shiftServices.GetUnitsDataForDateTime(date, processUnitId, shiftId);
                var kendoPreparedResult = Mapper.Map<IEnumerable<UnitsData>, IEnumerable<UnitDataViewModel>>(dbResult);
                var kendoResult = new DataSourceResult();
                try
                {
                    kendoResult = kendoPreparedResult.ToDataSourceResult(request, ModelState);
                }
                catch (Exception ex1)
                {
                    Debug.WriteLine(ex1.Message + "\n" + ex1.InnerException);
                }

                return Json(kendoResult);
            }
            else
            {
                var kendoResult = new List<UnitDataViewModel>().ToDataSourceResult(request, ModelState);
                return Json(kendoResult);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([DataSourceRequest]
                                 DataSourceRequest request, UnitDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                IEfStatus result = UpdateRelatedUnitConfigData(model);
                if (result.IsValid)
                {
                    var newManualRecord = new UnitsManualData
                    {
                        Id = model.Id,
                        Value = model.UnitsManualData.Value,
                        EditReasonId = model.UnitsManualData.EditReason.Id
                    };
                    var existManualRecord = this.data.UnitsManualData.All().FirstOrDefault(x => x.Id == newManualRecord.Id);
                    if (existManualRecord == null)
                    {
                        this.data.UnitsManualData.Add(newManualRecord);
                    }
                    else
                    {
                        UpdateRecord(existManualRecord, model);
                    }
                    try
                    {
                        result = this.data.SaveChanges(UserProfile.UserName);
                        if (!result.IsValid)
                        {
                            result.ToModelStateErrors(this.ModelState);
                        }
                    }
                    catch (DbUpdateException)
                    {
                        this.ModelState.AddModelError("ManualValue", "Записът не можа да бъде осъществен. Моля опитайте на ново!");
                    }
                }
                else
                {
                    result.ToModelStateErrors(this.ModelState);
                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private IEfStatus UpdateRelatedUnitConfigData(UnitDataViewModel model)
        {
            IEfStatus result;
            var relatedUnitConfigs = this.data.RelatedUnitConfigs.All().Where(x => x.RelatedUnitConfigId == model.UnitConfigId).ToList();
            if (relatedUnitConfigs.Count() > 0)
            {
                foreach (var relatedUnitConfig in relatedUnitConfigs)
                {
                    result = UpdateRelatedUnitConfig(relatedUnitConfig.UnitConfigId, model);
                    if (!result.IsValid)
                    {
                        return result;
                    }
                }

                //.data.SaveChanges(this.UserProfile.UserName);
            }

            return DependencyResolver.Current.GetService<IEfStatus>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(ProcessUnitConfirmShiftInputModel model)
        {
            ValidateModelState(model.date, model.processUnitId, model.shiftId);

            if (this.ModelState.IsValid)
            {
                if (!this.shiftServices.IsShitApproved(model.date, model.processUnitId, model.shiftId))
                {
                    this.data.UnitsApprovedDatas.Add(new UnitsApprovedData
                    {
                        RecordDate = model.date,
                        ProcessUnitId = model.processUnitId,
                        ShiftId = model.shiftId,
                        Approved = true
                    });

                    IEfStatus status;

                    IEnumerable<UnitsDailyData> dailyResult = new List<UnitsDailyData>();

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        status = data.SaveChanges(this.UserProfile.UserName);

                        if (status.IsValid)
                        {
                            if (dailyServices.CheckIfAllShiftsAreReady(model.date, model.processUnitId))
                            {
                                if (!dailyServices.CheckIfDayIsApproved(model.date, model.processUnitId))
                                {
                                    status = dailyServices.ClearUnitDailyDatas(model.date, model.processUnitId, this.UserProfile.UserName);
                                    if (status.IsValid)
                                    {
                                        dailyResult = dailyServices.CalculateDailyDataForProcessUnit(model.processUnitId, model.date);
                                    }
                                }
                            }
                        }

                        if (dailyResult.Count() > 0)
                        {
                            this.data.UnitsDailyDatas.BulkInsert(dailyResult, this.UserProfile.UserName);
                            status = this.data.SaveChanges(this.UserProfile.UserName);
                        }

                        transaction.Complete();
                    }

                    return Json(new { IsConfirmed = status.IsValid });
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    ModelState.AddModelError("shiftdata", "Данните за смяната вече са потвърдени!!!");
                    var errors = GetErrorListFromModelState(ModelState);
                    return Json(new { data = new { errors = errors } });
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = GetErrorListFromModelState(ModelState);
                return Json(new { data = new { errors = errors } });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IsConfirmed([DataSourceRequest]
                                        DataSourceRequest request, DateTime? date, int? processUnitId, int? shiftId)
        {
            ValidateModelState(date, processUnitId, shiftId);

            if (this.ModelState.IsValid)
            {
                var isConfirmed = shiftServices.IsShitApproved(date.Value, processUnitId.Value, shiftId.Value);
                if (!isConfirmed)
                {
                    isConfirmed = !this.data.UnitsData.All().Where(x => x.RecordTimestamp == date && x.UnitConfig.ProcessUnitId == processUnitId && (int)x.ShiftId == shiftId).Any();
                }
                return Json(new { IsConfirmed = isConfirmed });
            }

            return Json(new { IsConfirmed = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowManualDataModal(UnitDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                var startupValue = GetUnitConfigStartupValue(model);
                var manualCalculationModel = new ManualCalculationViewModel()
                {
                    IsOldValueAvailableForEditing = startupValue == decimal.MinValue,
                    OldValue = startupValue == decimal.MinValue ? 0 : startupValue,
                    MeasurementCode = model.UnitConfig.MeasureUnit.Code,
                    UnitDataId = model.Id,
                    EditorScreenHeading = string.Format(Resources.Layout.EditValueFor, model.UnitConfig.Name)
                };
                return PartialView("_ManualDataCalculation", manualCalculationModel);
            }
            else
            {
                var errors = this.ModelState.Values.SelectMany(x => x.Errors);
                return Json(new { success = false, status = 400, errors = errors });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalculateManualEntry(ManualCalculationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ManualDataCalculation", model);
            }

            var status = this.productionDataCalculator.CalculateByUnitData(model.UnitDataId, this.UserProfile.UserName, model.NewValue, model.OldValue);
            if (!status.IsValid)
            {
                status.ToModelStateErrors(this.ModelState);
            }

            return Json("success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowManualSelfCalculatedDataModal(UnitDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manualSelfCalculationModel = new ManualSelfCalculationViewModel()
                {
                    MeasurementCode = model.UnitConfig.MeasureUnit.Code,
                    UnitDataId = model.Id,
                    EditorScreenHeading = string.Format(Resources.Layout.EditValueFor, string.Format("{0} {1}", model.UnitConfig.Position, model.UnitConfig.Name))
                };
                return PartialView("_ManualDataSelfCalculation", manualSelfCalculationModel);
            }
            else
            {
                var errors = this.ModelState.Values.SelectMany(x => x.Errors);
                return Json(new { success = false, errors = errors });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelfCalculateManualEntry(ManualSelfCalculationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ManualDataSelfCalculation", model);
            }

            var status = this.productionDataCalculator.CalculateByUnitData(model.UnitDataId, this.UserProfile.UserName, model.Value);
            if (!status.IsValid)
            {
                status.ToModelStateErrors(this.ModelState);
            }

            return Json("success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowManualCalculatedDataModal(UnitDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manualWithRelatedCalculationModel = new ManualCalculationWithRelatedViewModel()
                {
                    MeasurementCode = model.UnitConfig.MeasureUnit.Code,
                    UnitDataId = model.Id,
                    EditorScreenHeading = string.Format(Resources.Layout.EditValueFor, string.Format("{0} {1}", model.UnitConfig.Position, model.UnitConfig.Name))
                };
                return PartialView("_ManualDataWithRelatedCalculation", manualWithRelatedCalculationModel);
            }
            else
            {
                var errors = this.ModelState.Values.SelectMany(x => x.Errors);
                return Json(new { success = false, errors = errors });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WithRelatedCalculateManualEntry(ManualCalculationWithRelatedViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ManualDataWithRelatedCalculation", model);
            }

            var status = this.productionDataCalculator.CalculateByUnitData(model.UnitDataId, this.UserProfile.UserName, model.Value);
            if (!status.IsValid)
            {
                status.ToModelStateErrors(this.ModelState);
            }

            return Json("success");
        }

        private IEfStatus UpdateRelatedUnitConfig(int unitConfigId, UnitDataViewModel model)
        {
            var unitConfig = this.data.UnitConfigs.GetById(unitConfigId);
            if (unitConfig.IsCalculated)
            {
                var formulaCode = unitConfig.CalculatedFormula ?? string.Empty;
                var arguments = PopulateFormulaTadaFromPassportData(unitConfig);
                PopulateFormulaDataFromRelatedUnitConfigs(unitConfig, arguments, model);
                var newValue = this.productionDataCalculator.Calculate(formulaCode, arguments);
                IEfStatus result = UpdateCalculatedUnitConfig(unitConfigId, newValue, model);
                return result;
            }
            return DependencyResolver.Current.GetService<IEfStatus>();
        }

        private IEfStatus UpdateCalculatedUnitConfig(int unitConfigId, double newValue, UnitDataViewModel model)
        {
            var record = data.UnitsData
                               .All().Include(x => x.UnitConfig)
                               .Where(x => x.RecordTimestamp == model.RecordTimestamp && x.ShiftId == model.Shift && x.UnitConfigId == unitConfigId)
                               .FirstOrDefault();

            IEfStatus result = ValidateObject(new UnitsManualData
                                {
                                    Id = record.Id,
                                    Value = (decimal)newValue,
                                    EditReasonId = model.UnitsManualData.EditReason.Id
                                }, record.UnitConfig);
            if (result.IsValid)
            {

                var existManualRecord = this.data.UnitsManualData.All().FirstOrDefault(x => x.Id == record.Id);
                if (existManualRecord == null)
                {
                    this.data.UnitsManualData.Add(new UnitsManualData
                    {
                        Id = record.Id,
                        Value = (decimal)newValue,
                        EditReasonId = model.UnitsManualData.EditReason.Id
                    });
                }
                else
                {
                    existManualRecord.Value = (decimal)newValue;
                    existManualRecord.EditReasonId = model.UnitsManualData.EditReason.Id;
                    this.data.UnitsManualData.Update(existManualRecord);
                }
            }

            return result;
        }

        private IEfStatus ValidateObject(UnitsManualData unitsManualData, UnitConfig unitConfig)
        {
            var result = DependencyResolver.Current.GetService<IEfStatus>();
            var errors = new List<ValidationResult>();
            foreach (var error in unitsManualData.Validate(null))
            {
                error.ErrorMessage = string.Format("{0}: {1}\n{2}: {3}\n {4}",
                Resources.Layout.Code,
                unitConfig.Code,
                Resources.Layout.UnitName,
                unitConfig.Name,
                error.ErrorMessage);
                errors.Add(error);
            }

            if (errors.Count > 0)
            {
                result.SetErrors(errors);
                foreach (var error in errors)
	            {
		            logger.Error(error.ErrorMessage, this, new Exception(), error.ErrorMessage.Split(new char[]{'\n'} ));
	            }
            }

            return result;
        }

        private FormulaArguments PopulateFormulaTadaFromPassportData(UnitConfig unitConfig)
        {
            var arguments = new FormulaArguments();
            arguments.MaximumFlow = (double?)unitConfig.MaximumFlow;
            arguments.EstimatedDensity = (double?)unitConfig.EstimatedDensity;
            arguments.EstimatedPressure = (double?)unitConfig.EstimatedPressure;
            arguments.EstimatedTemperature = (double?)unitConfig.EstimatedTemperature;
            arguments.EstimatedCompressibilityFactor = (double?)unitConfig.EstimatedCompressibilityFactor;
            return arguments;
        }

        private void PopulateFormulaDataFromRelatedUnitConfigs(UnitConfig unitConfig, FormulaArguments arguments, UnitDataViewModel model)
        {
            var ruc = unitConfig.RelatedUnitConfigs.ToList();
            foreach (var ru in ruc)
            {
                var parameterType = ru.RelatedUnitConfig.AggregateGroup;
                var inputValue = 0.0;
                if (ru.RelatedUnitConfigId == model.UnitConfigId)
                {
                    inputValue = (double)model.UnitsManualData.Value;
                }
                else
                {
                    inputValue = data.UnitsData.All()
                        .Where(x => x.RecordTimestamp == model.RecordTimestamp && x.ShiftId == model.Shift && x.UnitConfigId == ru.RelatedUnitConfigId)
                        .FirstOrDefault()
                        .RealValue;
                }

                if (parameterType == "I")
                {
                    arguments.InputValue = inputValue;
                }
                else if (parameterType == "T")
                {
                    arguments.Temperature = inputValue;
                }
                else if (parameterType == "P")
                {
                    arguments.Pressure = inputValue;
                }
                else if (parameterType == "D")
                {
                    arguments.Density = inputValue;
                }
            }
        }

        private double CalculateValueByProductionDataFormula(UnitDataViewModel model)
        {
            var formulaCode = model.UnitConfig.CalculatedFormula ?? string.Empty;
            var arguments = new FormulaArguments();
            arguments.MaximumFlow = (double?)model.UnitConfig.MaximumFlow;
            arguments.EstimatedDensity = (double?)model.UnitConfig.EstimatedDensity;
            arguments.EstimatedPressure = (double?)model.UnitConfig.EstimatedPressure;
            arguments.EstimatedTemperature = (double?)model.UnitConfig.EstimatedTemperature;
            arguments.EstimatedCompressibilityFactor = (double?)model.UnitConfig.EstimatedCompressibilityFactor;

            var uc = this.data.UnitConfigs.GetById(model.UnitConfigId);
            if (uc != null)
            {
                var ruc = uc.RelatedUnitConfigs.ToList();
                foreach (var ru in ruc)
                {
                    var parameterType = ru.RelatedUnitConfig.AggregateGroup;
                    var inputValue = data.UnitsData
                            .All()
                            .Where(x => x.RecordTimestamp == model.RecordTimestamp)
                            .Where(x => x.ShiftId == model.Shift)
                            .Where(x => x.UnitConfigId == ru.RelatedUnitConfigId)
                            .FirstOrDefault()
                            .RealValue;
                    if (parameterType == "I")
                    {
                        arguments.InputValue = inputValue;
                    }
                    else if (parameterType == "T")
                    {
                        arguments.Temperature = inputValue;
                    }
                    else if (parameterType == "P")
                    {
                        arguments.Pressure = inputValue;
                    }
                    else if (parameterType == "D")
                    {
                        arguments.Density = inputValue;
                    }
                }
            }

            return this.productionDataCalculator.Calculate(formulaCode, arguments);
        }

        private void UpdateRecord(UnitsManualData existManualRecord, UnitDataViewModel model)
        {
            existManualRecord.Value = model.UnitsManualData.Value;
            existManualRecord.EditReasonId = model.UnitsManualData.EditReason.Id;
            this.data.UnitsManualData.Update(existManualRecord);
        }

        private List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList;
        }

        private void ValidateModelState(DateTime? date, int? processUnitId, int? shiftId)
        {
            if (date == null)
            {
                this.ModelState.AddModelError("date", string.Format(Resources.ErrorMessages.Required, Resources.Layout.UnitsDateSelector));
            }
            if (processUnitId == null)
            {
                this.ModelState.AddModelError("processunits", string.Format(Resources.ErrorMessages.Required, Resources.Layout.UnitsProcessUnitSelector));
            }
            if (shiftId == null)
            {
                this.ModelState.AddModelError("shifts", string.Format(Resources.ErrorMessages.Required, Resources.Layout.UnitsProcessUnitShiftSelector));
            }
        }

        private decimal GetUnitConfigStartupValue(UnitDataViewModel model)
        {
            var startupValue = decimal.MinValue;

            var lastEnteredData = data.UnitEnteredForCalculationDatas.All().Where(x => x.UnitsData.UnitConfigId == model.UnitConfigId).OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastEnteredData == null)
            {
                var unitConfig = data.UnitConfigs.All().Where(x => x.Id == model.UnitConfigId).FirstOrDefault();
                if (unitConfig.StartupValue.HasValue)
                {
                    startupValue = unitConfig.StartupValue.Value;
                }
            }
            else
            {
                startupValue = lastEnteredData.NewValue;
            }
            return startupValue;
        }

    }
}