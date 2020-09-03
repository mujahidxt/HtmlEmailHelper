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
        public string To { get; set; }
        public string Subject { get; set; }
        public EmailTemplate Template { get; set; }
        public EmailTemplateFields TemplateFields { get; set; }
    }
    public class EmailTemplateFields
    {
        public string Name { get; set; } = string.Empty;

        public static EmailTemplateFields ExampleTemplate(string name)
        {
            return new EmailTemplateFields()
            {
                Name = name
            };
        }
    }
    public class SendGridOptions
    {
        public string ApiKey { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public enum EmailTemplate
    {
        ExampleTemplate
    }
    public static class EmailHelper
    {
        public static string TemplateString(EmailTemplate template, EmailTemplateFields fields)
        {
            return System.IO.File.ReadAllText(@$"EmailTemplates\{template}.html")
                .Replace($"[{nameof(fields.Name)}]", fields.Name);
        }
        private static Response Send(EmailFields emailFields, SendGridOptions sendGridOptions)
        {
            var client = new SendGridClient(sendGridOptions.ApiKey);
            var msg = MailHelper.CreateSingleEmail(
                new EmailAddress(sendGridOptions.Email, sendGridOptions.Name),
                new EmailAddress(emailFields.To, string.Empty),
                emailFields.Subject,
                string.Empty,
                TemplateString(emailFields.Template, emailFields.TemplateFields)
                );
            return client.SendEmailAsync(msg).Result;
        }

        public static Response SendEmail(this EmailFields emailFields, SendGridOptions sendGridOptions)
        {
            return Send(emailFields, sendGridOptions);
        }
    }
}
