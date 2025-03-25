using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Ganss.XSS;


/// <summary>
/// Summary description for StringExtension
/// </summary>
public static class StringExtension
{
    public static string SanitizeUnTrustedString(this string value)
    {
        var sanitizer = new HtmlSanitizer();
        return sanitizer.Sanitize(value);
    }
}