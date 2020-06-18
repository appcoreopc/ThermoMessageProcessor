using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThemoDataModel;

namespace ThemoDataMessageProcessor.DataProcessor
{
    public interface IDataStoreProcesor
    {
        Task<ExecutionState> ProcessAsync(PersonelThermoDataModel source);
    }
}
