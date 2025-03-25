<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityControl.ascx.cs" Inherits="PsychologyMatch.Controls.FacilityControl" %>
<div class="row sel-container p-2 row-eq-height">
    <div class="col-sm-5 justify-content-end d-flex align-items-center">
        <asp:Label ID="lblFacility" runat="server" ForeColor="black" Font-Names="Arial" Font-Bold="True" ToolTip="Select Facility">Select&nbsp;Facility:</asp:Label>
    </div>
    <div class="col-sm-7 justify-content-start d-flex align-items-center">
        <asp:DropDownList ID="cboFacility" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboFacility_SelectedIndexChanged" ToolTip="Select your Facility" Width="300px" CssClass="form-select"></asp:DropDownList>
    </div>
</div>