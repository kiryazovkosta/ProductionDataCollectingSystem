﻿namespace CollectingProductionDataSystem.Models.Nomenclatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CollectingProductionDataSystem.Models.Abstract;
    using CollectingProductionDataSystem.Models.Contracts;
    using CollectingProductionDataSystem.Models.Productions;

    public partial class DailyProductType : DeletableEntity, IEntity
    {
        public DailyProductType()
        {
            this.UnitsDailyConfigs = new HashSet<UnitDailyConfig>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UnitDailyConfig> UnitsDailyConfigs { get; set; }
    }
}