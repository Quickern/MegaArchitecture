using Pipopolam.MegaArchitecture.Common;
using Pipopolam.MegaArchitecture.Services;
using Unity;

namespace Pipopolam.MegaArchitecture.Configuration
{
    public partial class Registrator : IRegistrator, IImplementable
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void Register()
        {
            Container.RegisterSingleton<ILogger, ConsoleLogger>();
            Container.RegisterSingleton<IReader, ConsoleReader>();
            Container.RegisterSingleton<IResolverFactory, ResolverFactory>();

            RegisterResolvers();
        }

        private partial void RegisterResolvers();
    }
}
