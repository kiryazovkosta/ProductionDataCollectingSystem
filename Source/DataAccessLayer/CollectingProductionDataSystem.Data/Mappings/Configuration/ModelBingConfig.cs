﻿namespace CollectingProductionDataSystem.Data.Mappings.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ModelBingConfig
    {
        internal static void RegisterMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new AuditLogRecordMap());
            modelBuilder.Configurations.Add(new DirectionMap());
            modelBuilder.Configurations.Add(new EditReasonMap());
            modelBuilder.Configurations.Add(new FactoryMap());
            modelBuilder.Configurations.Add(new ParkMap());
            modelBuilder.Configurations.Add(new TankConfigMap());
            modelBuilder.Configurations.Add(new TankDataMap());
            modelBuilder.Configurations.Add(new MaterialTypeMap());
            modelBuilder.Configurations.Add(new MeasureUnitMap());
            modelBuilder.Configurations.Add(new PlantMap());
            modelBuilder.Configurations.Add(new ProcessUnitMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductTypeMap());
            modelBuilder.Configurations.Add(new UnitConfigMap());
            modelBuilder.Configurations.Add(new UnitsDataMap());
            modelBuilder.Configurations.Add(new UnitsManualDataMap());
            modelBuilder.Configurations.Add(new UnitsInspectionDataMap());
            modelBuilder.Configurations.Add(new IkunkMap());
            modelBuilder.Configurations.Add(new ZoneMap());
            modelBuilder.Configurations.Add(new MeasurementPointsProductsConfigMap());
            modelBuilder.Configurations.Add(new TransportTypeMap());
            modelBuilder.Configurations.Add(new UnitsAggregateDailyConfigMap());
            modelBuilder.Configurations.Add(new TankMasterProductMap());
        }
    }
}