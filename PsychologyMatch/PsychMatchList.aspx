<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="PsychMatchList" Codebehind="PsychMatchList.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/TopMenu.ascx" TagName="TopMenu" TagPrefix="uc" %>
<%@ Register Src="~/Controls/FacilityControl.ascx" TagName="userFacility" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CM" Runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <script type="text/javascript">
            function ShowInsertForm() {
                window.radopen("AddNewPosition.aspx?facFacility_ID=<%=FacFacility_ID%>", "NewPositionDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager2.ClientID %>").ajaxRequest("Rebind");
                 }
                 else {
                     $find("<%= RadAjaxManager2.ClientID %>").ajaxRequest("RebindAndNavigate");
                 }
            }
        </script>
        </telerik:RadCodeBlock>
        <telerik:RadScriptManager ID="ScriptManager1" runat="server"></telerik:RadScriptManager>
        <uc:TopMenu ID="TopMenu" runat="server" />
        <div class="container-fluid">
            <div class="row m-5">
                <div class="col-sm-12">
                    <div class="row justify-content-center">
                        <div class="col-sm-5 text-center p-3 ms-3">

                            <div>
                                <strong style="color:blue"> Select Facility: </strong>
                                <uc2:userFacility runat="server" ID="selUserFacility" OnListChanged="selUserFacility_ListChanged"/>
                            </div>
                            <div>
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="true"  ></asp:Label>
                            </div>
                            
                            <div class="row ps-2 pe-2">
                                <div class="col-6 text-end"><asp:Label ID="lblTotalPositionsAllowed" runat="server" Font-Bold="true" CssClass="badge bg-success"></asp:Label></div>
                                <div class="col-6 text-start"><asp:Label ID="lblTotalPositionsRequested" runat="server" Font-Bold="true" CssClass="badge bg-primary"  ></asp:Label></div>
                            </div>  
                            <hr/>
                                <asp:Button ID="btnAddNewPosition" runat="server" Text="Add Internship Positions" CssClass="btn btn-small btn-primary" OnClientClick="return ShowInsertForm();" />          
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 p-3">
                    <telerik:RadGrid ID="grdMain" runat="server" DataSourceID="dsMain" AllowSorting="true" AutoGenerateColumns="false"  AllowAutomaticDeletes="true"
                        Skin="Vista" OnItemCreated="grdMain_ItemCreated" OnItemDataBound="grdMain_ItemDataBound" OnItemCommand="grdMain_ItemCommand" OnDataBound="grdMain_DataBound">
                        <MasterTableView DataKeyNames="PositionId" ShowFooter="true" Width="100%">
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="PositionId" DataField="PositionId" Visible="false"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="false" ShowFilterIcon="false" ShowSortIcon="false" HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hypEditPosition" runat="server" Font-Bold="true" CssClass="icon-edit" ToolTip="Edit" >Edit</asp:HyperLink>
                                        <telerik:RadScriptBlock ID="ScriptBlock10" runat="server">
                                            <script type="text/javascript">
                                                function showEditPositionsWindow(id, rowIndex) {
                                                    var grid = $find("<%= grdMain.ClientID %>");
                                                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                                                    grid.get_masterTableView().selectItem(rowControl, true);
                                                    var oWindow = window.radopen("AddNewPosition.aspx?facFacility_ID=<%=FacFacility_ID%>&PositionId=" + id, "addPosWindow");
                                                    oWindow.setSize(780, 590);
                                                    oWindow.center();

                                                    return false;
                                                }
                                            </script>
                                        </telerik:RadScriptBlock>
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="Affiliate_Name" HeaderStyle-Width="300" DataField="SponsorName" HeaderText="Affiliate"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Degree" DataField="Degree" HeaderText="Degree" HeaderStyle-Width="50"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Program" DataField="Program" HeaderText="Program"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="PositionCount" DataField="PositionCount" HeaderText="Positions" Aggregate="Sum"></telerik:GridBoundColumn>
<%--                                <telerik:GridBoundColumn UniqueName="FieldComments" DataField="FieldComments" HeaderText="Comments" HeaderStyle-Width="300"></telerik:GridBoundColumn>--%>
                                <telerik:GridButtonColumn CommandName="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Center" UniqueName="DeleteColumn" Text="Delete" HeaderText="Delete" ConfirmTitle="Delete Record?" ConfirmText="Are you sure you want to delete this affiliate?" ></telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>
                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
                        <Windows>
                            <telerik:RadWindow ID="NewPositionDialog" runat="server" Title="Add New Position(s)" Height="590px"
                                Width="780px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                                Modal="true" />
                        </Windows>
                    </telerik:RadWindowManager>

                    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                        <AjaxSettings>

                            <telerik:AjaxSetting AjaxControlID="grdMain">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="grdMain" LoadingPanelID="RadAjaxLoadingPanel2" />
                                    <telerik:AjaxUpdatedControl ControlID="lblTotalPositionsRequested" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxManager2">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="grdMain" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>

                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Vista" OnAjaxRequest="RadAjaxManager1_AjaxRequest" />
                </div>
            </div>
        </div>
     <asp:SqlDataSource ID="dsMain" runat="server" SelectCommandType="StoredProcedure" SelectCommand="spPsychMatchGetPositionsByFacility"   ConnectionString="<%$ ConnectionStrings:cnOAAADB %>">
        <SelectParameters>
            <asp:ControlParameter ControlID="selUserFacility"  Name="facilityID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

