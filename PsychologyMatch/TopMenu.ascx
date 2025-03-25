<%@ Control Language="C#" AutoEventWireup="true" Inherits="TopMenu" Codebehind="TopMenu.ascx.cs" %>
<div class="navbar navbar-expand-sm site-header ps-3 pe-3">
    <div class="col-sm-10">
        <ul class="navbar-nav me-5 mb-2 mb-lg-0">
            <li class="nav-item"><a title="Questions" class="nav-link" href="https://vaww.oaa.med.va.gov/OAAHelpDesk/" target="_blank">Questions?</a></li>

            <li class="nav-item"><a class="nav-link" href="docs/Psch_Intern_Affiliation_Agreement_Memo.pdf" target="_blank" title="Instructions"><i class="icon-file"></i>Instructions</a></li>

            <li class="nav-item ms-3"><a class="nav-link btn btn-success" href="Certify.aspx" id="btnConfirmComplete" runat="server"><i class="icon-check"></i>Match Results Entered</a></li>
        </ul>
    </div>
    <div class="col-sm-2 text-end">
        <ul class="navbar-nav me-5 mb-2 mb-lg-0">
            <li class="nav-item"><a title="Update Profile" class="nav-link" href="RegisterUpdate.aspx" name="top">Update Profile</a></li>
            <li class="nav-item"><a title="Log Out" class="btn btn-primary" href="logout.aspx" name="top">Log Out</a></li>
        </ul>
        
    </div>
</div>
<!--/.navbar -->