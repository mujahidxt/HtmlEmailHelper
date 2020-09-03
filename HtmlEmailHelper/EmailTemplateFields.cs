using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlEmailHelper
{
    public class EmailTemplateFields : IEmailTemplateFields
    {
        public string Template { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        EmailTemplateFields(string template, Dictionary<string, string> fields)
        {
            this.Fields = fields;
            this.Template = template;
        }

        public static IEmailTemplateFields ExampleTemplate(string name)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("Name", name);
            return new EmailTemplateFields(@"EmailTemplates\TemplateName.html", fields);
        }
    }

    public interface IEmailTemplateFields
    {
        string Template { get; set; }
        Dictionary<string, string> Fields { get; set; }
    }
}
