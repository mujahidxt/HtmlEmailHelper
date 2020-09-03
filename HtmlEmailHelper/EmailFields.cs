using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlEmailHelper
{
    public class EmailFields
    {
        public EmailFields() { }
        public EmailFields(string subject, string to)
        {
            this.Subject = subject;
            this.To = to;
        }
        public EmailFields(string subject, string to, IEmailTemplateFields emailTemplateFields)
        {
            this.Subject = subject;
            this.To = to;
            this.TemplateFields = emailTemplateFields;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public IEmailTemplateFields TemplateFields { get; set; }
    }
}
