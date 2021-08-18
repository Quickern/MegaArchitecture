using Pipopolam.MegaArchitecture.Common;

namespace Pipopolam.MegaArchitecture.Mathematics
{
    public interface IIntMember : IMember, IImplementable
    {
        int Value { get; }
    }
}
