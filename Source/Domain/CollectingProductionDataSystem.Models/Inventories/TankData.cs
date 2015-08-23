namespace CollectingProductionDataSystem.Models.Inventories
{
    using System;
    using CollectingProductionDataSystem.Models.Abstract;
    using CollectingProductionDataSystem.Models.Contracts;
    using CollectingProductionDataSystem.Models.Nomenclatures;

    public partial class TankData: AuditInfo, IApprovableEntity, IEntity
    {
        public int Id { get; set; }
        public DateTime RecordTimestamp { get; set; }
        public int TankConfigId { get; set; }
        public int ParkId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? LiquidLevel { get; set; }
        public decimal? TotalObservableVolume { get; set; }
        public decimal? ProductLevel { get; set; }
        public decimal? GrossObservableVolume { get; set; }
        public decimal? ObservableDensity { get; set; }
        public decimal? GrossStandardVolume { get; set; }
        public decimal? AverageTemperature { get; set; }
        public decimal? NetStandardVolume { get; set; }
        public decimal? ReferenceDensity { get; set; }
        public decimal? WeightInAir { get; set; }
        public decimal? WeightInVacuum { get; set; }
        public decimal? FreeWaterLevel { get; set; }
        public decimal? FreeWaterVolume { get; set; }
        public decimal? MaxVolume { get; set; }
        public decimal? AvailableRoom { get; set; }
        public decimal? UnusableResidueLevel { get; set; }
        public int? EditReasonId { get; set; }
        public bool IsApproved { get; set; }
        public virtual TankConfig TankConfig { get; set; }
        public virtual Product Product { get; set; }
        public virtual EditReason EditReason { get; set; }
        public virtual TanksManualData TanksManualData { get; set; }
    }
}
