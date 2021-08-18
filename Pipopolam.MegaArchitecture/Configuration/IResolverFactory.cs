namespace Pipopolam.MegaArchitecture.Configuration
{
    public interface IResolverFactory
    {
        public IResolver GetResolver<T>();
    }
}
