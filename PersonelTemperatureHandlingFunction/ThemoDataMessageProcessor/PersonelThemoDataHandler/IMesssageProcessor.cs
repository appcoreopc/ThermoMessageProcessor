using Newtonsoft.Json;

namespace ThemoDataMessageProcessor.PersonelThemoDataHandler
{
    public interface IMesssageThermoProcessor
    {
        T ProcessMessage<T>(string message);
    }
}