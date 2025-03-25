using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserNotice : System.Web.UI.Page
{
    private string _referrerURL
    {
        get
        {
            return Request.QueryString["r"].SanitizeUnTrustedString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            btnAccept.NavigateUrl = _referrerURL;
        }
    }
}