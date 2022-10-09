using System;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{

    public class LogAnalyzer : ILogAnalyzer
    {

        public event LogAnalyzerAction Analyzed = null;

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
                try
                {
                    //Передать внешней службе сообщение об ошибке
                    IWebService webService = WebServiceFactory.Create();
                    webService.LogError("Слишком короткое имя файла: " + filename);
                }
                catch (Exception e)
                {
                    IEmailService emailService = EmailServiceFactory.Create();
                    //Отправить сообщение по электронной почте
                    emailService.SendEmail("somebody@mail.ru", "Невозможно вызвать веб-сервис", e.Message);
                }
            }

            //Обработка лога
            //...
            RaiseAnalyzedEvent();
        }

        public void RaiseAnalyzedEvent()
        {
            if (Analyzed != null)
            {
                Analyzed();
            }
        }

    }
}
