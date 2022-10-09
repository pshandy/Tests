using System;
using NSubstitute;
using NUnit.Framework;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.LogAn
{
    class PresenterTests
    {
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender()
        {
            FakeLogAnalyzer stubLogAnalyzer = new FakeLogAnalyzer();
            IView mockView = Substitute.For<IView>();
            Presenter presenter = new Presenter(stubLogAnalyzer, mockView);

            stubLogAnalyzer.CallRaiseAnalyzedEvent();

            mockView.Received().Render("Обработка завершена");

        }
    }

    class FakeLogAnalyzer : LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();
        }
    }



}
