using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4317.Nikonov.Lib.src.LogAn;
using KTPO4317.Nikonov.Lib.src.Views;

namespace KTPO4317.Nikonov.Lib.src.WindsorInstallers
{
    public class ViewInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IView>().ImplementedBy<ConsoleView>().LifeStyle.Transient
                );
        }
    }
}
