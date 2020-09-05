using System.Collections.Generic;

namespace MujahidHtmlEmailHelper
{
    public class EmailTemplateFields : IEmailTemplateFields
    {
        public EmailTemplateFields() { }
        public EmailTemplateFields(string template, Dictionary<string, string> fields)
        {
            this.Template = template;
            this.Fields = fields;
        }
        public string Template { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        public IEmailTemplateFields EmailTemplate(string template, Dictionary<string, string> fields)
        {
            return new EmailTemplateFields(template, fields);
        }
    }
}
