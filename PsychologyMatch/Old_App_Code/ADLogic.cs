using System;
using System.DirectoryServices.AccountManagement;

namespace PsychMatch
{
    /// <summary>
    /// Summary description for ADLogic
    /// </summary>
    public class ADLogic
    {
        public enum ADProperty
        {
            FullName,
            FirstName,
            MiddleName,
            LastName,
            DisplayName,
            Phone,
            Email,
            SamAccountName
        };

        public void Approvals()
        {
        }
        public bool CheckGroupMembership()
        {
            System.Security.Principal.WindowsIdentity MyIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal MyPrincipal = new System.Security.Principal.WindowsPrincipal(MyIdentity);

            return MyPrincipal.IsInRole("VHA WMC TAPS Users") ? true : false;
        }

        public bool IsInGroup(string user, string group)
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
            GroupPrincipal groupStatus = GroupPrincipal.FindByIdentity(principalContext, "VHA WMC TAPS Users");

            foreach (Principal principal in groupStatus.Members)
            {
                string name = principal.UserPrincipalName;
                if (name.ToLower() == user)
                {
                    return true;
                }
            }
           
            return false;
        }


        public static string GetADUserProperty(string username, ADProperty adpropertypassed)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain, GetDomain(username)))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {

                    if (adpropertypassed == ADProperty.FirstName)
                    {
                        return up != null && !String.IsNullOrEmpty(up.GivenName) ? up.GivenName : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.MiddleName)
                    {
                        return up != null && !String.IsNullOrEmpty(up.MiddleName) ? up.MiddleName : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.LastName)
                    {
                        return up != null && !String.IsNullOrEmpty(up.Surname) ? up.Surname : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.FullName)
                    {
                        return up != null && !String.IsNullOrEmpty(up.Name) ? up.Name : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.DisplayName)
                    {
                        return up != null && !String.IsNullOrEmpty(up.DisplayName) ? up.DisplayName : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.Phone)
                    {
                        return up != null && !String.IsNullOrEmpty(up.VoiceTelephoneNumber) ? up.VoiceTelephoneNumber : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.Email)
                    {
                        return up != null && !String.IsNullOrEmpty(up.EmailAddress) ? up.EmailAddress : string.Empty;
                    }
                    if (adpropertypassed == ADProperty.SamAccountName)
                    {
                        return up != null && !String.IsNullOrEmpty(up.SamAccountName) ? up.SamAccountName : string.Empty;
                    }

                    

                    return string.Empty;
                }

            }
        }

        public static string GetADUserEmailAddress(string username)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain, GetDomain(username)))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {
                    if (up != null)
                    {
                        return up.EmailAddress;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }


        public static string GetADUserFullName(string username)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain, GetDomain(username)))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {
                    return up != null && !String.IsNullOrEmpty(up.Name) ? up.Name : string.Empty;
                }
            }
        }

        public static string GetADUserFirstName(string username)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain, GetDomain(username)))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {
                    return up != null && !String.IsNullOrEmpty(up.GivenName) ? up.GivenName : string.Empty;
                }

            }
        }

        public static string GetADUserDisplayName(string username)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain, GetDomain(username)))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {
                    return up != null && !String.IsNullOrEmpty(up.DisplayName) ? up.DisplayName : string.Empty;
                }

            }
        }

        public static string GetADUserPhone(string username)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain, GetDomain(username)))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {
                    return up != null && !String.IsNullOrEmpty(up.VoiceTelephoneNumber) ? up.VoiceTelephoneNumber : string.Empty;
                }

            }
        }

        public static string GetDomain(string s)
        {
            string domainSearch;
            int stop = s.IndexOf("\\");
            if (stop > -1)
            {

                switch (s.Substring(0, stop).ToLower())
                {
                    case "vha":
                        domainSearch = "vha.med.va.gov";
                        break;
                    case "vhamaster":
                        domainSearch = "vha.med.va.gov";
                        break;
                    case "dva":
                        domainSearch = "dva.va.gov";
                        break;
                    case "vba":
                        domainSearch = "vba.va.gov";
                        break;
                    case "nca":
                        domainSearch = "cem.va.gov";
                        break;
                    case "vha01":
                        domainSearch = "v01.med.va.gov";
                        break;
                    case "vha02":
                        domainSearch = "v02.med.va.gov";
                        break;
                    case "vha03":
                        domainSearch = "v03.med.va.gov";
                        break;
                    case "vha04":
                        domainSearch = "v04.med.va.gov";
                        break;
                    case "vha05":
                        domainSearch = "v05.med.va.gov";
                        break;
                    case "vha06":
                        domainSearch = "v06.med.va.gov";
                        break;
                    case "vha07":
                        domainSearch = "v07.med.va.gov";
                        break;
                    case "vha08":
                        domainSearch = "v08.med.va.gov";
                        break;
                    case "vha09":
                        domainSearch = "v09.med.va.gov";
                        break;
                    case "vha10":
                        domainSearch = "v10.med.va.gov";
                        break;
                    case "vha11":
                        domainSearch = "v11.med.va.gov";
                        break;
                    case "vha12":
                        domainSearch = "v12.med.va.gov";
                        break;
                    case "vha13":
                        domainSearch = "v13.med.va.gov";
                        break;
                    case "vha14":
                        domainSearch = "v14.med.va.gov";
                        break;
                    case "vha15":
                        domainSearch = "v15.med.va.gov";
                        break;
                    case "vha16":
                        domainSearch = "v16.med.va.gov";
                        break;
                    case "vha17":
                        domainSearch = "v17.med.va.gov";
                        break;
                    case "vha18":
                        domainSearch = "v18.med.va.gov";
                        break;
                    case "vha19":
                        domainSearch = "v19.med.va.gov";
                        break;
                    case "vha20":
                        domainSearch = "v20.med.va.gov";
                        break;
                    case "vha21":
                        domainSearch = "v21.med.va.gov";
                        break;
                    case "vha22":
                        domainSearch = "v22.med.va.gov";
                        break;
                    case "vha23":
                        domainSearch = "v23.med.va.gov";
                        break;

                    default:
                        domainSearch = "vha.med.va.gov";
                        break;

                }

                return domainSearch;
            }
            else
            {
                return "";
            }


        }


    }
    
}