using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Telerik.Web.UI;
using System.Web;

public partial class PsychMatchList : Page
{
    SqlConnection connOAADB = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnOAAADB"].ToString());

    protected int TotalPositions { get; set; }
    protected int TotalRequestedPositions { get; set; }

    protected int GridRowCount { get; set; }

    protected int FacFacility_ID
    {
        get
        {
            return Convert.ToInt32(selUserFacility.SelectedValue);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();

        base.OnInit(e);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            selUserFacility_ListChanged(null, null);
        }
        else
        {
            //selUserFacility.SelectedValue = PsychMatch.User.SelectedFacilityId;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!PsychMatch.User.HasSession)
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

    protected void grdMain_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridItem)
        {
            HyperLink hlEditPositions = (HyperLink)e.Item.FindControl("hypEditPosition");
            if (hlEditPositions != null)
            {
                hlEditPositions.Attributes["href"] = "javascript:void(0);";
                hlEditPositions.Attributes["onclick"] = string.Format("return showEditPositionsWindow('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PositionId"], e.Item.ItemIndex);

            }
        }
    }
    protected void grdMain_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //To correct the row count not resetting to zero after all recs deleted, need to check if the grid is empty, if it is, set to 0
        if (e.Item is GridHeaderItem)
        {
            TotalRequestedPositions = 0;
        }
        if(e.Item is GridDataItem)
        {
            try
            {
                GridDataItem item = (GridDataItem)e.Item;
                TotalRequestedPositions += Convert.ToInt32(DataBinder.Eval(item.DataItem, "PositionCount").ToString());
                lblTotalPositionsRequested.CssClass = "badge bg-primary";
                lblTotalPositionsRequested.Text = "Total Matched: " + TotalRequestedPositions;
                GridRowCount++;
            }
            catch (Exception ex)
            {
                Label1.Text = "Error Occured in grdMain_ItemDataBound: " + ex.Message;
            }
        }
    }
    protected void grdMain_ItemCommand(object sender, GridCommandEventArgs e)
    {
        string psychMatch_ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PositionId"].ToString();

        try
        {
            SqlHelper.ExecuteNonQuery(connOAADB, "spPsychMatchDeletePosition", new SqlParameter("@PositionID", psychMatch_ID));
            ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "popup",
            "alert('Record Deleted');",
            true);
            grdMain.Rebind();

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "popup",
            ex.Message,
            true);
        }
    }
    
    private void GetTotalPositions()
    {
        int totalApproved;
        try
        {
            int.TryParse(SqlHelper.ExecuteScalar(connOAADB, "spWeb_AH_Psych_Fac_Affiliations_Get", new SqlParameter("@facFacility_ID", selUserFacility.SelectedValue)).ToString(), out totalApproved);
            TotalPositions = totalApproved;
            lblTotalPositionsAllowed.Text = "Approved Positions: " + totalApproved + " (Base + Temporary)";
            PsychMatch.User.TotalAllowedPositions = totalApproved.ToString();
        }
        catch
        {
            PsychMatch.User.TotalAllowedPositions = "0";
        }
    }

    private bool CheckCompletionStatus()
    {
        int recCnt = 0;
        string sql = @"SELECT Count(*)
                       FROM [dbo].[PsychMatchEntryComplete]
                       WHERE Fyear=(Year(getdate()) + 1) and FacilityID = " + selUserFacility.SelectedValue;
                        
        int.TryParse(SqlHelper.ExecuteScalar(connOAADB,CommandType.Text,sql).ToString(), out recCnt);
        if (recCnt > 0)
            return true;
        else
            return false;
    }

    protected void selUserFacility_ListChanged(object sender, EventArgs e)
    {
        PsychMatch.User.SelectedFacilityId = selUserFacility.SelectedValue;
        GetTotalPositions();
        //Check if the facility has already confirmed complete
        if (CheckCompletionStatus())
        {
            Label1.Text = "Your facility has already confirmed entries are complete";

        }
        else
        {
            Label1.Text = string.Empty;
        }
        grdMain.Rebind();
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            grdMain.MasterTableView.SortExpressions.Clear();
            grdMain.MasterTableView.GroupByExpressions.Clear();
            grdMain.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            grdMain.MasterTableView.SortExpressions.Clear();
            grdMain.MasterTableView.GroupByExpressions.Clear();
            grdMain.MasterTableView.CurrentPageIndex = grdMain.MasterTableView.PageCount - 1;
            grdMain.Rebind();
        }
    }
    protected void btnCertify_Click(object sender, EventArgs e)
    {
        Response.Redirect("Certify.aspx");
    }

    protected void grdMain_DataBound(object sender, EventArgs e)
    {
        if (grdMain.MasterTableView.Items.Count <= 0)
        {
            lblTotalPositionsRequested.Visible = false;
        }
        else
        {
            lblTotalPositionsRequested.Visible = true;
        }
    }
}