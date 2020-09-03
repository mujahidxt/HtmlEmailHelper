using System;
using System.Collections.Generic;
using System.Text;

namespace MujahidHtmlEmailHelper
{
    public interface IEmailTemplateFields
    {
        string Template { get; set; }
        Dictionary<string, string> Fields { get; set; }
    }
}
