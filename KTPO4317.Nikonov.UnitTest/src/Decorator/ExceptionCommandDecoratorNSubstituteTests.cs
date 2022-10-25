using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using KTPO4317.Nikonov.Lib.src.SampleCommands;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.Decorator
{
    class ExceptionCommandDecoratorNSubstituteTests
    {

        [Test]
        public void Execute_WhenCalled_ExecutesDecoratedObjectMethod()
        {
            IView stubViev = Substitute.For<IView>();
            ISampleCommand mockDecoratedCommand = Substitute.For<ISampleCommand>();

            ISampleCommand commandDecorator = new ExceptionIntercepter(mockDecoratedCommand, stubViev);
            commandDecorator.Execute();

            mockDecoratedCommand.Received().Execute();

        }

        [Test]
        public void Execute_CommandThrowsException_PrintsMessage()
        {
            ISampleCommand stubCommand = Substitute.For<ISampleCommand>();
            stubCommand
                .When(x => x.Execute())
                .Do(context => { throw new Exception(); });

            IView mockView = Substitute.For<IView>();

            ISampleCommand commandDecorator = new ExceptionIntercepter(stubCommand, mockView);
            commandDecorator.Execute();
            mockView.Received().Render("Перехвачено исключение!");
        }

    }
}
