using System;
using NUnit.Framework;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {

            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeManager);
            bool result = logAnalyzer.IsValidLogFileName("short.nmd");
            Assert.True(result);

        }

        [Test]
        public void IsValidFileName_NameNotSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeManager);
            bool result = logAnalyzer.IsValidLogFileName("short.nmd");
            Assert.False(result);

        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception();

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeManager);
            bool result = logAnalyzer.IsValidLogFileName("short.nmd");
            Assert.False(result);
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

}
