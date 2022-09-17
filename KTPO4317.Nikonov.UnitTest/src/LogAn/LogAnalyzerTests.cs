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

        public void LogError(string message)
        {
            lastError = message;
        }
    }

}
