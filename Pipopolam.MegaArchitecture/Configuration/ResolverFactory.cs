using System;
using Unity;

namespace Pipopolam.MegaArchitecture.Configuration
{
    public class ResolverFactory : IResolverFactory
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public IResolver GetResolver<T>()
        {
            return Container.Resolve<IResolver>(typeof(T).FullName);
        }
    }
}
