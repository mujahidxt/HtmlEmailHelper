using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace MujahidHtmlEmailHelper
{
    public static class EmailHelper
    {
        public static string TemplateString(this IEmailTemplateFields fields)
        {
            string htmlString = fields.TemplateType == TemplateType.HtmlString ? fields.Template : System.IO.File.ReadAllText(fields.Template);
            if (fields.Fields != null)
            {
                foreach (var field in fields.Fields)
                {
                    htmlString = htmlString.Replace(field.Key, field.Value);
                }
            }
            return htmlString;

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
        public static void SendEmail(this EmailFields emailFields, SmtpClientOptions smtpClientOptions)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(smtpClientOptions.Email, smtpClientOptions.Name);
            message.To.Add(new MailAddress(emailFields.To));
            message.Subject = emailFields.Subject;
            message.IsBodyHtml = true;
            message.Body = emailFields.TemplateFields.TemplateString();
            smtp.Port = smtpClientOptions.Port;
            smtp.Host = smtpClientOptions.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(smtpClientOptions.Email, smtpClientOptions.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

    }
}
