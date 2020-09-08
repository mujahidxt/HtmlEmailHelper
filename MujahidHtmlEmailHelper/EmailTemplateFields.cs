using System.Collections.Generic;

namespace MujahidHtmlEmailHelper
{
    public class EmailTemplateFields : IEmailTemplateFields
    {
        public EmailTemplateFields() { }
        public EmailTemplateFields(string template, Dictionary<string, string> fields, TemplateType templateType = TemplateType.HtmlFile)
        {
            this.Template = template;
            this.TemplateType = templateType;
            this.Fields = fields;
        }
        public string Template { get; set; }
        public TemplateType TemplateType { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        public static IEmailTemplateFields EmailTemplate(string template, Dictionary<string, string> fields,TemplateType templateType=TemplateType.HtmlFile)
        {
            return new EmailTemplateFields(template, fields, templateType);
        }
    }
}
