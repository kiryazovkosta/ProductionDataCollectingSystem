﻿namespace CollectingProductionDataSystem.Models
{
    using CollectingProductionDataSystem.Common;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class InventoryTank : IActiveEntity
    {
        private ICollection<InventoryTanksData> inventoryTankData;

        public InventoryTank()
        {
            this.inventoryTankData = new HashSet<InventoryTanksData>();
        }

        [Key]
        public int Id { get; set; }

        public int InventoryParkId { get; set; }

        public string ControlPoint { get; set; }

        public string TankName { get; set; }

        [Index]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public string PhdTagProductId { get; set; }

        public string PhdTagProductName { get; set; }

        public string PhdTagLiquidLevel { get; set; }

        public decimal LiquidLevelLowExtreme { get; set; }

        public decimal LiquidLevelHighExtreme { get; set; }

        public string PhdTagProductLevel { get; set; }

        public decimal ProductLevelLowExtreme { get; set; }

        public decimal ProductLevelHighExtreme { get; set; }

        public string PhdTagFreeWaterLevel { get; set; }

        public decimal FreeWaterLevelLowExtreme { get; set; }

        public decimal FreeWaterLevelHighExtreme { get; set; }

        public string PhdTagFreeWaterVolume { get; set; }

        public decimal FreeWaterVolumeLowExtreme { get; set; }

        public decimal FreeWaterVolumeHighExtreme { get; set; }

        public string PhdTagObservableDensity { get; set; }

        public decimal ObservableDensityLowExtreme { get; set; }

        public decimal ObservableDensityHighExtreme { get; set; }

        public string PhdTagReferenceDensity { get; set; }

        public decimal ReferenceDensityLowExtreme { get; set; }

        public decimal ReferenceDensityHighExtreme { get; set; }

        public string PhdTagGrossObservableVolume { get; set; }

        public decimal GrossObservableVolumeLowExtreme { get; set; }

        public decimal GrossObservableVolumeHighExtreme { get; set; }

        public string PhdTagGrossStandardVolume { get; set; }

        public decimal GrossStandardVolumeLowExtreme { get; set; }

        public decimal GrossStandardVolumeHighExtreme { get; set; }

        public string PhdTagNetStandardVolume { get; set; }

        public decimal NetStandardVolumeLowExtreme { get; set; }

        public decimal NetStandardVolumeHighExtreme { get; set; }

        public string PhdTagWeightInAir { get; set; }

        public decimal WeightInAirLowExtreme { get; set; }

        public decimal WeightInAirHighExtreme { get; set; }

        public string PhdTagAverageTemperature { get; set; }

        public decimal AverageTemperatureLowExtreme { get; set; }

        public decimal AverageTemperatureHighExtreme { get; set; }

        public string PhdTagTotalObservableVolume { get; set; }

        public decimal TotalObservableVolumeLowExtreme { get; set; }

        public decimal TotalObservableVolumeHighExtreme { get; set; }

        public string PhdTagWeightInVacuum { get; set; }

        public decimal WeightInVacuumLowExtreme { get; set; }

        public decimal WeightInVacuumHighExtreme { get; set; }

        public string PhdTagMaxVolume { get; set; }

        public decimal MaxVolumeLowExtreme { get; set; }

        public decimal MaxVolumeHighExtreme { get; set; }

        public string PhdTagAvailableRoom { get; set; }

        public decimal AvailableRoomLowExtreme { get; set; }

        public decimal AvailableRoomHighExtreme { get; set; }

        public virtual InventoryPark InventoryPark { get; set; } 
 
        public virtual ICollection<InventoryTanksData> InventoryTankData
        {
            get { return this.inventoryTankData; }
            set { this.inventoryTankData = value; }
        }
    }
}
