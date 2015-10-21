﻿namespace CollectingProductionDataSystem.Models.Productions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MultiShift
    {
        public DateTime TimeStamp { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public string MeasureUnit { get; set; }
        public int UnitConfigId { get; set; }
        public string UnitName { get; set; }
        public UnitsData Shift1 { get; set; }
        public UnitsData Shift2 { get; set; }
        public UnitsData Shift3 { get; set; }
        public double TotalQuantityValue
        { 
            get
            {
                double sum = 0;
                sum += GetValue(Shift1);
                sum += GetValue(Shift2);
                sum += GetValue(Shift3);
                return sum;
            }
        }

        private double GetValue(UnitsData dataParam)
        {
            if (dataParam != null)
            {
                return dataParam.RealValue;
            }

            return 0;
        }
    }

    public class MultiShiftComparer : IEqualityComparer<MultiShift>
    {
        /// <summary>
        /// Equalses the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public bool Equals(MultiShift x, MultiShift y)
        {
            return this.GetHashCode(x) == this.GetHashCode(y);
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public int GetHashCode(MultiShift obj)
        {
            return (new { obj.UnitConfigId }).GetHashCode();
        }
    }
}