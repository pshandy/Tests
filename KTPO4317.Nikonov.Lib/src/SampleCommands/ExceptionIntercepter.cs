using KTPO4317.Nikonov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.SampleCommands
{
    class ExceptionIntercepter : ISampleCommand
    {
        private readonly ISampleCommand sampleCommandDecorator;
        private readonly IView view;
        public ExceptionIntercepter(ISampleCommand sampleCommandDecorator, IView view)
        {
            this.sampleCommandDecorator = sampleCommandDecorator;
            this.view = view;
        }

        public void Execute()
        {
            try
            {
                sampleCommandDecorator.Execute();
            }
            catch
            {
                view.Render("Перехвачено исключение!");
            }
        }
    }
}
