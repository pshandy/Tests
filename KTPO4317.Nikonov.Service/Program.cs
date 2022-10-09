using System;
using KTPO4317.Nikonov.Lib.src.Common;
using KTPO4317.Nikonov.Lib.src.LogAn;
using KTPO4317.Nikonov.Lib.src.SampleCommands;
using KTPO4317.Nikonov.Lib.src.WindsorInstallers;

namespace KTPO4317.Nikonov.Service
{
    class Program
    {
        static void Main(string[] args)
        {

            CastleFactory.container.Install(
                new SampleCommandInstaller(),
                new ViewInstaller()
                );

            for (int i = 0; i < 3; i++)
            {
                ISampleCommand sampleCommand = CastleFactory.container.Resolve<ISampleCommand>();
                sampleCommand.Execute();
            }

        }
    }
}