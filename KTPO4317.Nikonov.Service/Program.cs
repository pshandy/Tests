using System;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();
            Console.WriteLine("Valid:");
            Console.WriteLine(logAnalyzer.IsValidLogFileName("valid.nmd"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("valid.NMD"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("valid.nMd"));
            Console.WriteLine("InValid:");
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid."));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid.txt"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid"));
            Console.WriteLine(logAnalyzer.IsValidLogFileName("invalid.?/!?"));
        }
    }
}