- ## Introduction
    This package is usefull for sending HTML email by reading and replacing content from HTML file.
- ## How to start?
    Follow below these steps to send your first email using `Html File`.
    You can also send using `Html String`, but we're focussing on `Html File` methode here.

    ### 1 Install : `MujahidHtmlEmailHelper` from NuGet
    Install package by running command in vs package manager console:
    ```Install-Package MujahidHtmlEmailHelper -Version 1.0.5```
    OR
    By searching in _NuGet Package Manager_ in VS. 
    
    ### 2 Create Html Template File
    Here we're creating `Welcome.html` for example.
    And adding tag `[CustomerName]` which will be replaced leter.
    
    ```html
    <!DOCTYPE html>
    <html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="utf-8" />
        <title></title>
    </head>
    <body>
        <h1>Welcome [CustomerName]!</h1>
    </body>
    </html>
    ```
    
    ### 3 Implement class `EmailTemplateFields`
    - Create class in your project with any name, I'm using `EmailTemplates`.
    - Implement class comming from namespace `MujahidHtmlEmailHelper`
    - And Create method for template file, I'm using `Welcome` for `Welcome.html`
    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MujahidHtmlEmailHelper;

    namespace EmailHelperByMujahid
    {
        public class EmailTemplates : EmailTemplateFields
        {
        //Method for Welcome.html template
        public static IEmailTemplateFields Welcome(string customerName)
            {
                var fields = new Dictionary<string, string>();
                fields.Add("[CustomerName]", customerName); //[CustomerName] will be replaced with customerName in Welcome.html document.
                return EmailTemplate("Welcome.html", fields); //EmailTemplate method comming from EmailTemplateFields.
            }
        }
    }
    ```
    
    ### 4 Implementation
    Here we're sending email using `SendGrid` you can also use `SmtpClient`.
    
    ```csharp
    using System;
    using MujahidHtmlEmailHelper;

    namespace EmailHelperByMujahid
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Initialize email fields
                var emailFields = new EmailFields(
                    subject: "your subject",
                    to: "mujahidatwork@gmail.com",
                    emailTemplateFields : EmailTemplates.Welcome("Muhammad Mujahid")
                );

                //Sending email using SendGrid
                var response = emailFields.SendEmail(new SendGridOptions()
                {
                    ApiKey="YOUR SEND GRID API KEY",
                    Email= "FROM EMAIL",
                    Name= "FROM NAME"
                });

            }
        }
    }
    ```
    
    ### 5 Result
    ![result image](https://lh3.googleusercontent.com/pw/ACtC-3e1wLsQwaHAJkhsO5a5G9oQRT2lwHRzt6UaZc914c7AK5acvuBEt54p4Iq2WUV8RvGzNY3VIEsdF3DIz519FWaW6iDiuzN4wZdmt-IN3FaWyFU3R3M7j-ka3C4ovGvrnK5uZs2e7IPMpVWYYny2hLBX=w1036-h342-no?authuser=0)
