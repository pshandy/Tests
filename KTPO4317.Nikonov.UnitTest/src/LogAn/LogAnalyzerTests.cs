using System;
using NUnit.Framework;
using KTPO4317.Nikonov.Lib.src.LogAn;

namespace KTPO4317.Nikonov.UnitTest.src.LogAn
{
    [TestFixture]
    class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("file.txt");
            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("file.NMD");
            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("file.nmd");
            Assert.True(result);
        }

        [TestCase("file.NMD")]
        [TestCase("file.nmd")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));
            StringAssert.Contains("Имя файла должно быть задано.", ex.Message);
        }

    }
}
