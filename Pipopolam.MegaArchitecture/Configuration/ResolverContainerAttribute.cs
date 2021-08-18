using System;

namespace Pipopolam.MegaArchitecture.Configuration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ResolverContainerAttribute : Attribute
    {
        public Type Type { get; }

        public ResolverContainerAttribute(Type type)
        {
            Type = type;
        }
    }
}
