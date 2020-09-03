using System;

namespace HtmlEmailHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Veriables
            string email = string.Empty;
            string name = string.Empty;
            SendGridOptions sendGrid = new SendGridOptions()
            {
                ApiKey = "YOUR SENDGRID API KEY",
                Email = "YOUR FROM EMAIL",
                Name = "YOUR COMPANY OR PERSONAL NAME"
            };

            //Read Email
            do
            {
                Console.WriteLine("Enter Your Email:");
                email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(email));

            //Read Name
            do
            {
                Console.WriteLine("Enter Your Name:");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            //Initialize template email
            var emailFields = new EmailFields("email subject", email);
            emailFields.Template = EmailTemplate.ExampleTemplate;
            emailFields.TemplateFields = EmailTemplateFields.ExampleTemplate(name);

            try
            {
                //Send Email
                var response= emailFields.SendEmail(sendGrid);
                Console.WriteLine("Response:");
                Console.WriteLine(response.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                //Catch Error
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
