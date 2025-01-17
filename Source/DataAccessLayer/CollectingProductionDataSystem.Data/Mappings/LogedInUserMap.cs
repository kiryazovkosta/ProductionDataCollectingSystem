﻿/// <summary>
/// Summary description for LogedInUserMap
/// </summary>
namespace CollectingProductionDataSystem.Data.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CollectingProductionDataSystem.Models.Identity;

    class LogedInUserMap:EntityTypeConfiguration<LogedInUser>
    {
        public LogedInUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.TimeStamp)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("ix_LogedInUserMap__TimeStamp", 1)))
                .IsRequired();
            
            this.Property(t => t.LogedUsersCount)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("LogedInUsers");
        }
    }
}
