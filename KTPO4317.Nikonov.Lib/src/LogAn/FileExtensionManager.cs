using System;
using System.Configuration;
using System.Collections.Specialized;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            string extension = ConfigurationManager.AppSettings.Get("extension");
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Имя файла должно быть задано.");
            }
            if (fileName.ToUpper().EndsWith(extension))
            {
                return (true);
            }
            return (false);
        }
    }
}