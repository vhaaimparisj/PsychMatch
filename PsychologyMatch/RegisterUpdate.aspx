<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="RegisterUpdate.aspx.cs" Inherits="PsychologyMatch.RegisterUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CM" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row justify-content-center">
        <div class="col-sm-6 p-3 text-center">
            <h5 class="text-center">Please update or remove your registration.</h5>
            <asp:Panel ID="pnlUserFields" runat="server">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                <div class="row">
                    <div class="col-6 righttext">
                        First Name:
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="200px" MaxLength="25" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="valFirstName" runat="server" ErrorMessage="Required" ControlToValidate="txtFirstName" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 righttext">
                        Last Name:
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="txtLastName" runat="server" Width="200px" MaxLength="25" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="valLastName" runat="server" ErrorMessage="Required" ControlToValidate="txtLastName" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 righttext">
                        Title:
                    </div>
                    <div class="col-6">
                        <asp:DropDownList ID="ddlTitle" runat="server" ToolTip="Title or Position"  CssClass="form-control form-select">
                                    <asp:ListItem Text="Assistant Training Director"></asp:ListItem>
                                    <asp:ListItem Text="Psychology Training Director"></asp:ListItem>
                                    <asp:ListItem Text="Psychology Chief"></asp:ListItem>
                                    <asp:ListItem Text="VAMC Education Office"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valTitle" runat="server" ErrorMessage="Required" ControlToValidate="ddlTitle" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>            
                <div class="row">
                    <div class="col-6 righttext">
                        Phone Number:
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="txtPhone" runat="server" Width="200px" MaxLength="25" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPhone" runat="server" ErrorMessage="Required" ControlToValidate="txtPhone" ForeColor="red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 righttext">
                        Email:
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="txtEmail" runat="server" Width="200px" MaxLength="50" ReadOnly="true" CssClass="form-control"></asp:TextBox><div class="text-start"><small>Your VA Email cannot be changed.</small></div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valEmailString" runat="server" ErrorMessage="Check Email" ForeColor="red"
                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6 righttext">
                        Facility(s):
                    </div>
                            <telerik:RadComboBox ID="ddlFacility" CssClass="col-6" runat="server" DataValueField="facFacility_ID" ToolTip="Facility" DataTextField="facName" CheckBoxes="true" Width="200px" Orientation="VerticalLeft">
                            </telerik:RadComboBox>
                            <asp:SqlDataSource ID="sqlDSFacility" runat="server" ConnectionString="<%$ ConnectionStrings:cnOAAADB %>" SelectCommand="SELECT DISTINCT [facFacility_ID],[FacSNameAndVaFacType] AS facName FROM [dbo].[vPsychMatchUsedFacilities] ORDER BY facName"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="valFacility" runat="server" ControlToValidate="ddlFacility" ForeColor="red" ErrorMessage="Value is required" Text="Select one or more Facility(s)">
                            </asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="cmdRegister" runat="server" Text="Update My Profile" OnClick="cmdUpdate_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="cdmDeactivate" runat="server" Text="Remove My Registration" OnClick="cmdDeactivate_Click" CssClass="btn btn-primary btn-sm" />
            
            </asp:Panel>

        
            <asp:Panel ID="pnlSuccess" runat="server">
                <div style="text-align: center">
                    <img src="~/images/GreenCheckMark.png" alt="Success" runat="server" /><p>
                    </p>
                    <h4>Your Pofile has been Updated. </h4>
                    <p>&nbsp;</p>
                    <h4><a href="PsychMatchList.aspx">Back to Program List</a></h4>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlDeactivate" runat="server">
                <div style="text-align: center">
                    <img src="~/images/GreenCheckMark.png" alt="Success" runat="server" /><p>
                    </p>
                    <h4>
                    Your account has been deactivated.
                    <br />
                    <a href="default.aspx">Back to home</a></h4>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>