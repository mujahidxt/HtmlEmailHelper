using System;
using System.Collections.Generic;
using System.Text;

namespace MujahidHtmlEmailHelper
{
    public class SmtpClientOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
