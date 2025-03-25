using System;

/// <summary>
/// Summary description for HelperFunctions
/// </summary>
public static class HelperFunctions
{

    public static string Santize(this string value)
    {
        return HtmlUtility.SanitizeHtml(value);
    }

    public static bool IsDate(Object obj)
    {
        string strDate = obj.ToString();
        try
        {
            DateTime dt = DateTime.Parse(strDate);
            if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                return true;
            return false;
        }
        catch
        {
            return false;
        }
    }

    public static void SendEmail(string Recipient, string Sender, string Subject, string Message)
    {
        var msg = new System.Net.Mail.MailMessage();

        string[] EmailArray = Recipient.Split(';');
        foreach (string email in EmailArray)
        {
            msg.To.Add(new System.Net.Mail.MailAddress(email));
        }

        msg.From = new System.Net.Mail.MailAddress(Sender);
        msg.Priority = System.Net.Mail.MailPriority.High;
        msg.Subject = Subject;
        msg.Body = Message;
        msg.IsBodyHtml = true;
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Send(msg);
    }
}
