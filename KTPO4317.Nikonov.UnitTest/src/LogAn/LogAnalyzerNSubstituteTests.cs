using System;
using NUnit.Framework;
using NSubstitute;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.LogAn
{
    class LogAnalyzerNSubstituteTests
    {

        public void AfterEachTest()
        {
            ExtensionManagerFactory.setExtensionManagaer(null);
        }

        [Test]
        public void IsValidFileName_NameNotSupportedExtension_ReturnsFalse()
        {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("t.nmd").Returns(false);

            ExtensionManagerFactory.setExtensionManagaer(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("t.nmd");
            Assert.False(result);

        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {

            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("valid.nmd").Returns(true);

            ExtensionManagerFactory.setExtensionManagaer(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("valid.nmd");
            Assert.True(result);

        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager
                .When(x => x.IsValid("file.nmd"))
                .Do(context => { throw new Exception(); });

            ExtensionManagerFactory.setExtensionManagaer(fakeExtensionManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("file.nmd");
            Assert.False(result);
        }

    }
}
