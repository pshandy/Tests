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

        public void Analyze(string filename)
        {
            if (filename.Length < 8)
            {
                IWebService webService = WebServiceFactory.Create();
                webService.LogError("Слишком короткое имя файла: " + filename);
            }
        }

    }
}
