using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using PsychMatch;
using System.Web;

public partial class _Default : System.Web.UI.Page
{
    readonly SqlConnection _conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());
    object LoginParameter = new object();
    protected void Page_Load(object sender, EventArgs e)
    {
        //If the user does not have a session, clear out all the cookies.
        if(PsychMatch.User.HasSession == false)
        {
            string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Value = string.Empty;
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }
        if (Session["UserNoticeRead"] == null ) //Show Pop-up Warning Banner.
        {
           // rwNotification.VisibleOnPageLoad = true;
            Session["UserNoticeRead"] = true;
        }
        else //Don't show warning banner if page already loaded.
        {
            // rwNotification.VisibleOnPageLoad = false;
        }

        if (Request.QueryString["email"] == null)
        {
            lblLoginName.Text = ADLogic.GetADUserProperty(Page.User.Identity.Name, ADLogic.ADProperty.FirstName) + " " + ADLogic.GetADUserProperty(Page.User.Identity.Name, ADLogic.ADProperty.LastName);
            LoginParameter = ADLogic.GetADUserProperty(Page.User.Identity.Name, ADLogic.ADProperty.Email);

        }
        else
        {
            lblLoginName.Text = Request.QueryString["email"].SanitizeUnTrustedString();
            LoginParameter = Request.QueryString["email"].SanitizeUnTrustedString();
        }

        if(!IsPostBack)
        {
            if(_message != string.Empty)
            {
                lblError.Text = _message.Santize();
            }
        }
    }

    private string _message
    {
        get
        {
            if (Request.QueryString["msg"] != null)
            {
                return Request.QueryString["msg"];
            }
            else
            {
                return string.Empty;
            }
        }
    }

    private string _email
    {
        get
        {
            string email = string.Empty;
            if(Request.QueryString["email"] != null)
            {
                email = Request.QueryString["email"].SanitizeUnTrustedString(); 
            }
            return email;
        }
    }
    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        var emailToUse = string.Empty;
        emailToUse = _email == string.Empty ? LoginParameter.ToString() : _email;

        try
        {
            using (var rdr = SqlHelper.ExecuteReader(_conn,CommandType.StoredProcedure,"spPsychMatchGetUser", new SqlParameter("@VAEmail", emailToUse)))
            {
                if (rdr.Read())
                {
                    var isActive = false;
                    var isApproved = false;
                    var isAdmin = false;
                    bool.TryParse(rdr["Active"].ToString(), out isActive);
                    bool.TryParse(rdr["IsApproved"].ToString(), out isApproved);
                    bool.TryParse(rdr["IsAdmin"].ToString(), out isAdmin);


                    PsychMatch.User.Email = rdr["VAEmail"].ToString();
                    PsychMatch.User.UserID = rdr["UserID"].ToString();
                    //PsychMatch.User.FacilityID = rdr["FacilityID"].ToString();
                    PsychMatch.User.FullName = rdr["FullName"].ToString();
                    //PsychMatch.User.FacilityName = rdr["FacilityName"].ToString();
                    PsychMatch.User.IsActive = isActive;
                    PsychMatch.User.IsApproved = isApproved;
                    PsychMatch.User.IsAdmin = isAdmin;
                    PsychMatch.User.HasSession = true;
                    if (PsychMatch.User.IsActive)
                    {
                        Response.Redirect("PsychMatchList.aspx");
                    }
                    else
                    {
                        if (!PsychMatch.User.IsApproved)
                        {
                            lblError.Text =
                                "Your account has not been approved yet. You will receive an email once it is approved";
                        }
                        else if (!PsychMatch.User.IsActive)
                        {
                            lblError.Text =
                                "Your account is no longer active. Please contact the Associated Health Team if you think this is incorrect.";
                        }
                    }
                }
                else
                {
                    lblError.Text = "Your Email is not recognized.  Please register if you haven't already. If you have already registered, please contact the Associated Health Team.";
                }
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }   
    }
}