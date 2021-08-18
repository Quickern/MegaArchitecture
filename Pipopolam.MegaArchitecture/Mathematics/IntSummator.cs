using System;
using Pipopolam.MegaArchitecture.Configuration;
using Unity;

namespace Pipopolam.MegaArchitecture.Mathematics
{
    public class IntSummator : IIntSummator
    {
        [Dependency]
        public IResolver Resolver { get; set; }

        [Dependency]
        public IMember Left { get; set; }

        [Dependency]
        public IMember Right { get; set; }

        public IResult GetResult()
        {
            Validate();

            return Resolver.ResolveResult(((IIntMember)Left).Value + ((IIntMember)Right).Value);
        }

        public void Validate()
        {
            if (Left is not IIntMember)
                throw new ArgumentException("Left operand is of invalid type!");

            if (Right is not IIntMember)
                throw new ArgumentException("Left operand is of invalid type!");
        }
    }
}
