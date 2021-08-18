using Pipopolam.MegaArchitecture.Services;
using Unity;

namespace Pipopolam.MegaArchitecture.Mathematics
{
    public class IntMember : IIntMember
    {
        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public int Value { get; set; }

        public void Log()
        {
            Logger.Log(this);
        }

        public string ToLog()
        {
            return Value.ToString();
        }
    }
}
