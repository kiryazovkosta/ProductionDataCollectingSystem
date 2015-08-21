using System;
using System.Collections.Generic;
using CollectingProductionDataSystem.Models.Abstract;
using CollectingProductionDataSystem.Models.Contracts;
using CollectingProductionDataSystem.Models.Inventories;
using CollectingProductionDataSystem.Models.Nomenclatures;

namespace CollectingProductionDataSystem.Models.Inventories
{
    public partial class Park : DeletableEntity, IEntity
    {
        private ICollection<TankConfig> tankConfigs;

        public Park()
        {
            this.tankConfigs = new HashSet<TankConfig>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<TankConfig> TankConfigs 
        {
            get { return this.tankConfigs; }
            set { this.tankConfigs = value; } 
        }
    }
}
