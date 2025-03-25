using System;
using System.Web;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
        foreach (string cookie in cookies)
        {
            Response.Cookies[cookie].Value = string.Empty;
            Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
        }

        PsychMatch.User.HasSession = false;

        Session.RemoveAll();
        Session.Clear();
        Session.Abandon();

        Response.Redirect("default.aspx?msg=You have been logged out.  Thank You!");

    }
}