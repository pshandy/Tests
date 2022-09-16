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

            LogAnalyzer log = new LogAnalyzer(fakeManager);

            bool result = log.IsValidLogFileName("short.nmd");

            Assert.True(result);

        }

        [Test]
        public void IsValidFileName_NameNotSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillBeValid = false;

            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeExtensionManager);
            bool result = logAnalyzer.IsValidLogFileName("short.xts");
            Assert.False(result);

        }

        internal class FakeExtensionManager : IExtensionManager
        {
            public bool WillBeValid = false;

            public bool IsValid(string fileName)
            {
                return WillBeValid;
            }
        }
    }
}
