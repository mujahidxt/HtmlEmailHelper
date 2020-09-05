using System.Collections.Generic;

namespace MujahidHtmlEmailHelper
{
    public interface IEmailTemplateFields
    {
        string Template { get; set; }
        Dictionary<string, string> Fields { get; set; }
        IEmailTemplateFields EmailTemplate(string template, Dictionary<string, string> fields);
    }
}
