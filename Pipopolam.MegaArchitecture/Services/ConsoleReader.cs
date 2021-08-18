using System;

namespace Pipopolam.MegaArchitecture.Services
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
