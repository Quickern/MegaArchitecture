using Pipopolam.MegaArchitecture.Common;
using Pipopolam.MegaArchitecture.Mathematics;

namespace Pipopolam.MegaArchitecture.Configuration
{
    public interface IResolver : IImplementable
    {
        IMember ResolveMember(object value);
        IResult ResolveResult(object result);
        ISummator ResolveSummator(IMember left, IMember right);
        IInput ResolveInput();
    }
}
