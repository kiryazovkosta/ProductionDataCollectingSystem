﻿namespace CollectingProductionDataSystem.Application.ProductionDataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CollectingProductionDataSystem.Application.Contracts;
    using CollectingProductionDataSystem.Application.CalculatorService;
    using CollectingProductionDataSystem.Data.Common;
    using CollectingProductionDataSystem.Data.Contracts;
    using CollectingProductionDataSystem.Models.Productions;
    using System.ComponentModel.DataAnnotations;

    public class ProductionDataCalculatorService : IProductionDataCalculatorService
    {
        private readonly ICalculatorService calculator;
        private readonly IProductionData data;

        public ProductionDataCalculatorService(IProductionData dataParam)
        {
            this.calculator = new CalculatorService();
            this.data = dataParam;
        }

        public double Calculate(string formulaCode, FormulaArguments arguments)
        {
            if (string.IsNullOrEmpty(formulaCode))
            {
                throw new ArgumentNullException("The value of the formulaCode can not be null or an empty string!");
            }

            if (arguments == null)
            {
                throw new ArgumentNullException("The value of formula arguments can not be null!"); 
            }

            double result = double.MinValue;
            switch (formulaCode)
            {
                case "P1":
                    result = FormulaP1(arguments);
                    break;
                case "PP1":
                    result = FormulaPP1(arguments);
                    break;
                case "Z1":
                    result = FormulaZ1(arguments);
                    break;
                case "ZZ1":
                    result = FormulaZZ1(arguments);
                    break;
                case "Z2":
                    result = FormulaZ2(arguments);
                    break;
                case "ZZ2":
                    result = FormulaZZ2(arguments);
                    break;
                case "N2":
                    result = FormulaN2(arguments);
                    break;
                case "G2":
                    result = FormulaG2(arguments);
                    break;
                case "V2":
                    result = FormulaV2(arguments);
                    break;
                case "N3":
                    result = FormulaN3(arguments);
                    break;
                case "G3":
                    result = FormulaG3(arguments);
                    break;
                case "V3":
                    result = FormulaV3(arguments);
                    break;
                case "PP3":
                    result = FormulaPP3(arguments);
                    break;
                case "N4":
                    result = FormulaN4(arguments);
                    break;
                case "N5":
                    result = FormulaN5(arguments);
                    break;
                case "G6":
                    result = FormulaG6(arguments);
                    break;
                case "G7":
                    result = FormulaG7(arguments);
                    break;
                case "R10":
                    result = FormulaR10(arguments);
                    break;
                case "O13":
                    result = FormulaO13(arguments);
                    break;
                case "V14":
                    result = FormulaV14(arguments);
                    break;
                case "I16":
                    result = FormulaI16(arguments);
                    break;
                case "I17":
                    result = FormulaI17(arguments);
                    break;
                case "R18":
                    result = FormulaR18(arguments);
                    break;
                case "ZZ52":
                    result = FormulaZZ52(arguments);
                    break;
                case "Z18":
                    result = FormulaZ18(arguments);
                    break;
                case "N18":
                    result = FormulaN18(arguments);
                    break;
                case "N19":
                    result = FormulaN19(arguments);
                    break;
                case "G19":
                    result = FormulaG19(arguments);
                    break;
                case "G26":
                    result = FormulaG26(arguments);
                    break;
                case "P26":
                    result = FormulaP26(arguments);
                    break;
                case "N42":
                    result = FormulaN42(arguments);
                    break;
                default:
                    throw new ArgumentException("The entered value of the formula code is invalid!");
                    break;
            }

            return result;
        }

        public IEfStatus CalculateByUnitData(decimal value, int unitDataId, string userName)
        {
            var unitConfig = this.data.UnitsData.GetById(unitDataId).UnitConfig;
            if (unitConfig != null)
            {
                var formulaCode = unitConfig.CalculatedFormula;
                var arguments = GetUnitConfigPassportData(unitConfig, value);
                var calculatedValue = this.Calculate(formulaCode, arguments);
                AddOrUpdateUnitEnteredForCalculationData(unitDataId, default(decimal), value);
                AddOrUpdateUnitsManualData(unitDataId, calculatedValue);
                var status = this.data.SaveChanges(userName);
                return status;
            }
            else
            {
                var validationResults = new List<ValidationResult>();
                validationResults.Add(new ValidationResult("There is not a unit config for that unit data!!!", new[] { "UnitConfig" }));
                return new EfStatus().SetErrors(validationResults);
            }
        }

        public IEfStatus CalculateDeltaByUnitData(decimal oldValue, decimal newValue, int unitDataId, string userName)
        {
            var unitConfig = this.data.UnitsData.GetById(unitDataId).UnitConfig;
            if (unitConfig != null)
            {
                var formula = unitConfig.CalculatedFormula;
                var arguments = GetUnitConfigDeltaPassportData(unitConfig, oldValue, newValue);
                var calculatedValue = this.Calculate(formula, arguments);
                AddOrUpdateUnitEnteredForCalculationData(unitDataId, oldValue, newValue);
                AddOrUpdateUnitsManualData(unitDataId, calculatedValue);
                var status = this.data.SaveChanges(userName);
                return status;
            }
            else
            {
                var validationResults = new List<ValidationResult>();
                validationResults.Add(new ValidationResult("There is not a unit config for that unit data!!!", new[] { "UnitConfig" }));
                return new EfStatus().SetErrors(validationResults);
            }
        }
 
        public IEfStatus CalculateByUnitAndRelatedData(decimal value, int unitDataId, string userName)
        {
            var unitData = this.data.UnitsData.GetById(unitDataId);
            var unitConfig = this.data.UnitsData.GetById(unitDataId).UnitConfig;
            if (unitConfig != null)
            {
                var formula = unitConfig.CalculatedFormula;
                var arguments = GetUnitConfigAndRelatedPassportData(unitConfig, unitData, value);
                var calculatedValue = this.Calculate(formula, arguments);
                AddOrUpdateUnitEnteredForCalculationData(unitDataId, default(decimal), value);
                AddOrUpdateUnitsManualData(unitDataId, calculatedValue);
                var status = this.data.SaveChanges(userName);
                return status;
            }
            else
            {
                var validationResults = new List<ValidationResult>();
                validationResults.Add(new ValidationResult("There is not a unit config for that unit data!!!", new[] { "UnitConfig" }));
                return new EfStatus().SetErrors(validationResults);
            }
        }
 
        private FormulaArguments GetUnitConfigPassportData(UnitConfig unitConfig, decimal value)
        {
            var arguments = new FormulaArguments();
            arguments.InputValue = (double)value;
            arguments.MaximumFlow = (double?)unitConfig.MaximumFlow;
            arguments.EstimatedDensity = (double?)unitConfig.EstimatedDensity;
            arguments.EstimatedPressure = (double?)unitConfig.EstimatedPressure;
            arguments.EstimatedTemperature = (double?)unitConfig.EstimatedTemperature;
            arguments.EstimatedCompressibilityFactor = (double?)unitConfig.EstimatedCompressibilityFactor;
            return arguments;
        }

        private FormulaArguments GetUnitConfigAndRelatedPassportData(UnitConfig unitConfig, UnitsData unitData, decimal value)
        {
            var arguments = new FormulaArguments();
            arguments.InputValue = (double)value;
            arguments.MaximumFlow = (double?)unitConfig.MaximumFlow;
            arguments.EstimatedDensity = (double?)unitConfig.EstimatedDensity;
            arguments.EstimatedPressure = (double?)unitConfig.EstimatedPressure;
            arguments.EstimatedTemperature = (double?)unitConfig.EstimatedTemperature;
            arguments.EstimatedCompressibilityFactor = (double?)unitConfig.EstimatedCompressibilityFactor;

            var relatedUnitConfigs = unitConfig.RelatedUnitConfigs.ToList();
            foreach (var relatedUnitConfig in relatedUnitConfigs)
            {
                var parameterType = relatedUnitConfig.RelatedUnitConfig.AggregateGroup;
                var inputValue = data.UnitsData
                        .All()
                        .Where(x => x.RecordTimestamp == unitData.RecordTimestamp)
                        .Where(x => x.ShiftId == unitData.ShiftId)
                        .Where(x => x.UnitConfigId == unitConfig.Id)
                        .FirstOrDefault()
                        .RealValue;
                if (parameterType == "T")
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
            return arguments;
        }

        private FormulaArguments GetUnitConfigDeltaPassportData(UnitConfig unitConfig, decimal oldValue, decimal newValue)
        {
            var formulaArguments = new FormulaArguments();
            formulaArguments.MaximumFlow = (double?)unitConfig.MaximumFlow;
            formulaArguments.EstimatedDensity = (double?)unitConfig.EstimatedDensity;
            formulaArguments.EstimatedPressure = (double?)unitConfig.EstimatedPressure;
            formulaArguments.EstimatedTemperature = (double?)unitConfig.EstimatedTemperature;
            formulaArguments.OldValue = (double?)oldValue;
            formulaArguments.InputValue = (double?)newValue;
            return formulaArguments;
        }

        private void AddOrUpdateUnitsManualData(int unitDataId, double calculatedValue)
        {
            var newManualRecord = new UnitsManualData
            {
                Id = unitDataId,
                Value = (decimal)calculatedValue,
                EditReasonId = this.data.EditReasons.All().Where(x => x.Name == "Калкулация").FirstOrDefault().Id
            };
            var existManualRecord = this.data.UnitsManualData.All().FirstOrDefault(x => x.Id == newManualRecord.Id);
            if (existManualRecord == null)
            {
                this.data.UnitsManualData.Add(newManualRecord);
            }
            else
            {
                existManualRecord.Value = (decimal)calculatedValue;
                this.data.UnitsManualData.Update(existManualRecord);
            }
        }
 
        private void AddOrUpdateUnitEnteredForCalculationData(int unitDataId, decimal oldValue, decimal newValue)
        {
            var newUnitEnteredForCalculationRecord = new UnitEnteredForCalculationData
            {
                Id = unitDataId,
                OldValue = oldValue,
                NewValue = newValue
            };
            var existsUnitEnteredForCalculationRecord = this.data.UnitEnteredForCalculationDatas.All().Where(x => x.Id == newUnitEnteredForCalculationRecord.Id).FirstOrDefault();
            if (existsUnitEnteredForCalculationRecord == null)
            {
                this.data.UnitEnteredForCalculationDatas.Add(newUnitEnteredForCalculationRecord);   
            }
            else
            {
                existsUnitEnteredForCalculationRecord.OldValue = oldValue;
                existsUnitEnteredForCalculationRecord.NewValue = newValue;
                this.data.UnitEnteredForCalculationDatas.Update(existsUnitEnteredForCalculationRecord);
            }
        }

        ///  <summary>
        /// 1) P1 ;ПАРА-КОНСУМИРАНА [ТОНОВЕ] :: X A1,F Q
        ///  </summary>            
        private double FormulaP1(FormulaArguments args) 
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.Pressure.HasValue)
            {
                throw new ArgumentNullException("The value of Pressure(P) is not allowed to be null");
            }
            if (!args.Temperature.HasValue)
            {
                throw new ArgumentNullException("The value of Temperature(T) is not allowed to be null");
            }
            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }
            if (!args.EstimatedPressure.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedPressure(D5) is not allowed to be null");
            }
            if (!args.EstimatedTemperature.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedTemperature(D6) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double p = args.Pressure.Value;
            double t = args.Temperature.Value;
            double d2 = args.MaximumFlow.Value;
            double d5 = args.EstimatedPressure.Value;
            double d6 = args.EstimatedTemperature.Value;

            double a1 = Functions.GetValueFormulaA1(p, t, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a1);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            double result = calculator.Calculate("par.f", "par", 1, inputParams);
            return result;
        }
        
        /// <summary>
        /// 2) PP1 ;ПАРА-ПРОИЗВЕДЕНА [ТОНОВЕ] :: X A1,F Q
        /// </summary>
        private double FormulaPP1(FormulaArguments args)
        {
            double p = 20;
            double t = 20;
            double d2 = 15;
            double pl = 20;
            double d5 = 2;
            double d6 = 2;
            double a1 = Functions.GetValueFormulaA1(p, t, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a1);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);
            double result = calculator.Calculate("par.f", "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 3) Z1 ;ПАРА-КОНСУМИРАНА [MWH] :: X A1,F,K15,K2,K3,EN S Q=Q*ENT/0.860 Q
        /// </summary>
        private double FormulaZ1(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.Pressure.HasValue)
            {
                args.Pressure = args.EstimatedPressure;
            }
            if (!args.Temperature.HasValue)
            {
                args.Temperature = args.EstimatedTemperature;
            }
            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }
            if (!args.EstimatedPressure.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedPressure(D5) is not allowed to be null");
            }
            if (!args.EstimatedTemperature.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedTemperature(D6) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double p = args.Pressure.Value;
            double t = args.Temperature.Value;
            double d2 = args.MaximumFlow.Value;
            double d5 = args.EstimatedPressure.Value;
            double d6 = args.EstimatedTemperature.Value;

            double a1 = Functions.GetValueFormulaA1(p, t, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a1);
            double ent = Functions.GetValueFormulaEN(t, p);            

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);
            inputParams.Add("ent", ent);
            string expr = @"(par.f*par.ent)/0.860";
            double result = calculator.Calculate(expr, "par", 2, inputParams);
            return result;
        }

        /// <summary>
        /// 4) ZZ1 ;ПАРА-ПРОИЗВЕДЕНА [MWH] :: X A1,F,K15,K2,K3,EN S Q=Q*ENT/0.860 Q
        /// </summary>
        private double FormulaZZ1(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.Pressure.HasValue)
            {
                throw new ArgumentNullException("The value of Pressure(P) is not allowed to be null");
            }
            if (!args.Temperature.HasValue)
            {
                throw new ArgumentNullException("The value of Temperature(T) is not allowed to be null");
            }
            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }
            if (!args.EstimatedPressure.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedPressure(D5) is not allowed to be null");
            }
            if (!args.EstimatedTemperature.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedTemperature(D6) is not allowed to be null");
            }
            
            double pl = args.InputValue.Value;
            double p = args.Pressure.Value;
            double t = args.Temperature.Value;
            double d2 = args.MaximumFlow.Value;
            double d5 = args.EstimatedPressure.Value;
            double d6 = args.EstimatedTemperature.Value;

            double a1 = Functions.GetValueFormulaA1(p, t, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a1);
            double ent = Functions.GetValueFormulaEN(t, p);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);
            inputParams.Add("ent", ent);
            string expr = @"(par.f*par.ent)/0.860";
            var result = calculator.Calculate(expr, "par", 2, inputParams);
            return result;
        }

        /// <summary>
        /// 5) Z2 ;ПАРА-КОНСУМИРАНА, АСУТП, [MWH] :: X K15,K2,K3,EN S Q=PL*ENT/0.860 Q
        /// </summary>
        private double FormulaZ2(FormulaArguments args) 
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.Pressure.HasValue)
            {
                throw new ArgumentNullException("The value of Pressure(P) is not allowed to be null");
            }
            if (!args.Temperature.HasValue)
            {
                throw new ArgumentNullException("The value of Temperature(T) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double p = args.Pressure.Value;
            double t = args.Temperature.Value;

            double ent = Functions.GetValueFormulaEN(t, p);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("pl", pl);
            inputParams.Add("ent", ent);

            string expr = @"(par.pl*par.ent)/0.860";
            var result = calculator.Calculate(expr, "par", 2, inputParams);
            return result;
        }

        /// <summary>
        ///  6) ZZ2 ;ПАРА-ПРОИЗВЕДЕНА, АСУТП, [MWH] :: X K15,K2,K3,EN S Q=PL*ENT/0.860 Q
        /// </summary>
        private double FormulaZZ2(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.Pressure.HasValue)
            {
                throw new ArgumentNullException("The value of Pressure(P) is not allowed to be null");
            }
            if (!args.Temperature.HasValue)
            {
                throw new ArgumentNullException("The value of Temperature(T) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double p = args.Pressure.Value;
            double t = args.Temperature.Value;
            double ent = Functions.GetValueFormulaEN(t, p);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("pl", pl);
            inputParams.Add("ent", ent);

            string expr = @"(par.pl*par.ent)/0.860";
            double result = calculator.Calculate(expr, "par", 2, inputParams);
            return result;
        }

        /// <summary>
        /// 7) N2 ;ТЕЧНИ НЕФТОПРОДУКТИ И ВТЕЧНЕНИ ГАЗОВЕ ;ИЗЧИСЛЯВАНЕ НА ПЛЪТНОСТ :: S:D<0.5 D=0.5 X C,A2,F Q 
        /// </summary>
        private double FormulaN2(FormulaArguments args)
        {
            double c = 0;
            double a2 = 0;
            double f = 0;
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            double al = 0.001163;

            if (d < 0.5)
            {
                d = 0.5;
            }
            c = Functions.GetValueFormulaC(t, d, al);
            a2 = Functions.GetValueFormulaA2(p, t, c, d4, d5, d6);
            f = Functions.GetValueFormulaF(d2, pl, a2);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 8) G2 ;НЕФТОЗАВОДСКИ ГАЗ И ВОДОРОД :: S DF=D X A2,F Q
        /// </summary>
        private double FormulaG2(FormulaArguments args)
        {
            double a2 = 0;
            double f = 0;
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            a2 = Functions.GetValueFormulaA2(p, t, d, d4, d5, d6);
            f = Functions.GetValueFormulaF(d2, pl, a2);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 9) V2 ;КОНДЕНЗАТ И ХОВ :: X C1,A2,F Q
        /// </summary>
        private double FormulaV2(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double qpt3 = 0.9787;
            double a2 = Functions.GetValueFormulaA2(p, t, qpt3, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a2);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 10) N3 ;ТЕЧНИ НЕФТОПРОДУКТИ И ВТЕЧНЕНИ ГАЗОВЕ :: S:D<0.5 D=0.5 X C,A7,F S Q=Q*DF Q
        /// </summary>
        private double FormulaN3(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            double al = 0.001163;
            if (d < 0.5)
            {
                d = 0.5;
            }
            double c = Functions.GetValueFormulaC(t, d, al);
            double a7 = Functions.GetValueFormulaA7(p, t, d, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a7);
            f = f * c;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 11) G3 ;НЕФТОЗАВОДСКИ ГАЗ :: S DF=D X A7,F S Q=Q*DF Q
        /// </summary>
        private double FormulaG3(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            double df = d;
            
            double a7 = Functions.GetValueFormulaA7(p, t, d, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a7);
            f = f * df;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 12) G3 ;КОНДЕНЗАТ И ХОВ :: X C1,A7,F S Q=Q*DF Q
        /// </summary>
        private double FormulaV3(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            double qpt3 = 0.9929;
            double df = qpt3;
            
            //double c1 = Functions.GetValueFormulaC1(p, t, qpt3);
            double a7 = Functions.GetValueFormulaA7(p, t, d, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a7);
            f = f * df;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 13) PP3 ;МРЕЖОВА ВОДА :: X C1,A7,F S Q=Q*DF Q
        /// </summary>
        private double FormulaPP3(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            double qpt3 = 0.9929;
            double df = qpt3;

            //double c1 = Functions.GetValueFormulaC1(p, t, qpt3);
            double a7 = Functions.GetValueFormulaA7(p, t, d, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a7);
            f = f * df;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 14) N4 ;ТЕЧНИ НЕФТОПРОДУКТИ И ВТЕЧНЕНИ ГАЗОВЕ :: S:D<0.5 D=0.5 X C,A3,F Q
        /// </summary>
        private double FormulaN4(FormulaArguments args)
        {
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d6 = 50;
            double d = 50;
            double al = 0.001163;            
            if (d < 0.5)
            {
                d = 0.5;
            }

            double c = Functions.GetValueFormulaC(t, d, al);
            double a3 = Functions.GetValueFormulaA3(t, c, d4, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a3);
            
            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 15) N5 ;ТЕЧНИ НЕФТОПРОДУКТИ И ВТЕЧНЕНИ ГАЗОВЕ :: S:D<0.5 D=0.5 X C,A15,F S Q=Q*DF Q
        /// </summary>
        private double FormulaN5(FormulaArguments args)
        {
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d6 = 50;
            double d = 50;
            double al = 0.001163;
            if (d < 0.5)
            {
                d = 0.5;
            }

            double df = Functions.GetValueFormulaC(t, d, al);
            double a15 = Functions.GetValueFormulaA15(t, df, d4, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a15);
            f = f * df;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 16) G6 ;НЕФТОЗАВОДСКИ ГАЗ И ВОДОРОД :: X A4,F S Q=Q/1000 Q
        /// </summary>
        private double FormulaG6(FormulaArguments args)
        {
            double p = 15;
            double pl = 20;
            double d2 = 15;
            double d5 = 10;

            double a4 = Functions.GetValueFormulaA4(p, d5);
            double f = Functions.GetValueFormulaF(d2, pl, a4);
            f = f / 1000;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 17) G7 ;НЕФТОЗАВОДСКИ ГАЗ И ВОДОРОД :: S DF=D X A7,F S Q=Q*DF/1000 Q
        /// </summary>
        private double FormulaG7(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            double df = d;

            double a7 = Functions.GetValueFormulaA7(p, t, d, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a7);
            f = (f * df) / 1000;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 20) R10 ;ПРИРОДЕН ГАЗ :: X A7,F S Q=Q/1000 Q
        /// </summary>
        private double FormulaR10(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double d2 = 15;
            double d4 = 5;
            double d5 = 10;
            double d6 = 50;
            double d = 50;
            
            double a7 = Functions.GetValueFormulaA7(p, t, d, d4, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a7);
            f = f / 1000;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 23) O13 ;ОБОРОТНИ, ПИТЕЙНИ И ОТПАДНИ ВОДИ :: X A10 Q
        /// </summary>
        private double FormulaO13(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }

            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double d2 = args.MaximumFlow.Value;
            
            double q = Functions.GetValueFormulaA10(pl, d2);
            
            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 26) V14 ;КОНДЕНЗАТ, ХОВ :: X A10 Q
        /// </summary>
        private double FormulaV14(FormulaArguments args)
        {
            double pl = 20;
            double d2 = 15;

            double q = Functions.GetValueFormulaA10(pl, d2);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 30) I16 ;ВЪЗДУХ, АЗОТ, КИСЛОРОД :: X A1,F Q
        /// </summary>
        private double FormulaI16(FormulaArguments args)
        {
            double p = 20;
            double t = 20;
            double d2 = 15;
            double pl = 20;
            double d5 = 2;
            double d6 = 2;
            double a1 = Functions.GetValueFormulaA1(p, t, d5, d6);
            double f = Functions.GetValueFormulaF(d2, pl, a1);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 31) I17 ;ВЪЗДУХ, АЗОТ, КИСЛОРОД :: X A4,F Q
        /// </summary>
        private double FormulaI17(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }
            if (!args.EstimatedPressure.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedPressure(D5) is not allowed to be null");
            }
            if (!args.Pressure.HasValue)
            {
                args.Pressure = args.EstimatedPressure;
            }

            double pl = args.InputValue.Value;
            double p = args.Pressure.Value;
            double d2 = args.MaximumFlow.Value;
            double d5 = args.EstimatedPressure.Value;

            double a4 = Functions.GetValueFormulaA4(p, d5);
            double f = Functions.GetValueFormulaF(d2, pl, a4);
            
            var inputParams = new Dictionary<string, double>();
            inputParams.Add("f", f);

            string expr = @"par.f";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 32) R18 ;БРОЯЧИ ЗА ПРИРОДЕН ГАЗ :: X A11 Q
        /// </summary>
        private double FormulaR18(FormulaArguments args)
        {
            double pl = 20;
            double pl1 = 10;
            double d2 = 15;

            double q = Functions.GetValueFormulaA11(pl, pl1, d2);
            
            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 41) ZZ52 ;БРОЯЧИ ЗА ПАРА - ДОБАВЕНО 03/05/2007 - ЗА ТЕЦА /ТЦ104/  :: X A11 Q
        /// </summary>
        private double FormulaZZ52(FormulaArguments args)
        {
            double pl = 20;
            double pl1 = 10;
            double d2 = 15;

            double q = Functions.GetValueFormulaA11(pl, pl1, d2);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 42) Z18 ;БРОЯЧИ ЗА ПАРА [MWH] :: X A11,K15,K2,K3,EN S Q=Q*ENT/0.860 Q
        /// </summary>
        private double FormulaZ18(FormulaArguments args)
        {
            double p = 15;
            double t = 40;
            double pl = 20;
            double pl1 = 10;
            double d2 = 15;
            double a11 = Functions.GetValueFormulaA11(pl, pl1, d2);
            double ent = Functions.GetValueFormulaEN(t, p);
            double q = (a11 * ent) / 0.860;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"(par.q)";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// // 34) N18 ;;БРОЯЧИ ЗА НЕФТОПРОДУКТИ И ВТЕЧНЕНИ ГАЗОВЕ :: X A11 Q
        /// </summary>
        public double FormulaN18(FormulaArguments args)              
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.OldValue.HasValue)
            {
                throw new ArgumentNullException("The value of Old CounterIndication(PL-1) is not allowed to be null");
            }
            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double pl1 = args.OldValue.Value;
            double d2 = args.MaximumFlow.Value;

            double q = Functions.GetValueFormulaA11(pl, pl1, d2);

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);
            string expr = @"par.q";
            var result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 47) N19 ;БРОЯЧИ ЗА НЕФТОПРОДУКТИ :: S:D<0.5 D=0.5 X C,A11 S Q=Q*DF Q
        /// </summary>
        private double FormulaN19(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.OldValue.HasValue)
            {
                throw new ArgumentNullException("The value of Old CounterIndication(PL-1) is not allowed to be null");
            }
            if (!args.EstimatedTemperature.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedTemperature(D6) is not allowed to be null");
            }
            if (!args.Temperature.HasValue)
            {
                args.Temperature = args.EstimatedTemperature;
            }
            if (!args.MaximumFlow.HasValue)
            {
                throw new ArgumentNullException("The value of MaximumFlow(D2) is not allowed to be null");
            }
            if (!args.EstimatedDensity.HasValue)
            {
                throw new ArgumentNullException("The value of EstimatedPressure(D5) is not allowed to be null");
            }
            if (!args.Density.HasValue)
            {
                args.Density = args.EstimatedDensity;
            }

            double pl = args.InputValue.Value;
            double pl1 = args.OldValue.Value;
            double t = args.Temperature.Value;
            double d = args.Density.Value;
            double d2 = args.MaximumFlow.Value;
            double al = 0.001163;
            if (d < 0.5)
            {
                d = 0.5;
            }
            double c = Functions.GetValueFormulaC(t, d, al);
            double a11 = Functions.GetValueFormulaA11(pl, pl1, d2);
            double q = a11 * c;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        ///  48) G19 ;БРОЯЧИ ЗА ГАЗОВЕ :: S DF=D X A11 S Q=Q*DF Q
        /// </summary>
        private double FormulaG19(FormulaArguments args)
        {
            double pl = 20;
            double pl1 = 10;
            double d = 50;
            double d2 = 15;
            double df = d;

            double q = Functions.GetValueFormulaA11(pl, pl1, d2);
            q = q * df;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 62) G26 ;ПРЕВРЪЩАНЕ ДИМЕНСИЯТА ОТ "Н.M.КУБ." В "ТОНОВЕ" :: S Q=PL*D Q
        /// </summary>
        private double FormulaG26(FormulaArguments args)
        {
            if (!args.InputValue.HasValue)
            {
                throw new ArgumentNullException("The value of CounterIndication(PL) is not allowed to be null");
            }
            if (!args.EstimatedDensity.HasValue)
            {
                throw new ArgumentNullException("The value of Density(D) is not allowed to be null");
            }

            double pl = args.InputValue.Value;
            double d = args.EstimatedDensity.Value;           
            double q = pl * d;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 63) P26 ;ПРЕВРЪЩАНЕ ДИМЕНСИЯТА ОТ "M.КУБ." В "ТОНОВЕ" :: S Q=PL*D Q
        /// </summary>
        private double FormulaP26(FormulaArguments args)
        {
            double pl = 20;
            double d = 50;
            double q = pl * d;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }

        /// <summary>
        /// 87) N42 ;НЕФТОПРОДУКТИ /ХО-1/ :: S:D<0.5 D=0.5 X C S Q=PL*DF Q
        /// </summary>
        private double FormulaN42(FormulaArguments args)
        {
            double pl = 20;
            double t = 40;
            double d = 50;
            double al = 0.001163;
            if (d < 0.5)
            {
                d = 0.5;
            }
            double c = Functions.GetValueFormulaC(t, d, al);
            double q = pl * c;

            var inputParams = new Dictionary<string, double>();
            inputParams.Add("q", q);

            string expr = @"par.q";
            double result = calculator.Calculate(expr, "par", 1, inputParams);
            return result;
        }
    }
}