using LoableTech;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            FlagParser.Parse(args);
            Console.WriteLine(FlagParser.StringFlag("stringtest", "none", false));
            Console.WriteLine(FlagParser.DecimalFlag("dectest", 0.45M, false));
        }
    }
}
