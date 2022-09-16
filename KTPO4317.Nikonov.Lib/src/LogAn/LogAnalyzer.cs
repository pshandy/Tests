using System;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{

    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager mrg = ExtensionManagerFactory.Create();
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
