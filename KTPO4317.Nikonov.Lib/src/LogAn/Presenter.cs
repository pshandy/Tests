using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class Presenter
    {

        private LogAnalyzer LogAnalyzer;
        private IView View;

        public Presenter(LogAnalyzer LogAnalyzer, IView View)
        {
            this.LogAnalyzer = LogAnalyzer;
            this.View = View;
            LogAnalyzer.Analyzed += OnLogAnalyzer;
        }

        private void OnLogAnalyzer()
        {
            View.Render("Обработка завершена");
        }

    }
}
