<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Certify" Codebehind="Certify.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CM" runat="Server">
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <div align="center" class="m-5 p-5" style="min-height: 600px">
        <table class="table-hover">
            <tr>
                <td class="pe-3">
                    <asp:CheckBox ID="chkConfirmPositionsAccurate" runat="server" /></td>
                <td><strong>By checking the box you are certifying that match results have been entered
                    <br />
                    You may still return to edit your results after selecting Match Results Entered.
                    <br />
                    Note: If you did not match with any positions in Phase I of the match, please check this box for tracking purposes</strong></td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <br />
                    <asp:Button runat="server" ID="btnConfirmComplete" CssClass="btn btn-success" Text="Match Results Entered" OnClick="btnConfirmComplete_Click" /></td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <a href="PsychMatchList.aspx">Return to Matches</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>