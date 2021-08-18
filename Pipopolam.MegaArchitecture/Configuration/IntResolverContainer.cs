using System;
using Pipopolam.MegaArchitecture.Mathematics;
using Unity;
using Unity.Resolution;

namespace Pipopolam.MegaArchitecture.Configuration
{
    [ResolverContainer(typeof(int))]
    public class IntResolverContainer : IResolverContainer
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void Register()
        {
            Container.RegisterType<IIntMember, IntMember>();
            Container.RegisterType<IIntResult, IntResult>();
            Container.RegisterType<IIntSummator, IntSummator>();
            Container.RegisterType<IIntInput, IntInput>();
        }

        public Type GetResolver() => typeof(IntResolver);
    }
}
