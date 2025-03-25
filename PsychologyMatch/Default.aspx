<%@ Page Title="Psychology Match Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CM" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row m-5 border shadow">
            <div class="col-sm-6 mt-3 mb-3">
                <div>
                    <p>
                        Welcome and thank you for visiting the <strong>Psychology Internship Affiliation Match Portal</strong>  Website
                    </p>
                    <p>
                        Please <a href="Register.aspx">Register</a> if you have not already
                    </p>
                </div>
                <div class="row info_box" style="margin-top: 35px">
                    <div class="col-6">
                        <p style="color: maroon"><b>Questions?</b></p>
                        <p>Direct questions to Associated Health Team at <a href="https://vaww.oaa.med.va.gov/OAAHelpDesk/" target="_blank">OAA Help desk</a> . Select “Associated Health Affiliation Agreements” from the topic options.</p>
                    </div>
                    <div class="col-6">
                        <p style="color: maroon"><b>Technical difficulties?</b></p>
                        <p style="padding-left: 20px"><a href="mailto:oaadmc@va.gov?subject=Psychology Affiliation Portal Issues" title="Psychology Affiliation Portal Issues">OAA DMC</a></p>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 mt-3 mb-3 login border-start">
                <p><b>We'll Sign In with your Integrated Windows Account if you have access.  Click Login Below or Register.</b></p>
                <div class="input-prepend">
                    <h4>
                        <span style="color: navy">Welcome:
                                        <asp:Label ID="lblLoginName" runat="server" Font-Bold="true"></asp:Label>
                        </span>
                    </h4>
                </div>

                <div>
                    <asp:Button ID="cmdLogin" runat="server" Text=" Login " OnClick="cmdLogin_Click" CssClass="btn btn-success" />
                    <a href="Register.aspx" style="color: white" class="btn btn-primary btn-mini"><i class="icon-white icon-check"></i>Register</a></div>
                <asp:Label ID="lblError" runat="server" ForeColor="red" Font-Bold="True" Font-Size="Large"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container-fluid site-hero">
        <div class="row d-flex justify-content-center pt-3">
            <div class="col-sm-11 p-3 m-1 border border-white notice-text bg-dark">
                <p>
                    This computer system, including all related equipment, networks,and network devices (including Internet access) is provided by the Department of Veterans Affairs (VA) in accordance with the agency policy for official
                            use and limited personal use. All agency computer systems may be monitored for all lawful purposes, including but not limited to, ensuring that use is authorized, for management of the system, to facilitate
                            protection against unauthorized access, and to verify security procedures, survivability and operational security. Any information on this computer system may be examined, recorded, copied and used for authorized
                            purposes at any time. All information, including personal information, placed or sent over this system may be monitored, and users of this system are reminded that such monitoring does occur.
                            Therefore, there should be no expectation of privacy with respect to use of this system. By logging into this agency computer system, you acknowledge and consent to the monitoring of this system.
                            Evidence of your use, authorized or unauthorized, collected during monitoring may be used for civil, criminal, administrative, or other adverse action. Unauthorized or illegal use may subject you to prosecution.
                </p>
                <p class="text-center"><strong>This is a Privacy Act System of Records</strong></p>
                <p>
                    Access to this information is limited to only those who have a need for the information in the performance of their official duties. Disclosure without the consent of the subject of the information is
                            restricted unless required by the Freedom of Information Act; to those listed in an appropriate Federal Register System of Records Notice under the "routine use" section; for the purposes identified in
                            that section; and to those identified in 43 C.F.R. 2.56. These records may not be altered or destroyed except as authorized by 43.C.F.R. 2.52. Please contact your office's Privacy Act Officer for advice on
                            disclosure restrictions.
                </p>
                <p><strong>CRIMINAL PENALTIES FOR DISCLOSURE: </strong>The Privacy Act contains provisions for criminal penalties for knowingly and/or willfully disclosing information from this system unless properly authorized.</p>
            </div>
        </div>
    </div>
</asp:Content>