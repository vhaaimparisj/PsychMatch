<%@ Page Language="C#" AutoEventWireup="true" Inherits="AddNewPosition" Codebehind="AddNewPosition.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add\Update - Psychology Internship Affiliation Match Portal</title>
    <link href="bootstrap/css/bootstrap.min.css" rel="Stylesheet" />
    <link href="Includes/General_stylesBS2.css" type="text/css" rel="stylesheet" />
</head>
<body background="images/lightbluegradientbackground.jpg">
    <form id="form1" runat="server">
        <script type="text/javascript">
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }

            function Rebind(args){
                GetRadWindow().BrowserWindow.refreshGrid(args);
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }

            function CancelEdit() {
                GetRadWindow().close();
            }
        </script>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:HiddenField ID="hdnMaxPositions" runat="server" />
            <table width="100%" border="0" cellpadding="3" cellspacing="3">
                <tr>
                    <td width="5%"></td>
                    <td>
                        <h4>Add New Psychology Internship Positions</h4>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <table border="1" cellpadding="3" cellspacing="3" width="100%">

                                    <tr>

                                        <td align="right" valign="top"><strong>Affiliate:</strong></td>

                                        <td>
                                            <telerik:RadComboBox ID="cboAffiliateSearch" runat="server" EmptyMessage="Type to Search for Affiliate..." Filter="Contains" Width="400px"
                                                 DataTextField="Sponsor" DataValueField="SponsorID" AllowCustomText="false" AutoPostBack="true"
                                                 OnSelectedIndexChanged="cboAffiliateSearch_SelectedIndexChanged" DataSourceID="dsAffiliationList"></telerik:RadComboBox>
                                            <a class="btn btn-danger btn-mini" href="https://vaww.oaa.med.va.gov/OAAHelpDesk/" target="_blank">Can't find affiliate?</a><br/>
                                            <p>Click <b>Can’t find affiliate</b> button to initiate Help desk request and <b>select “Associated Health Affiliation Agreements” from the topic options.</b></p>

                                            <asp:SqlDataSource ID="dsAffiliationList" runat="server" ConnectionString="<%$ ConnectionStrings:cnOAAADB %>" 
                                                SelectCommand="spPsychMatchGetSponsors" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right" valign="top">
                                            <strong>Degree:</strong><br />
                                            
                                        </td>
                                        <td>
                                            
                                            <asp:Label ID="lblDegree" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                            
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td align="right">
                                            <strong>Program:</strong>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProgram" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table cellpadding="3" cellspacing="3">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblMatchedPositions" runat="server" Text="Number of Matched Positions"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox EmptyMessage="Enter number of hours" Type="Number" NumberFormat-DecimalDigits="0"
                                                            Width="75px" ID="txtMatchedPositions" MaxLenth="2" Value="1" ShowSpinButtons="true" runat="server" MinValue="1" />
                                                        <asp:RangeValidator ID="valHours" runat="server" ErrorMessage="Must be Above 0" ControlToValidate="txtMatchedPositions"
                                                            MaximumValue="9999" MinimumValue="1" ForeColor="Red"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
<%--                                    <tr>
                                        <td align="right" valign="top"><strong>Comments:</strong></td>
                                        <td><asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="3" Height="87px" Width="498px"></asp:TextBox></td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="cmdAdd" runat="server" Text="Save Entry" class="btn btn-primary" EnableViewState="false" OnClick="cmdAdd_Click" />
                                                
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <p>
                            &nbsp;
                        </p>
                        <table width="100%" cellpadding="5" cellspacing="5">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnCloseWindow" runat="server" Text="Close this Window" OnClick="btnCloseWindow_Click"  CausesValidation="false"
                                        class="btn btn-warning" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="5%"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<!--OnClientClick="CloseAndRebind();"-->