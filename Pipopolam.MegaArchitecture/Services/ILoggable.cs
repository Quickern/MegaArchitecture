using Pipopolam.MegaArchitecture.Common;

namespace Pipopolam.MegaArchitecture.Services
{
    public interface ILoggable : IImplementable
    {
        string ToLog();
    }
}
