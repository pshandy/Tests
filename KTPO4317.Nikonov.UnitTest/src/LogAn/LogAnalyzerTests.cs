using System;
using NUnit.Framework;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.setExtensionManagaer(null);
            WebServiceFactory.SetWebService(null);
            EmailServiceFactory.setEmailService(null);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {

            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            ExtensionManagerFactory.setExtensionManagaer(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("short.nmd");
            Assert.True(result);

        }

        [Test]
        public void IsValidFileName_NameNotSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            ExtensionManagerFactory.setExtensionManagaer(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("short.nmd");
            Assert.False(result);

        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception();

            ExtensionManagerFactory.setExtensionManagaer(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("short.nmd");
            Assert.False(result);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetWebService(mockWebService);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.nmd";
            log.Analyze(tooShortFileName);
            StringAssert.Contains("Слишком короткое имя файла: " + tooShortFileName, mockWebService.lastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.SetWebService(stubWebService);
            stubWebService.WillThrow = new Exception("это подделка");

            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.setEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.nmd";
            log.Analyze(tooShortFileName);

            StringAssert.Contains("somebody@mail.ru", mockEmail.To);
            StringAssert.Contains("это подделка", mockEmail.Body);
            StringAssert.Contains("Невозможно вызвать веб-сервис", mockEmail.Subject);
        }



    }

    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            return WillBeValid;
        }
    }

    internal class FakeWebService : IWebService
    {

        public String lastError;
        public Exception WillThrow;

        public void LogError(string message)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            lastError = message;
        }
    }

    internal class FakeEmailService : IEmailService
    {

        public String To;
        public String Subject;
        public String Body;
        public void SendEmail(string To, string Subject, string Body)
        {
            this.To = To;
            this.Subject = Subject;
            this.Body = Body;
        }
    }

}
