using Pipopolam.MegaArchitecture.Configuration;
using Pipopolam.MegaArchitecture.Mathematics;
using Pipopolam.MegaArchitecture.Services;
using Unity;
using Unity.Resolution;

namespace Pipopolam.MegaArchitecture
{
    class Program
    {
        public static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterSingleton<IRegistrator, Registrator>();
            container.Resolve<IRegistrator>().Register();

            IResolver resolver = container.Resolve<IResolverFactory>().GetResolver<int>();
            IInput input = resolver.ResolveInput();

            ISummator summator = resolver.ResolveSummator(input.ReadMember(), input.ReadMember());

            summator.GetResult().Log();
        }
    }
}
