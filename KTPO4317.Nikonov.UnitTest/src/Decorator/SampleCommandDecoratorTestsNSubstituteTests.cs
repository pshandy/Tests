using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using KTPO4317.Nikonov.Lib.src.SampleCommands;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.Decorator
{
    class SampleCommandDecoratorTestsNSubstituteTests
    {
        [Test]
        public void Execute_WhenCalled_ExecutesDecoratedObjectMethod()
        {
            IView stubViev = Substitute.For<IView>();
            ISampleCommand mockDecoratedCommand = Substitute.For<ISampleCommand>();

            ISampleCommand commandDecorator = new SampleCommandDecorator(mockDecoratedCommand, stubViev);
            commandDecorator.Execute();

            mockDecoratedCommand.Received().Execute();

        }

        [Test]
        public void Execute_WhenCalled_PrintsMessage()
        {
            ISampleCommand stubCommand = Substitute.For<ISampleCommand>();
            IView mockView = Substitute.For<IView>();

            ISampleCommand commandDecorator = new SampleCommandDecorator(stubCommand, mockView);
            commandDecorator.Execute();
            mockView.Received().Render("Начало: KTPO4317.Nikonov.Lib.src.SampleCommands.SampleCommandDecorator");
            mockView.Received().Render("Конец: KTPO4317.Nikonov.Lib.src.SampleCommands.SampleCommandDecorator");
        }

    }
}
