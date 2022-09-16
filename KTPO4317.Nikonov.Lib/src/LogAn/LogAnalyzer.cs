using System;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{

    public class LogAnalyzer
    { 
        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager mrg = new FileExtensionManager();
            return (mrg.isValid(fileName));
        }
    }
}
