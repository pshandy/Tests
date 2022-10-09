using KTPO4317.Nikonov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.Views
{
    class ConsoleView : IView
    {
        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
