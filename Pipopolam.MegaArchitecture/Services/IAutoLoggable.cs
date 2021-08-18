using Pipopolam.MegaArchitecture.Common;

namespace Pipopolam.MegaArchitecture.Services
{
    public interface IAutoLoggable : ILoggable, IImplementable
    {
        void Log();
    }
}
