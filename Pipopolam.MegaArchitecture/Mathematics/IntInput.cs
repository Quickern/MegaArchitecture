using System;
using Pipopolam.MegaArchitecture.Configuration;
using Pipopolam.MegaArchitecture.Services;
using Unity;

namespace Pipopolam.MegaArchitecture.Mathematics
{
    public class IntInput : IIntInput
    {
        [Dependency]
        public IReader Reader { get; set; }

        //[Dependency]
        public IResolver Resolver { get; set; }

        public IntInput(IResolver resolver)
        {
            Resolver = resolver;
        }

        public IMember ReadMember()
        {
            string str = Reader.Read();
            if (Int32.TryParse(str, out int result))
                return Resolver.ResolveMember(result);

            throw new ArgumentException("Invalid parameter!");
        }
    }
}
