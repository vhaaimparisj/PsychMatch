<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="EntryComplete" Codebehind="EntryComplete.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CM" Runat="Server">
    <div align="center">
        <h4><asp:Label ID="lblEntryCompleteNotification" runat="server" ForeColor="Blue" Text="Your entries have been marked as complete.  <br />  Thank You!"></asp:Label></h4>
        <h5><a href="PsychMatchList.aspx">Return to Matches</a></h5>
    </div>
</asp:Content>

