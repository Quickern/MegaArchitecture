using Pipopolam.MegaArchitecture.Mathematics;
using Unity;
using Unity.Resolution;

namespace Pipopolam.MegaArchitecture.Configuration
{
    public class IntResolver : IResolver
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public IInput ResolveInput()
        {
            return Container.Resolve<IIntInput>(new DependencyOverride<IResolver>(this));
        }

        public IMember ResolveMember(object value)
        {
            return Container.Resolve<IIntMember>(new PropertyOverride("Value", value), new DependencyOverride<IResolver>(this));
        }

        public IResult ResolveResult(object result)
        {
            return Container.Resolve<IIntResult>(new PropertyOverride("Value", result), new DependencyOverride<IResolver>(this));
        }

        public ISummator ResolveSummator(IMember left, IMember right)
        {
            return Container.Resolve<IIntSummator>(new PropertyOverride("Left", left),
                new PropertyOverride("Right", right),
                new DependencyOverride<IResolver>(this));
        }
    }
}
