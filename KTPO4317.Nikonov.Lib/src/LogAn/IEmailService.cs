using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.Nikonov.Lib.src.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string To, string Subject, string Body);
    }
}