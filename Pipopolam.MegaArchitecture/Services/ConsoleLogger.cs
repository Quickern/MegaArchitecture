using System;

namespace Pipopolam.MegaArchitecture.Services
{
    public class ConsoleLogger : ILogger
    {
        public void Log(ILoggable obj)
        {
            Console.WriteLine($"{obj?.ToLog() ?? "[null]"}");
        }
    }
}
