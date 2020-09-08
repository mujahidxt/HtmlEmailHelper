using System.Collections.Generic;

namespace MujahidHtmlEmailHelper
{
    public interface IEmailTemplateFields
    {
        string Template { get; set; }
        TemplateType TemplateType { get; set; }
        Dictionary<string, string> Fields { get; set; }
    }
}
