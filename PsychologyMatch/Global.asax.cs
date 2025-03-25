using System;
using System.Web;

namespace PsychologyMatch
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Response.Filter = null;
                }
                catch { }

                Exception serverException = Server.GetLastError();
                if (serverException is HttpUnhandledException)
                {
                    Server.ClearError();
                    Server.Transfer("Error.html");
                }
            }
            catch (Exception)
            {
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 200;
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.     
            // Note: The Session_End event is raised only when the sessionstate mode    
            // is set to InProc in the Web.config file. If session mode is set to StateServer     
            // or SQLServer, the event is not raised.
            // 
            PsychMatch.User.HasSession = false;

            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
        }

        protected void Application_End(object sender, EventArgs e)
        {


            PsychMatch.User.HasSession = false;

            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
        }
    }
}