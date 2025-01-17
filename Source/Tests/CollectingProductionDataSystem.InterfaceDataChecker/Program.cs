﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectingProductionDataSystem.Data;
using CollectingProductionDataSystem.Data.Concrete;
using CollectingProductionDataSystem.Data.Contracts;
using CollectingProductionDataSystem.Infrastructure.Contracts;
using CollectingProductionDataSystem.Infrastructure.Log;
using CollectingProductionDataSystem.Models.Productions;

namespace CollectingProductionDataSystem.InterfaceDataChecker
{
    public static class Program
    {
        public static void Main()
        {
            var targetDay = new DateTime(2016, 3, 18);
            var testContext = new CollectingDataSystemDbContext(new AuditablePersister(), new Logger(), "Dev");
            var productiveContext = new CollectingDataSystemDbContext(new AuditablePersister(), new Logger(), "Productive");
            var testData = new ProductionData(testContext);
            var productiveData = new ProductionData(productiveContext);
            var resultList = new List<string>();
            var productiveUnits = productiveData.UnitsData.All().Where(x => x.RecordTimestamp == targetDay).ToDictionary(x => new { x.RecordTimestamp, x.ShiftId, x.UnitConfigId });
            var testUnits = testData.UnitsData.All().Where(x => x.RecordTimestamp == targetDay).ToDictionary(x => new { x.RecordTimestamp, x.ShiftId, x.UnitConfigId });
            for (int i = 1; i < 4; i++)
            {
                var productiveUnitsCnt = productiveUnits.Where(x => x.Key.ShiftId == i).Count();
                var testUnitsCnt = testUnits.Where(x => x.Key.ShiftId == i).Count();
                Console.WriteLine("\n\nShift {0}", i);
                Console.WriteLine("Productive data count: {0}", productiveUnitsCnt);
                Console.WriteLine("Testing data count: {0}", testUnitsCnt);
                Console.WriteLine("Delta {0}", productiveUnitsCnt - testUnitsCnt);
            }
            int ix = 0;
            foreach (var item in testUnits)
            {
                if (((item.Value.Value ?? 0M) != (productiveUnits[item.Key].Value ?? 0M)) || (item.Value.Confidence != productiveUnits[item.Key].Confidence))
                {
                    resultList.Add(string.Format("Test | {0}", item.Value.Stringify()));
                    resultList.Add(string.Format("Prod | {0}", productiveUnits[item.Key].Stringify()));
                    resultList.Add("");
                    ix++;
                }
            }
            Console.WriteLine("difference count: {0}", ix);
            resultList.Add(string.Format("difference count: {0}", ix));
            var encoding = Encoding.GetEncoding("windows-1251");
            TextWriter tw = new StreamWriter("../../../SavedList.txt", false, encoding);
            foreach (String s in resultList)
                tw.WriteLine(s);
            tw.Close();
            ////Console.WriteLine(new DateTime(2016,1,1,22,54,05) + new TimeSpan(0,35,54));
            //GetNextTime();
        }
 
        /// <summary>
        /// Gets the next time.
        /// </summary>
        private static void GetNextTime()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
