using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        bool IsValidLogFileName(string fileName);
        void Analyze(string filename);
        void RaiseAnalyzedEvent();

        event LogAnalyzerAction Analyzed;
    }
}
