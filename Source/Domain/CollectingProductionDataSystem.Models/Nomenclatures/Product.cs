namespace CollectingProductionDataSystem.Models.Nomenclatures
{
    using System;
    using System.Collections.Generic;
    using CollectingProductionDataSystem.Models.Abstract;
    using CollectingProductionDataSystem.Models.Contracts;
    using CollectingProductionDataSystem.Models.Inventories;
    using CollectingProductionDataSystem.Models.Productions;
    using CollectingProductionDataSystem.Models.Transactions;

    public partial class Product: DeletableEntity, IEntity
    {
        private ICollection<TankData> tanksDatas;
        private ICollection<UnitConfig> unitConfigs;
        private ICollection<MeasurementPointsProductsConfig> measurementPointsProductsConfigs;
        private ICollection<UnitsDailyConfig> unitsDailyConfigs;
        private ICollection<MeasuringPointsConfigsData> measuringPointsConfigsDatas;

        public Product()
        {
            this.tanksDatas = new HashSet<TankData>();
            this.unitConfigs = new HashSet<UnitConfig>();
            this.measurementPointsProductsConfigs = new HashSet<MeasurementPointsProductsConfig>();
            this.unitsDailyConfigs = new HashSet<UnitsDailyConfig>();
            this.measuringPointsConfigsDatas = new HashSet<MeasuringPointsConfigsData>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public virtual TankMasterProduct TankMasterProduct { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<TankData> TanksDatas 
        {
            get { return this.tanksDatas; }
            set { this.tanksDatas = value; }
        }

        public virtual ICollection<UnitConfig> UnitConfigs 
        {
            get { return this.unitConfigs; }
            set { this.unitConfigs = value; }
        }

        public virtual ICollection<MeasurementPointsProductsConfig> MeasurementPointsProductsConfigs 
        {
            get { return this.measurementPointsProductsConfigs; }
            set { this.measurementPointsProductsConfigs = value; }
        }

        public virtual ICollection<UnitsDailyConfig> UnitsDailyConfigs
        {
            get { return this.unitsDailyConfigs; }
            set { this.unitsDailyConfigs = value; }
        }

        public virtual ICollection<MeasuringPointsConfigsData> MeasuringPointsConfigsDatas 
        {
            get { return this.measuringPointsConfigsDatas; }
            set { this.measuringPointsConfigsDatas = value; }
        }
    }
}
