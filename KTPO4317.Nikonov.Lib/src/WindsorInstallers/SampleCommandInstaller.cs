using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4317.Nikonov.Lib.src.SampleCommands;

namespace KTPO4317.Nikonov.Lib.src.WindsorInstallers
{
    public class SampleCommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<FirstCommand>().LifeStyle.Singleton
                );
        }
    }
}
