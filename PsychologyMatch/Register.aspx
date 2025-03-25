<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Register" Codebehind="Register.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CM" runat="Server">
    <style type="text/css">
        .style1 {
            font-size: xx-small;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
        <div class="row m-3 pt-5 pb-5 justify-content-center">
            <div class="col-sm-5">
                <h4 class="text-center">Please Register for an account to enter your data.
                </h4>
                <p style="color: red" class="text-center">
                    <b>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label></b>
                </p>
                <p class="text-center">
                    After registering, you will be able to log in using your Integrated Windows Account.
                    <br />
                    You should only create <strong>one account.</strong>
                </p>
                <table summary="layout" width="100%">
                    <tr>
                        <td align="right" class="righttext">First Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" Width="285px" ToolTip="First Name" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valFirstName" runat="server" ErrorMessage="* Required" ForeColor="Red" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="righttext">Last Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastname" runat="server" MaxLength="50" Width="285px" ToolTip="Last Name" CssClass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="valLastName" runat="server" ForeColor="Red" ErrorMessage="* Required"
                                ControlToValidate="txtLastname"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="righttext">Title/Position:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTitle" runat="server" ToolTip="Title or Position" CssClass="form-control form-select">
                                <asp:ListItem Text="Assistant Training Director"></asp:ListItem>
                                <asp:ListItem Text="Psychology Training Director"></asp:ListItem>
                                <asp:ListItem Text="Psychology Chief"></asp:ListItem>
                                <asp:ListItem Text="VAMC Education Office"></asp:ListItem>
                            </asp:DropDownList>
                            <p></p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="righttext">Phone:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="50" Width="285px" ToolTip="Telephone" CssClass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="valPhone" runat="server" ForeColor="Red" ErrorMessage="* Required"
                                ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="righttext">Email:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="285px" ToolTip="Email" Enabled="false" CssClass="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="valEmail" runat="server" ErrorMessage="* Required" ForeColor="Red"
                                ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="valEmailConstruct" runat="server" ForeColor="Red" ControlToValidate="txtEmail"
                                ErrorMessage="* Not Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="righttext" valign="top">Facility:
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlFacility" CssClass="col-6" runat="server" DataValueField="facFacility_ID" ToolTip="Facility" DataTextField="facName" CheckBoxes="true" Width="200px" Orientation="VerticalLeft">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="valFacility" runat="server" ControlToValidate="ddlFacility" ForeColor="red" ErrorMessage="Value is required" Text="Select one or more Facility(s)">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>

                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="cmdSubmit" runat="server" Text="Register" ToolTip="Register" OnClick="cmdSubmit_Click" CssClass="btn btn-primary" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>