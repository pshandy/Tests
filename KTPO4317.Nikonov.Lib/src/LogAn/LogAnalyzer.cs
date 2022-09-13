
namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (fileName.EndsWith(".NMD"))
            {
                return (false);
            }
            return (true);
        }
    }
}
