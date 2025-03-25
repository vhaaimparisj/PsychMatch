using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Telerik.Web.UI;
using System.Web;

public partial class AddNewPosition : System.Web.UI.Page
{
    readonly SqlConnection _connOaadb = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());

    private int PositionId
    {
        get
        {
            var temp = 0;
            if (Request.QueryString["PositionId"] != null)
            {
                int.TryParse(Request.QueryString["PositionId"], out temp);
            }
            return temp;
        }
    }

    private int FacilityId
    {
        get
        {
            var temp = 0;
            if (Request.QueryString["facFacility_ID"] != null)
            {
                int.TryParse(Request.QueryString["facFacility_ID"], out temp);
            }
            return temp;
        }
    }

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
            CloseForm();
        }

        if(!IsPostBack)
        {
            if(PositionId != 0)
            {
                LoadForm();
            }
        }
    }
    protected void cmdAdd_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;

        if (cboAffiliateSearch.SelectedIndex <= 0)
        {
            lblMessage.Text = "You must select an affiliate from the list";
            return;
        }
        
        try
        {
            int maxPositions;
            int.TryParse(PsychMatch.User.TotalAllowedPositions, out maxPositions);

            if(txtMatchedPositions.Value > (maxPositions - GetTotalMatched()))
            {
                lblMessage.Text =
                    string.Format("You cannot add more positions than approved.  You have {0} approved positions",
                        maxPositions);
                return;
            }
            if(txtMatchedPositions.Value <= 0)
            {
                lblMessage.Text = "Number of positions must be greater than 0";
                return;
            }
            
            
            SqlHelper.ExecuteNonQuery(_connOaadb, "dbo.spPsychMatchPositionUpsert", 
                                                new SqlParameter("@positionID", PositionId),
                                                new SqlParameter("@facilityID", FacilityId),
                                                new SqlParameter("@sponsorID", int.Parse(cboAffiliateSearch.SelectedValue)),
                                                new SqlParameter("@positionCount", int.Parse(txtMatchedPositions.Text)),
                                                new SqlParameter("@fieldComment", ""),
                                                new SqlParameter("@whoCreatedUpdated", int.Parse(PsychMatch.User.UserID)));
            lblMessage.Text = "Record successfully saved.  You can add another or click the close window button. NOTE: The list will not be refreshed until you close this window.";
            ClearFields();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void ddlAffiliate_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDegreeProgram();
    }

    private int GetTotalMatched()
    {
        int iTotalRequested = 0;
        string sqlTotalRequested = string.Format(@"SELECT SUM(PositionCount)
                                FROM [dbo].[PsychMatchFacilitySponsorPosition]
                                WHERE Fyear=(Year(getdate()) + 1) and FacilityID = {0} AND PositionID !={1}", FacilityId, PositionId);
        int.TryParse(SqlHelper.ExecuteScalar(_connOaadb, CommandType.Text, sqlTotalRequested).ToString().Santize(), out iTotalRequested);
        return iTotalRequested;
    }

    private void GetDegreeProgram()
    { 
        var sql = string.Format(@"SELECT [SponsorID]
                        ,[SponsorName]
                        ,[Program]
                        ,[Degree]
                       FROM [dbo].[vPsychMatchSponsorDetail] 
                       WHERE [SponsorID] = {0}", cboAffiliateSearch.SelectedValue);
        var ds = SqlHelper.ExecuteDataset(_connOaadb, CommandType.Text, sql);
        if(ds.Tables[0].Rows.Count > 0)
        {
            lblDegree.Text = ds.Tables[0].Rows[0]["Degree"].ToString().Santize();
            lblProgram.Text = ds.Tables[0].Rows[0]["Program"].ToString().Santize();
        }
    }

    
    private void LoadForm()
    {
        DataSet ds = SqlHelper.ExecuteDataset(_connOaadb, "spPsychMatchGetPosition", new SqlParameter("@PositionID", PositionId));
        
        cboAffiliateSearch.SelectedValue = ds.Tables[0].Rows[0]["SponsorID"].ToString();
        txtMatchedPositions.Text = ds.Tables[0].Rows[0]["PositionCount"].ToString().Santize();
        GetDegreeProgram();
    }
    private void ClearFields()
    {
        lblDegree.Text = string.Empty;
        lblProgram.Text = string.Empty;
        
        cboAffiliateSearch.SelectedIndex = 0;
    }

    private void CloseForm()
    {
        lblMessage.Text = "<script type='text/javascript'>top.location.href='PsychMatchList.aspx'</script>";
    }

    protected void btnCloseWindow_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
    protected void cboAffiliateSearch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        GetDegreeProgram();
    }
}