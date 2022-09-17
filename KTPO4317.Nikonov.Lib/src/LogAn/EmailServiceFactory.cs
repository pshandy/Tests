using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public class EmailServiceFactory
    {

        private static IEmailService emailService;

        public static IEmailService Create()
        {
            if (emailService != null)
            {
                return (emailService);
            }
            throw new NotImplementedException();
        }

        public static void setEmailService(IEmailService mgr)
        {
            emailService = mgr;
        }

    }
}