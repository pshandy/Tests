using System;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{

    public class LogAnalyzer
    {

        private IExtensionManager extensionManager;

        public LogAnalyzer(IExtensionManager extensionManager)
        {
            this.extensionManager = extensionManager;
        }

        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager mrg = extensionManager;
            try
            {
                return mrg.IsValid(fileName);
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
