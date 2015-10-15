﻿namespace CollectingProductionDataSystem.Web.Areas.ShiftReporting.ViewModels
{
    using AutoMapper;
    using CollectingProductionDataSystem.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using CollectingProductionDataSystem.Models.Productions;
    using System.ComponentModel.DataAnnotations;
    using Resources = App_GlobalResources.Resources;

    public class UnitsReportsDataViewModel : IMapFrom<MultiShift>, IHaveCustomMappings
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "№")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "RecordTimestamp", ResourceType = typeof(Resources.Layout))]
        public DateTime TimeStamp{get;set;}

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Code", ResourceType = typeof(Resources.Layout))]
        public string Code { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Position", ResourceType = typeof(Resources.Layout))]
        public string Position { get; set; }

        [UIHint("Hidden")]
        public int UnitConfigId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "UnitName", ResourceType = typeof(Resources.Layout))]
        public string UnitName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "MeasureUnit", ResourceType = typeof(Resources.Layout))]
        public string MeasureUnit { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Shift1QuantityValue", ResourceType = typeof(Resources.Layout))]
        public decimal Shift1QuantityValue { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Shift2QuantityValue", ResourceType = typeof(Resources.Layout))]
        public decimal Shift2QuantityValue { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "Shift3QuantityValue", ResourceType = typeof(Resources.Layout))]
        public decimal Shift3QuantityValue { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        [Display(Name = "TotalQuantityValue", ResourceType = typeof(Resources.Layout))]
        public double TotalQuantityValue { get; set; }
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<MultiShift, UnitsReportsDataViewModel>()
                .ForMember(p => p.Shift1QuantityValue, opt => opt.MapFrom(p => p.Shift1.RealValue))
                .ForMember(p => p.Shift2QuantityValue, opt => opt.MapFrom(p => p.Shift2.RealValue))
                .ForMember(p => p.Shift3QuantityValue, opt => opt.MapFrom(p => p.Shift3.RealValue));
        }
    }
}