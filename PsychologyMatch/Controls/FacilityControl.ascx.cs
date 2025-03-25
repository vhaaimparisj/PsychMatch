using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PsychologyMatch.Controls
{
    public partial class FacilityControl : UserControl
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());

        public event ListChangedEventHandler ListChanged;

        public delegate void ListChangedEventHandler(object sender, EventArgs e);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (PsychMatch.User.IsAdmin)
                {
                    string sql = @"SELECT DISTINCT[facFacility_ID],[FacSNameAndVaFacType] AS facName 
                                FROM[dbo].[vPsychMatchUsedFacilities] 
                                ORDER BY facName";

                    var rdr = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);
                    cboFacility.DataSource = rdr;
                    cboFacility.DataValueField = "facFacility_ID";
                    cboFacility.DataTextField = "facName";
                    cboFacility.DataBind();

                    rdr.Close();
                }
                else
                {
                    string sql = @"	SELECT	fac.FacilityID, f.facsnameandvafactype AS FacilityName
                                    FROM    dbo.PsychMatchUser u 
	                                INNER JOIN PsychMatchUserFacility fac ON u.UserID = fac.UserID
	                                INNER JOIN vPsychMatchUsedFacilities f ON (fac.FacilityID = f.facfacility_id 
                                        AND f.fyear = YEAR(GETDATE()) + 1)
                                    WHERE  u.VAEmail = @userEmail
                                    ORDER BY FacilityName";

                    var rdr = SqlHelper.ExecuteReader(conn, CommandType.Text, sql, new SqlParameter("@userEmail", PsychMatch.User.Email));
                    cboFacility.DataSource = rdr;
                    cboFacility.DataValueField = "FacilityID";
                    cboFacility.DataTextField = "FacilityName";
                    cboFacility.DataBind();

                    rdr.Close();
                }
            }

        }

        protected void cboFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ListChanged != null)
            {
                this.ListChanged(this, e);
            }
        }
        public string SelectedValue
        {
            get
            {
                try
                {
                    return this.cboFacility.SelectedItem.Value;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                cboFacility.SelectedIndex = cboFacility.Items.IndexOf(cboFacility.Items.FindByValue(value));
            }
        }

        public string SelectedText
        {
            get
            {
                try
                {
                    return this.cboFacility.SelectedItem.Text;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public int SetWidth
        {
            set { cboFacility.Width = Unit.Pixel(value); }
        }
    }
}