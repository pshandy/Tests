

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (fileName.ToUpper().EndsWith(".NMD"))
            {
                return (true);
            }
            return (false);
        }
    }
}
