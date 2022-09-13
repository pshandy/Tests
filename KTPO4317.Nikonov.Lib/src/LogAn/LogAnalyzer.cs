using System;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Имя файла должно быть задано.");
            }
            if (fileName.ToUpper().EndsWith(".NMD"))
            {
                return (true);
            }
            return (false);
        }
    }
}
