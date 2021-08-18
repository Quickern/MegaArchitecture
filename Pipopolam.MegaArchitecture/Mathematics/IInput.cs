using Pipopolam.MegaArchitecture.Common;

namespace Pipopolam.MegaArchitecture.Mathematics
{
    public interface IInput : IImplementable
    {
        public IMember ReadMember();
    }
}
