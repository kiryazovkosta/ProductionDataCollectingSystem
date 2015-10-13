﻿/// <summary>
/// Summary description for ShiftList
/// </summary>
namespace CollectingProductionDataSystem.Models.Nomenclatures
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CollectingProductionDataSystem.Infrastructure.Mapping;
    using CollectingProductionDataSystem.Models.Abstract;
    using CollectingProductionDataSystem.Models.Contracts;

    public class Shift : DeletableEntity, IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        public string Name { get; set; }

        public long BeginTicks { get; set; }
        public long ReadOffsetTicks { get; set; }
        public long ReadPollTimeSlotTicks { get; set; }

        [NotMapped]
        public TimeSpan BeginTime
        {
            get
            {
                return new TimeSpan(this.BeginTicks);
            }
            set
            {
                this.BeginTicks = value.Ticks;
            }
        }

        [NotMapped]
        public TimeSpan ReadOffset
        {
            get
            {
                return new TimeSpan(this.ReadOffsetTicks);
            }
            set
            {
                this.ReadOffsetTicks = value.Ticks;
            }
        }

        [NotMapped]
        public TimeSpan ReadPollTimeSlot
        {
            get
            {
                return new TimeSpan(this.ReadPollTimeSlotTicks);
            }
            set
            {
                this.ReadPollTimeSlotTicks = value.Ticks;
            }
        }

    }
}
