﻿namespace CollectingProductionDataSystem.Web.Areas.NomManagement.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using CollectingProductionDataSystem.Infrastructure.Mapping;
    using CollectingProductionDataSystem.Models.Contracts;
    using CollectingProductionDataSystem.Models.Productions;
    using Resources = App_GlobalResources.Resources;

    public class ProductionPlanConfigDropDownViewModel : IMapFrom<ProductionPlanConfig>, IEntity, IHaveCustomMappings
    {
        [Required]
        [UIHint("Hidden")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Layout))]
        public string DisplayText { get; set; }

         public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ProductionPlanConfig, ProductionPlanConfigDropDownViewModel>()
                    .ForMember(p => p.DisplayText, opt => opt.MapFrom(p => string.Format("{0} - {1}",p.Code, p.Name)));
        }
    }
}