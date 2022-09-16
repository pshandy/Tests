using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public static class ExtensionManagerFactory
    {
        private static IExtensionManager customManager;

        public static IExtensionManager Create()
        {
            if (customManager != null)
            {
                return (customManager);
            }
            return (new FileExtensionManager());
        }

        public static void setExtensionManagaer(IExtensionManager mgr)
        {
            customManager = mgr;
        }

    }

}
