using System.Threading.Tasks;

namespace ThemoDataMessageProcessor.PersonelThemoDataHandler
{
    public interface IMesssageThermoProcessor
    {
        Task ProcessMessage(string message);
    }
}