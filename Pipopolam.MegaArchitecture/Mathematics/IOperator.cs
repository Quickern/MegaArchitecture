using Pipopolam.MegaArchitecture.Common;

namespace Pipopolam.MegaArchitecture.Mathematics
{
    public interface IOperator : IImplementable
    {
        IMember Left { get; set; }
        IMember Right { get; set; }

        IResult GetResult();
    }
}
