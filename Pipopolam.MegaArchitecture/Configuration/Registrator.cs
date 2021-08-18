using System;
using Pipopolam.MegaArchitecture.Common;
using Pipopolam.MegaArchitecture.Services;
using Unity;
using Unity.Resolution;

namespace Pipopolam.MegaArchitecture.Configuration
{
    public class Registrator : IRegistrator, IImplementable
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void Register()
        {
            Container.RegisterSingleton<ILogger, ConsoleLogger>();
            Container.RegisterSingleton<IReader, ConsoleReader>();
            Container.RegisterSingleton<IResolverFactory, ResolverFactory>();

            foreach (Type type in typeof(IResolverContainer).Assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(ResolverContainerAttribute), false) is ResolverContainerAttribute[] attributes)
                {
                    if (attributes.Length < 1)
                        continue;

                    if (!typeof(IResolverContainer).IsAssignableFrom(type))
                        continue;

                    IResolverContainer resolverContainer = (IResolverContainer)Container.Resolve(type);

                    foreach (ResolverContainerAttribute attribute in attributes)
                    {
                        resolverContainer.Register();
                        Container.RegisterSingleton(typeof(IResolver), resolverContainer.GetResolver(), attribute.Type.FullName);
                    }
                }
            }
        }
    }
}
