﻿namespace CollectingProductionDataSystem.Application.Contracts
{
    using CollectingProductionDataSystem.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPrimaryDataService
    {
        IEfStatus ReadAndSaveUnitsDataForShift();
    }
}
