﻿namespace CollectingProductionDataSystem.Data.Mappings
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using CollectingProductionDataSystem.Models.Productions;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RelatedUnitConfigsMap : EntityTypeConfiguration<RelatedUnitConfigs>
    {
        public RelatedUnitConfigsMap()
        {
            this.HasKey(t => new { t.UnitConfigId, t.RelatedUnitConfigId });

            this.HasRequired(p => p.RelatedUnitConfig).WithMany().WillCascadeOnDelete(false);

            //this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
