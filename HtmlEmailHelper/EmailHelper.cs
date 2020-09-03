using SendGrid;
using SendGrid.Helpers.Mail;
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
        public EmailFields(string subject, string to, EmailTemplateFields emailTemplateFields)
        {
            this.Subject = subject;
            this.To = to;
            this.TemplateFields = emailTemplateFields;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public EmailTemplateFields TemplateFields { get; set; }
    }
    public class EmailTemplateFields
    {
        public string Template { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        EmailTemplateFields(string template, Dictionary<string, string> fields)
        {
            this.Fields = fields;
            this.Template = template;
        }

        public static EmailTemplateFields ExampleTemplate(string name)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("Name", name);
            return new EmailTemplateFields(@"EmailTemplates\TemplateName.html", fields);
        }
    }
    public class SendGridOptions
    {
        public string ApiKey { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static class EmailHelper
    {
        public static string TemplateString(EmailTemplateFields fields)
        {
            string htmlDocument = System.IO.File.ReadAllText(fields.Template);
            foreach (var field in fields.Fields)
            {
                htmlDocument.Replace($"[{field.Key}]", field.Value);
            }
            return htmlDocument;

        }
        private static Response Send(EmailFields emailFields, SendGridOptions sendGridOptions)
        {
            var client = new SendGridClient(sendGridOptions.ApiKey);
            var msg = MailHelper.CreateSingleEmail(
                new EmailAddress(sendGridOptions.Email, sendGridOptions.Name),
                new EmailAddress(emailFields.To, string.Empty),
                emailFields.Subject,
                string.Empty,
                TemplateString(emailFields.TemplateFields)
                );
            return client.SendEmailAsync(msg).Result;
        }

        public static Response SendEmail(this EmailFields emailFields, SendGridOptions sendGridOptions)
        {
            return Send(emailFields, sendGridOptions);
        }
    }
}
