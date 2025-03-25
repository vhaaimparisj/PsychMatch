using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Telerik.Web.UI;

namespace PsychologyMatch
{
    public partial class RegisterUpdate : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string sql = @"SELECT DISTINCT[facFacility_ID],[FacSNameAndVaFacType] AS facName 
                                FROM[dbo].[vPsychMatchUsedFacilities] 
                                ORDER BY facName";

                var rdr = SqlHelper.ExecuteReader(conn,CommandType.Text ,sql);
                ddlFacility.DataSource = rdr;
                ddlFacility.DataValueField = "facFacility_ID";
                ddlFacility.DataTextField = "facName";
                ddlFacility.DataBind();

                rdr.Close();
                pnlSuccess.Visible = false;
                pnlDeactivate.Visible = false;

                LoadUserInfo();
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UpdateUser();
                pnlUserFields.Visible = false;
                pnlSuccess.Visible = true;
            }
        }

        protected void cmdDeactivate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DeactivateUser();

                string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
                foreach (string cookie in cookies)
                {
                    Response.Cookies[cookie].Value = string.Empty;
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }

                Session.RemoveAll();
                Session.Clear();
                Session.Abandon();

                Response.Redirect("default.aspx");
            }
        }

        private void UpdateUser()
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
                            {new SqlParameter("@userID", PsychMatch.User.UserID)
                                    , new SqlParameter("@title", ddlTitle.Text)
                                    , new SqlParameter("@lastName", txtLastName.Text.Trim())
                                    , new SqlParameter("@firstName", txtFirstName.Text.Trim())
                                    , new SqlParameter("@vaEmail", txtEmail.Text.Trim())
                                    , new SqlParameter("@phone", txtPhone.Text.Trim())
                                    , new SqlParameter("@isAdmin", "false")
                                    , new SqlParameter("@isApproved", "true")
                                    , new SqlParameter("@isActive", "true")
                                    , new SqlParameter("@facilityIds", String.Join(",", checkedFacilities))
                                    , returnParameter};
            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "spPsychMatchUserUpsert", parameters);
         }

        private void DeactivateUser()
        {
            if(Page.IsValid)
            {
                string sql = "UPDATE dbo.PsychMatchUser SET Active = 0 WHERE VAEmail =@userEmail";

                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, new SqlParameter("@userEmail", PsychMatch.User.Email));
                
                string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
                foreach (string cookie in cookies)
                {
                    Response.Cookies[cookie].Value = string.Empty;
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }

                Session.RemoveAll();
                Session.Clear();
                Session.Abandon();

                Response.Redirect("default.aspx");
            }
        }
    
        private void LoadUserInfo()
        {
            try
            {
                string userSql = @"SELECT	u.UserID
		                                , u.TitlePosition
		                                , u.FirstName 
		                                , u.LastName 
		                                , u.VAEmail
		                                , u.BusinessPhone
		                                , u.IsApproved
		                                , STRING_AGG (fac.FacilityID, ',') AS Facilities
                                FROM    dbo.PsychMatchUser u 
                                LEFT JOIN PsychMatchUserFacility fac ON u.UserID = fac.UserID
                                WHERE u.VAEmail =@userEmail
                                GROUP BY u.UserID
		                                , u.TitlePosition
		                                , u.FirstName 
		                                , u.LastName 
		                                , u.VAEmail
		                                , u.BusinessPhone
		                                , u.IsApproved";
                using (var rdr = SqlHelper.ExecuteReader(conn, CommandType.Text, userSql, new SqlParameter("@userEmail", PsychMatch.User.Email)))
                {
                    if (rdr.Read())
                    {
                        txtFirstName.Text = rdr["FirstName"].ToString();
                        txtLastName.Text = rdr["LastName"].ToString();
                        txtPhone.Text = rdr["BusinessPhone"].ToString();
                        txtEmail.Text = rdr["VAEmail"].ToString();
                        if (!string.IsNullOrEmpty(rdr["TitlePosition"].ToString()))
                        {
                            ddlTitle.SelectedValue = rdr["TitlePosition"].ToString();
                        }
                        string facilities = rdr["Facilities"].ToString();

                        if(!string.IsNullOrEmpty(facilities))
                        {
                            string[] facilityIds = facilities.Split(',');
                            foreach (string facilityId in facilityIds) 
                            { 
                               RadComboBoxItem item = ddlFacility.FindItemByValue(facilityId);
                                if (item != null)
                                {
                                    item.Checked = true;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}