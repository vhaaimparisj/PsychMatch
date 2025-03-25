using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Web;

public partial class Certify : Page
{
    readonly SqlConnection _conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());
    int facFacility_ID;
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

    protected void btnConfirmComplete_Click(object sender, EventArgs e)
    {
        //Get total allowed and total requested
        int iTotalBase = 0;
        int iTotalRequested = 0;
        string sqlTotalRequested = string.Format(@"SELECT SUM(PositionCount)
                                FROM [dbo].[PsychMatchFacilitySponsorPosition]
                                WHERE Fyear=(Year(getdate()) + 1) and FacilityID = {0}", FacFacility_ID);
        int.TryParse(SqlHelper.ExecuteScalar(_conn, CommandType.Text, sqlTotalRequested).ToString().Santize(), out iTotalRequested);
        iTotalBase = Convert.ToInt32(PsychMatch.User.TotalAllowedPositions);

        if (!chkConfirmPositionsAccurate.Checked)
        {
            ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "popup",
            "alert('You must check the box acknowledging that all entries are accurate and complete before you can continue.');",
            true);
            
        }
        else if(iTotalRequested > iTotalBase)
        {
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "popup",
                "alert('You are requesting more positions than you are currently allowed. Please adjust your verification or contact Associated Health for assistance.');",
                true);
        }
        else
        {
            try
            {

                  //Insert Confirmation Record and redirect possibly send email
                SqlHelper.ExecuteNonQuery(_conn, "spPsychMatchEntryCompleteUpsert", new SqlParameter("@facilityID", FacFacility_ID),
                                                                                    new SqlParameter("@userID", Convert.ToInt32(PsychMatch.User.UserID)),
                                                                                    new SqlParameter("@totalBase", iTotalBase),
                                                                                    new SqlParameter("@totalRequested", iTotalRequested));

                Response.Redirect("EntryComplete.aspx");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An Error has occured while trying to insert Confirmation Record: " + ex.Message;
            }
        }
    }

    protected int FacFacility_ID
    {
        get
        {
            return facFacility_ID = Convert.ToInt32(PsychMatch.User.SelectedFacilityId);
        }
    }
}