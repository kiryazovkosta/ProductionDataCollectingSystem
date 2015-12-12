﻿using System.Text;
using CollectingProductionDataSystem.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollectingProductionDataSystem.Models.Productions;

namespace CollectingProductionDataSystem.Web.ViewModels.Units
{
    public class FactoryViewModel : IMapFrom<Factory>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  FullName { get; set; }

        public string FactorySortableName
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(this.Id.ToString("d2"));
                sb.Append(" ");
                sb.Append(this.Name);
                return sb.ToString();
            }
        }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Factory, FactoryViewModel>()
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.ShortName));
        }
    }
}