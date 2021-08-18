using Pipopolam.MegaArchitecture.Common;

namespace Pipopolam.MegaArchitecture.Services
{
    public interface ILogger : IImplementable
    {
        void Log(ILoggable obj);
    }
}
