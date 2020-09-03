using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace MujahidHtmlEmailHelper
{
    public static class EmailHelper
    {
        public static string TemplateString(this IEmailTemplateFields fields)
        {
            string htmlDocument = System.IO.File.ReadAllText(fields.Template);
            foreach (var field in fields.Fields)
            {
                htmlDocument=htmlDocument.Replace($"[{field.Key}]", field.Value);
            }
            return htmlDocument;

        }
        public static Response SendEmail(this EmailFields emailFields, SendGridOptions sendGridOptions)
        {
            var client = new SendGridClient(sendGridOptions.ApiKey);
            var msg = MailHelper.CreateSingleEmail(
                new EmailAddress(sendGridOptions.Email, sendGridOptions.Name),
                new EmailAddress(emailFields.To, string.Empty),
                emailFields.Subject,
                string.Empty,
                emailFields.TemplateFields.TemplateString()
                );
            return client.SendEmailAsync(msg).Result;
        }
    }
}
