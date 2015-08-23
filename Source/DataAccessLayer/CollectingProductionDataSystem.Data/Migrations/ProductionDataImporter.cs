﻿namespace CollectingProductionDataSystem.Data.Migrations
{
    using CollectingProductionDataSystem.Models.Productions;
    using System.Data.Entity.Migrations;

    internal class ProductionDataImporter
    {
        internal static void Insert(CollectingDataSystemDbContext context)
        {
            context.Plants.AddOrUpdate(
                p => p.Id,
                new Plant
                {
                    ShortName = "ПД",
                    FullName = "ПРОИЗВОДСТВЕНА ДЕЙНОСТ",
                    Factories = {
                        new Factory
                        {
                            ShortName = "АВД",
                            FullName = "Производство АВД",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "АД-4",
                                    FullName = "Инсталация АД-4",
                                    UnitsConfigs = { }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "АВД-1",
                                    FullName = "Инсталация АВД-1",
                                    UnitsConfigs = {
                                        new UnitConfig
                                        {
                                            Code = "1A0100",
                                            Position = "01-FICQ-001",
                                            Name = "Нефт вход АВД-1",
                                            ProductTypeId = 1,
                                            ProductId = 1,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FICQ-001.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FICQ-001.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0200",
                                            Position = "01-FIQ-646А",
                                            Name = "Бензин отгони",
                                            ProductTypeId = 1,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-646A.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-646A.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0300",
                                            Position = "01-FIQ-014",
                                            Name = "Нефт - некондиция от Е-10",
                                            ProductTypeId = 1,
                                            DirectionId = 3,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-014.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-014.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0400",
                                            Position = "01-FIQ-147",
                                            Name = "Некондиция от Р-1",
                                            ProductTypeId = 1,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = false,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-147.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-147.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0500",
                                            Position = "01-FIQ-134",
                                            Name = "Сух газ от Е-101",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-134.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-134.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0600",
                                            Position = "01-FIQ-135",
                                            Name = "Сух газ от Е-104",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-135.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-135.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0700",
                                            Position = "01-FICQ-048",
                                            Name = "Пропан-бутан към ЦГФИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FICQ-048.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FICQ-048.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0701",
                                            Position = "01-FICQ-048",
                                            Name = "Пропан-бутан към парк Братово",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0800",
                                            Position = "01-FIQ-050",
                                            Name = "Бензин връх К105 н.к100 към ХО-1",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-050.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-050.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0801",
                                            Position = "01-FIQ-050",
                                            Name = "Бензин връх К105 н.к100 към т.31",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0802",
                                            Position = "01-FIQ-050",
                                            Name = "Бензин връх К105 н.к100 към Мерокс",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0803",
                                            Position = "01-FIQ-050",
                                            Name = "Бензин връх К105 н.к100 към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0804",
                                            Position = "01-FIQ-050",
                                            Name = "Бензин връх К105 н.к100 към Некондиция",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0900",
                                            Position = "01-FIQ-045",
                                            Name = "Бензин дъно К-105 фр.85-180 към КР-1",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-045.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-045.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0901",
                                            Position = "01-FIQ-045",
                                            Name = "Бензин дъно К-105 фр.85-180 към т.31",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0902",
                                            Position = "01-FIQ-045",
                                            Name = "Бензин дъно К-105 фр.85-180 към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A0903",
                                            Position = "01-FIQ-045",
                                            Name = "Бензин дъно К-105 фр.85-180 към некондиция",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1000",
                                            Position = "01-FIQ-047",
                                            Name = "Лека дизелова фракция към ХО-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "А",
                                            PreviousShiftTag = "AV1_01-FIQ-047.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-047.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1001",
                                            Position = "01-FIQ-047",
                                            Name = "Лека дизелова фракция към ХО-3",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1002",
                                            Position = "01-FIQ-047",
                                            Name = "Лека дизелова фракция към ХО-5",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1003",
                                            Position = "01-FIQ-047",
                                            Name = "Лека дизелова фракция към ТСНП",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1004",
                                            Position = "01-FIQ-047",
                                            Name = "Лека дизелова фракция към некондиция",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1100",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към ХО-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "А",
                                            PreviousShiftTag = "AV1_01-FIQ-046.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-046.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1101",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към ХО-3",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1102",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към ХО-5",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1103",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към ТСНП",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1104",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към некондиция",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1105",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към промивка БИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1106",
                                            Position = "01-FIQ-046",
                                            Name = "Тежка дизелова фракция към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "М",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1200",
                                            Position = "01-FIQ-049",
                                            Name = "ААтмосферен Газьол към ХО-5",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-049.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-049.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1201",
                                            Position = "01-FIQ-049",
                                            Name = "Атмосферен Газьол към ККр",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1202",
                                            Position = "01-FIQ-049",
                                            Name = "Атмосферен Газьол към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1203",
                                            Position = "01-FIQ-049",
                                            Name = "Атмосферен Газьол към некондиция",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1300",
                                            Position = "01-FIС-090",
                                            Name = "Мазут към П-1",
                                            ProductTypeId = 2,
                                            DirectionId = 3,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIC-090.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIC-090.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1400",
                                            Position = "01-FIСQ-201",
                                            Name = "Мазут към ВД-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIСQ-201.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIСQ-201.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1401",
                                            Position = "01-FIСQ-201",
                                            Name = "Мазут към Р-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1402",
                                            Position = "01-FIСQ-201",
                                            Name = "Мазут към Р-1",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1500",
                                            Position = "01-FIQ-117",
                                            Name = "Нефопродукт от Е-3 към ХО-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-117.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-117.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1501",
                                            Position = "01-FIQ-117",
                                            Name = "Нефопродукт от Е-3 към ХО-3",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1502",
                                            Position = "01-FIQ-117",
                                            Name = "Нефопродукт от Е-3 към ХО-5",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1503",
                                            Position = "01-FIQ-117",
                                            Name = "Нефопродукт от Е-3 към некондиция",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1600",
                                            Position = "01-FIСQ-086",
                                            Name = "ШМФ към ККр",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FICQ-086.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FICQ-086.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1601",
                                            Position = "01-FIСQ-086",
                                            Name = "ШМФ към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1602",
                                            Position = "01-FIСQ-086",
                                            Name = "ШМФ към промивка БИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1700",
                                            Position = "01-FIQ-087",
                                            Name = "ШМФ към Р-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-087.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-087.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1701",
                                            Position = "01-FIQ-087",
                                            Name = "ШМФ към Р-1",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1800",
                                            Position = "01-FICQ-088",
                                            Name = "ТДФ от ВДМ1 към ХО-2",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FICQ-088.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FICQ-088.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1801",
                                            Position = "01-FICQ-088",
                                            Name = "ТДФ от ВДМ1 към ХО-3",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1802",
                                            Position = "01-FICQ-088",
                                            Name = "ТДФ от ВДМ1 към ХО-5",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1803",
                                            Position = "01-FICQ-088",
                                            Name = "ТДФ от ВДМ1 към ТСНП",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1804",
                                            Position = "01-FICQ-088",
                                            Name = "ТДФ от ВДМ1 към промивка БИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A1900",
                                            Position = "01-FICQ-085",
                                            Name = "Слоп",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FICQ-085.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FICQ-085.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2000",
                                            Position = "01-FIQ-084",
                                            Name = "Гудрон към БИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-084.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-084.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2001",
                                            Position = "01-FIQ-084",
                                            Name = "Гудрон към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2002",
                                            Position = "01-FIQ-084",
                                            Name = "Гудрон към ТК",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2100",
                                            Position = "01-FIQ-083",
                                            Name = "Гудрон към БИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-083.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-083.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2101",
                                            Position = "01-FIQ-083",
                                            Name = "Гудрон към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2102",
                                            Position = "01-FIQ-083",
                                            Name = "Гудрон към ТК",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2200",
                                            Position = "01-FICQ-082",
                                            Name = "Гудрон към БИ",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FICQ-082.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FICQ-082.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2201",
                                            Position = "01-FICQ-082",
                                            Name = "Гудрон към КПТО",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2202",
                                            Position = "01-FICQ-082",
                                            Name = "Гудрон към ТК",
                                            ProductTypeId = 2,
                                            DirectionId = 1,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "M",
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2300",
                                            Position = "01-FIQ-119",
                                            Name = "Обор. вода към АД_1",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 13,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-119.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-119.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2400",
                                            Position = "01-FIQ-120",
                                            Name = "Обор. вода към АД_2",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 13,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-120.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-120.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2500",
                                            Position = "01-FIQ-121",
                                            Name = "Обор. вода към ВД_1",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 13,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-121.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-121.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2600",
                                            Position = "01-FIQ-122",
                                            Name = "Обор. вода към ВД_2",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 13,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-122.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-122.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2700",
                                            Position = "01-FIQ-139",
                                            Name = "Свежа вода",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 13,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-139.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-139.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2800",
                                            Position = "01-FIQ-026",
                                            Name = "Деминерализирана вода",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 13,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-026.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-026.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A2900",
                                            Position = "01-FIQ-125",
                                            Name = "КИП въздух",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-125.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-125.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3000",
                                            Position = "01-FIQ-133",
                                            Name = "Азот",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-133.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-133.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3100",
                                            Position = "01-FIQ-126",
                                            Name = "ВГГ за АВД-1",
                                            ProductTypeId = 9,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-126.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-126.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3200",
                                            Position = "01-FIQ-089",
                                            Name = "Пара ВД",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-089.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-089.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3201",
                                            Position = "01-FIQ-089",
                                            Name = "Температура",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 6,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = null,
                                            CurrentInspectionDataTag = "AV1_01-TI-257.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3202",
                                            Position = "01-FIQ-089",
                                            Name = "Налягане",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 5,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = null,
                                            CurrentInspectionDataTag = "AV1_01-PIC-064.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3203",
                                            Position = "01-FIQ-089",
                                            Name = "Количество енергия",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 12,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsCalculated = true,
                                            CollectingDataMechanism = "C",
                                            PreviousShiftTag = null,
                                            CurrentInspectionDataTag = null
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3300",
                                            Position = "01-FIQ-118",
                                            Name = "Пара АД",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 11,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-118.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-118.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3301",
                                            Position = "01-FIQ-118",
                                            Name = "Температура",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 6,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "",
                                            CurrentInspectionDataTag = "AV1_01-TI-318.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3302",
                                            Position = "01-FIQ-118",
                                            Name = "Налягане",
                                            ProductTypeId = 10,
                                            DirectionId = 2,
                                            MeasureUnitId = 5,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "",
                                            CurrentInspectionDataTag = "AV1_01-PIC-096.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3303",
                                            Position = "01-FIQ-118",
                                            Name = "Количество енергия",
                                            ProductTypeId = 10,
                                            DirectionId = 1,
                                            MeasureUnitId = 12,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            PreviousShiftTag = null,
                                            CurrentInspectionDataTag = null,
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3400",
                                            Position = "01-FIQ-452",
                                            Name = "Котел изход пара",
                                            ProductTypeId = 10,
                                            DirectionId = 1,
                                            MeasureUnitId = 12,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "AV1_01-FIQ-452.TOTS_L",
                                            CurrentInspectionDataTag = "AV1_01-FIQ-452.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3401",
                                            Position = "01-FIQ-452",
                                            Name = "Температура",
                                            ProductTypeId = 10,
                                            DirectionId = 1,
                                            MeasureUnitId = 6,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "",
                                            CurrentInspectionDataTag = "AV1_01-TICA-452.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3402",
                                            Position = "01-FIQ-452",
                                            Name = "Налягане",
                                            ProductTypeId = 10,
                                            DirectionId = 1,
                                            MeasureUnitId = 5,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            IsInspectionPoint = true,
                                            CollectingDataMechanism = "A",
                                            PreviousShiftTag = "",
                                            CurrentInspectionDataTag = "AV1_01-PICA-452.PV"
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3403",
                                            Position = "01-FIQ-452",
                                            Name = "Количество енергия",
                                            ProductTypeId = 10,
                                            DirectionId = 1,
                                            MeasureUnitId = 5,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            PreviousShiftTag = null,
                                            CurrentInspectionDataTag = null
                                        },
                                        new UnitConfig
                                        {
                                            Position = null,
                                            Name = "Деемулгатор",
                                            ProductTypeId = 11,
                                            DirectionId = 2,
                                            MeasureUnitId = 4,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            IsDeleted = true
                                        },
                                        new UnitConfig
                                        {
                                            Position = null,
                                            Name = "Филмообразуващ инхибитор",
                                            ProductTypeId = 11,
                                            DirectionId = 2,
                                            MeasureUnitId = 4,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            IsDeleted = true
                                        },
                                        new UnitConfig
                                        {
                                            Position = null,
                                            Name = "Неутрализатор",
                                            ProductTypeId = 11,
                                            DirectionId = 2,
                                            MeasureUnitId = 4,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            IsDeleted = true
                                        },
                                        new UnitConfig
                                        {
                                            Position = null,
                                            Name = "NaOH",
                                            ProductTypeId = 11,
                                            DirectionId = 2,
                                            MeasureUnitId = 4,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            IsDeleted = true
                                        },
                                        new UnitConfig
                                        {
                                            Position = null,
                                            Name = "Поглътител на кислород",
                                            ProductTypeId = 11,
                                            DirectionId = 2,
                                            MeasureUnitId = 4,
                                            MaterialTypeId = 1,
                                            IsMaterial = true,
                                            IsEnergy = false,
                                            CollectingDataMechanism = "C",
                                            IsDeleted = true
                                        },
                                        new UnitConfig
                                        {
                                            Code = "1A3500",
                                            Position = "Електромер",
                                            Name = "Ел.енергия",
                                            ProductTypeId = 12,
                                            DirectionId = 2,
                                            MeasureUnitId = 12,
                                            MaterialTypeId = 2,
                                            IsMaterial = true,
                                            IsEnergy = true,
                                            CollectingDataMechanism = "C",
                                            IsDeleted = true
                                        },
                                    },
                                UnitsAggregateDailyConfigs = {
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0100",
                                        MeasureUnitId = 11,
                                        Name = "Нефт",
                                        ProductTypeId = 13,
                                        AggregationFormula = "1A0100-1А0804-1А0903-1А1004-1А1104-1А1105-1А1203-1А1402-1А1503-1А1804"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0200",
                                        MeasureUnitId = 11,
                                        Name = "Некондиция",
                                        ProductTypeId = 13,
                                        AggregationFormula = "1А0804+1А0903+1А1004+1А1104+1А1105+1А1203+1А1402+1А1503+1А1804"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0300",
                                        MeasureUnitId = 11,
                                        Name = "Некондиционни продукти",
                                        ProductTypeId = 13,
                                        AggregationFormula = "1А0300+1А0400"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0400",
                                        MeasureUnitId = 11,
                                        Name = "Бензин отгон",
                                        ProductTypeId = 13,
                                        AggregationFormula = "1А0200"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А9900",
                                        MeasureUnitId = 11,
                                        Name = "Бензин отгон",
                                        ProductTypeId = 13,
                                        AggregationFormula = "2A1+2A2+2A3+2A4"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0500",
                                        MeasureUnitId = 11,
                                        Name = "Бензинова фракция от АД",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A8+1A81+1A82+1A83+1A9+1A91+1A92"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0600",
                                        MeasureUnitId = 11,
                                        Name = "Керосинова фракция от АД",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A10+1A101"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0700",
                                        MeasureUnitId = 11,
                                        Name = "Дизелова фракция от АД",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A102+1A103+1A11+1A111+1A112+1A113+1A116"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0800",
                                        MeasureUnitId = 11,
                                        Name = "Дизелова фракция за ТСНП",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A183	"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0801",
                                        MeasureUnitId = 11,
                                        Name = "Дизелова фракция за ХО-1,2,3",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A15+1A151+1A18+1A181"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0802",
                                        MeasureUnitId = 11,
                                        Name = "Дизелова фракция за ХО-4,5",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A152++1A182"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0900",
                                        MeasureUnitId = 11,
                                        Name = "Атмосферен газьол за ККр",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A121"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0901",
                                        MeasureUnitId = 11,
                                        Name = "Атмосферен газьол за ХО-5",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A12"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А0902",
                                        MeasureUnitId = 11,
                                        Name = "Атмосферен газьол за КПТО",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A122"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А1000",
                                        MeasureUnitId = 11,
                                        Name = "ШМФ",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A16+1A161+1A162+1A17+1A171"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А1100",
                                        MeasureUnitId = 11,
                                        Name = "Мазут от първична дестилация",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A14+1A141+1A142"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А1200",
                                        MeasureUnitId = 11,
                                        Name = "Гудрон за ТСНП",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A20+1A201+1A202+1A21+1A211+1A212+1A22+1A221+1A222"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А1300",
                                        MeasureUnitId = 11,
                                        Name = "Пропан-бутан за ЦГФИ",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A7"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А1301",
                                        MeasureUnitId = 11,
                                        Name = "Пропан-бутан за Братово",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A71"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2А1400",
                                        MeasureUnitId = 11,
                                        Name = "Сух газ за АГФИ",
                                        ProductTypeId = 14,
                                        AggregationFormula = "1A5+1A6"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2A9900",
                                        MeasureUnitId = 11,
                                        Name = "Сума произведено",
                                        ProductTypeId = 14,
                                        AggregationFormula = "2A5+2A6+2A7+2A8+2A81+2A82+2A9+2A91+2A92+2A10+2A11+2A12+2A13+2A131+2A14"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2A9901",
                                        MeasureUnitId = 11,
                                        Name = "Загуби",
                                        ProductTypeId = 14,
                                        AggregationFormula = "2A0*0,002"
                                    },
                                    new UnitsAggregateDailyConfig
                                    {
                                        Code = "2A9902",
                                        MeasureUnitId = 11,
                                        Name = "Общо",
                                        ProductTypeId = 14,
                                        AggregationFormula = "2A00+2A000"
                                    },
                                }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ВДМ-2",
                                    FullName = "Инсталация ВДМ-2",
                                    UnitsConfigs = { }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ТК",
                                    FullName = "Инсталация ТК",
                                    UnitsConfigs = { }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "Битумна",
                                    FullName = "Инсталация Битумна",
                                    UnitsConfigs = { }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "КАБ",
                            FullName = " Производство КАБ",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "ХО и ГО (с.100)",
                                    FullName = "Инсталация ХО и ГО (с.100)",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ККр (с.200)",
                                    FullName = "Инсталация ККр (с.200)",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "АГФИ (с.300)",
                                    FullName = "Инсталация Абс. И Гфр. (с.300)",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ВИ-15 и PSA",
                                    FullName = "Инсталация ВИ-15 и PSA",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "СКА и PОК",
                                    FullName = "Инсталация СКА и PОК",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "МТБЕ",
                                    FullName = "Инсталация МТБЕ",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "КОГ",
                            FullName = "Производство КОГ",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "ЦГФИ и ИНБ",
                                    FullName = "Инсталация ЦГФИ и ИНБ",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "КР-1",
                                    FullName = "Инсталация КР-1",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХХ",
                                    FullName = "Инсталация Хидроочистка и хидриране",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "АГФИ и факел F-1",
                                    FullName = "Инсталация АГФИ и факел F-1",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХО-1",
                                    FullName = "Инсталация ХО-1",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХО-3",
                                    FullName = "Инсталация ХО-3",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ГО-2",
                                    FullName = "Инсталация ГО-2",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "П-37",
                                    FullName = "Парк 37",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "КОГ-2",
                            FullName = "Производство КОГ-2",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "ХО-2",
                                    FullName = "Инсталация ХО-2",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХО-5",
                                    FullName = "Инсталация ХО-5",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХОБ-1",
                                    FullName = "Инсталация ХОБ-1",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХО-4",
                                    FullName = "Инсталация ХО-4",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "КПТО",
                            FullName = "Производство КПТО",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "H-Oil",
                                    FullName = "Инсталация H-Oil",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ВИ-71",
                                    FullName = "Инсталация ВИ-71",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "РМДЕА и КВ",
                                    FullName = "Инсталация Регенерация на МДЕА и КВ",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ГС-4",
                                    FullName = "Инсталация ГС-4",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "МДЕА и АО",
                                    FullName = "Инсталация МДЕА и АО",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ГС-3",
                                    FullName = "Инсталация ГС-3",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ГС-2",
                                    FullName = "Инсталация ГС-2",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "ПП",
                            FullName = "Производство Полипропилен",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "ПП",
                                    FullName = "Инсталация Полипропилен",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "АК",
                            FullName = "Производство Азотно-кислородно",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "АК",
                                    FullName = "Инсталация Азотно-кислородно",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "ТСНП и ПТР",
                            FullName = "Производство ТСНП и ПТ Росенец",
                            ProcessUnits = 
                            {
                                new ProcessUnit
                                {
                                    ShortName = "ПТР",
                                    FullName = "ПТ Росенец",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ТСНП",
                                    FullName = "ТСНП",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "ВиК и ОС",
                            FullName = "Производство ВиК и ОС",
                            ProcessUnits = 
                            {
                                new ProcessUnit
                                {
                                    ShortName = "СВ",
                                    FullName = "Свежа вода",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "СВВК",
                                    FullName = "Свежа вода - външни консуматори",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ПВ",
                                    FullName = "Питейна вода",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ПВВК",
                                    FullName = "Питейна вода - външни консуматори",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "Ел ВиК",
                                    FullName = "Ел. енергия ВиК",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ХООБ",
                                    FullName = "Химикали за обр. на оборотната вода",
                                    UnitsConfigs = {
                                    }
                                },
                                new ProcessUnit
                                {
                                    ShortName = "ОС",
                                    FullName = "Очистни съоръжение",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                        new Factory
                        {
                            ShortName = "ТЕЦ",
                            FullName = "Производство ТЕЦ",
                            ProcessUnits = {
                                new ProcessUnit
                                {
                                    ShortName = "ТЕЦ",
                                    FullName = "Инсталация ТЕЦ",
                                    UnitsConfigs = {
                                    }
                                }
                            }
                        },
                    }
                });

            context.SaveChanges("Initial System Loading");
        }
    }
}
