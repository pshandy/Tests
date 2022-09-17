using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class WebServiceFactory
    {

        private static IWebService webService;

        public static IWebService Create()
        {
            if (webService != null)
            {
                return (webService);
            }
            return (new WebService());
        }

        public static void SetWebService(IWebService iwb)
        {
            webService = iwb;
        }

    }
}