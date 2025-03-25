using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using PsychMatch;
using Telerik.Web.UI;
using static Telerik.Web.UI.OrgChartStyles;

public partial class Register : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sql = @"SELECT DISTINCT[facFacility_ID],[FacSNameAndVaFacType] AS facName 
                                FROM[dbo].[vPsychMatchUsedFacilities] 
                                ORDER BY facName";

            var rdr = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);
            ddlFacility.DataSource = rdr;
            ddlFacility.DataValueField = "facFacility_ID";
            ddlFacility.DataTextField = "facName";
            ddlFacility.DataBind();

            rdr.Close();

            txtEmail.Text = ADLogic.GetADUserProperty(Page.User.Identity.Name, ADLogic.ADProperty.Email);
        }
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {

        //var sql = "Select * from dbo.PsychMatchUser where VAEmail = '" + txtEmail.Text.Trim() + "'";
        var sql = "Select * from dbo.PsychMatchUser where VAEmail = @email";
        SqlParameter param = new SqlParameter("@email", txtEmail.Text.Trim().Santize());
        if(ddlTitle.SelectedValue == "0")
        {
            lblMessage.Text = "Title is required";
            return;
        }
        if(ddlFacility.SelectedValue == "0")
        {
            lblMessage.Text = "Facility is required";
            return;
        }
        try
        {
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql, param);
            if(ds.Tables[0].Rows.Count > 0)
            {
                lblMessage.Text = "There is already an account registered with this email address.  <a href='default.aspx'>Please login</a> ";
            }
            else
            {
                string[] checkedFacilities = new string[ddlFacility.CheckedItems.Count ];
                int count = 0;
                foreach (RadComboBoxItem checkeditem in ddlFacility.CheckedItems) //Build User Facility List 1 ore more.
                {
                    checkedFacilities[count] = checkeditem.Value.ToString();
                    count++;
                }
                var returnParameter = new SqlParameter("@RetVal", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] parameters =
                                {new SqlParameter("@userID", 0)
                                    , new SqlParameter("@title", ddlTitle.Text)
                                    , new SqlParameter("@lastName", txtLastname.Text.Trim())
                                    , new SqlParameter("@firstName", txtFirstName.Text.Trim())
                                    , new SqlParameter("@vaEmail", txtEmail.Text.Trim())
                                    , new SqlParameter("@phone", txtPhone.Text.Trim())
                                    , new SqlParameter("@isAdmin", "false")
                                    , new SqlParameter("@isApproved", "true")
                                    , new SqlParameter("@isActive", "true")
                                    , new SqlParameter("@facilityIds", String.Join(",", checkedFacilities))
                                    , returnParameter};
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure,"spPsychMatchUserUpsert", parameters);
                Response.Redirect("Default.aspx?msg=" + "Thank you for Registering! Your Account has been created. You can now login and complete the match.");
            }
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}