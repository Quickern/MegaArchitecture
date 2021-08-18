using System;
using Pipopolam.MegaArchitecture.Common;
using Unity.Resolution;

namespace Pipopolam.MegaArchitecture.Configuration
{
    public interface IResolverContainer : IImplementable
    {
        void Register();
        Type GetResolver();
    }
}
