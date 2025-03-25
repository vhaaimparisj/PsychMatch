using System;
using System.Web;

public partial class EntryComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PsychMatch.User.HasSession)
        {
            string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Value = string.Empty;
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("Default.aspx");
        }
    }
}