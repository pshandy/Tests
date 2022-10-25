using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using KTPO4317.Nikonov.Lib.src.SampleCommands;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.Command
{
    class FirstCommandNSubstituteTests
    {
        [Test]
        public void Execute_WhenCalled_PrintsNumberOfCalls()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand command = new FirstCommand(mockView);
            command.Execute();
            mockView.Received().Render("KTPO4317.Nikonov.Lib.src.SampleCommands.FirstCommand\n iExecute = 1");
            command.Execute();
            mockView.Received().Render("KTPO4317.Nikonov.Lib.src.SampleCommands.FirstCommand\n iExecute = 2");
        }
    }
}
