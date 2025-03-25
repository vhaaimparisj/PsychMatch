<%@ Page Language="C#" AutoEventWireup="true" Inherits="UserNotice" Codebehind="UserNotice.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="styles/bootstrap4/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div style="overflow:hidden; background-color:white; padding-top:20px;" class="text-center">
        <div id="banner-image">
            <a href="http://vaww.va.gov/" title="United States Department of Veterans Affairs">
                <img src="~/commonimages/OAAVALogo.jpg" runat="server" width="400" height="88" alt="United States Department of Veterans Affairs"
                    title="United States Department of Veterans Affairs" border="0" />
            </a>
        </div>
        </div>
        <div style="padding-top: 30px;" class="row">
            <div class="col-3"></div>
            <div class="col-6">
                <p class="text-center font-weight-bold">Attention Users of this System:</p>
            <p></p>
            <p class="text-center">
                This computer system, including all related equipment, networks,and network devices (including Internet access) is provided by the Department of Veterans Affairs (VA) in accordance with the agency policy for official 
                use and limited personal use. All agency computer systems may be monitored for all lawful purposes, including but not limited to, ensuring that use is authorized, for management of the system, to facilitate
                protection against unauthorized access, and to verify security procedures, survivability and operational security. Any information on this computer system may be examined, recorded, copied and used for authorized 
                purposes at any time. All information, including personal information, placed or sent over this system may be monitored, and users of this system are reminded that such monitoring does occur. 
                Therefore, there should be no expectation of privacy with respect to use of this system. By logging into this agency computer system, you acknowledge and consent to the monitoring of this system. 
                Evidence of your use, authorized or unauthorized, collected during monitoring may be used for civil, criminal, administrative, or other adverse action. Unauthorized or illegal use may subject you to prosecution.
            </p>
            <p></p>
            <p class="text-center font-weight-bold">This is a Privacy Act System of Records</p>
            <p></p>
            <p>Access to this information is limited to only those who have a need for the information in the performance of their official duties. Disclosure without the consent of the subject of the information is 
                restricted unless required by the Freedom of Information Act; to those listed in an appropriate Federal Register System of Records Notice under the "routine use" section; for the purposes identified in 
                that section; and to those identified in 43 C.F.R. 2.56. These records may not be altered or destroyed except as authorized by 43.C.F.R. 2.52. Please contact your office's Privacy Act Officer for advice on 
                disclosure restrictions.</p>
            <p></p>
            <p><strong>CRIMINAL PENALTIES FOR DISCLOSURE: </strong>The Privacy Act contains provisions for criminal penalties for knowingly and/or willfully disclosing information from this system unless properly authorized.</p>
            <p></p>
            <asp:HyperLink ID="btnAccept" runat="server" CssClass="btn btn-primary" ForeColor="White" Text="I acknowledge the above statements"></asp:HyperLink>
            </div>
            <div class="col-3"></div>
        </div>
        
        
    </form>
</body>
</html>
