
namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (fileName.EndsWith(".NMD"))
            {
                return (true);
            }
            return (false);
        }
    }
}
