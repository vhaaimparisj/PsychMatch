using System;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>


namespace PsychMatch
{
    public class User
    {
        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string UserID
        {
            get
            {

                try
                {
                    return HttpContext.Current.Request.Cookies["UserID"].Value.Santize();
                }
                catch (Exception)
                {
                    return "0";
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["UserID"].Value = value.Santize();
                HttpContext.Current.Response.Cookies["UserID"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["UserID"].Secure = true;
            }
        }

        public static string FullName
        {
            get { return HttpContext.Current.Request.Cookies["FullName"].Value.Santize(); }
            set
            {
                HttpContext.Current.Response.Cookies["FullName"].Value = value.Santize();
                HttpContext.Current.Response.Cookies["FullName"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["FullName"].Secure = true;
            }
        }


        public static string Email
        {
            get { return HttpContext.Current.Request.Cookies["Email"].Value.Santize(); }
            set { 
                HttpContext.Current.Response.Cookies["Email"].Value = value.Santize();
                HttpContext.Current.Response.Cookies["Email"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["Email"].Secure = true;
            }
        }

        public static string TotalAllowedPositions
        {
            get { return HttpContext.Current.Request.Cookies["TotalAllowedPositions"].Value.Santize(); }
            set
            {
                HttpContext.Current.Response.Cookies["TotalAllowedPositions"].Value = value.Santize();
                HttpContext.Current.Response.Cookies["TotalAllowedPositions"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["TotalAllowedPositions"].Secure = true;
            }
        }

        public static bool IsApproved
        {
            get
            {
                bool isApproved = false;
                bool.TryParse( HttpContext.Current.Request.Cookies["IsApproved"].Value, out isApproved);
                return isApproved;
            }
            set
            {
                HttpContext.Current.Response.Cookies["IsApproved"].Value = value.ToString();
                HttpContext.Current.Response.Cookies["IsApproved"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["IsApproved"].Secure = true;
            }

        }

        public static bool IsActive
        {
            get
            {
                bool isActive = false;
                bool.TryParse(HttpContext.Current.Request.Cookies["IsActive"].Value, out isActive);
                return isActive;
            }
            set
            {
                HttpContext.Current.Response.Cookies["IsActive"].Value = value.ToString();
                HttpContext.Current.Response.Cookies["IsActive"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["IsActive"].Secure = true;
            }
        }

        public static bool IsAdmin
        {
            get
            {
                bool IsAdmin = false;
                bool.TryParse(HttpContext.Current.Request.Cookies["IsAdmin"].Value, out IsAdmin);
                return IsAdmin;
            }
            set
            {
                HttpContext.Current.Response.Cookies["IsAdmin"].Value = value.ToString();
                HttpContext.Current.Response.Cookies["IsAdmin"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["IsAdmin"].Secure = true;
            }
        }

        public static string SelectedFacilityId
        {
            get { return HttpContext.Current.Request.Cookies["SelectedFacilityID"].Value.Santize(); }
            set
            {
                HttpContext.Current.Response.Cookies["SelectedFacilityID"].Value = value.Santize();
                HttpContext.Current.Response.Cookies["SelectedFacilityID"].HttpOnly = true;
                HttpContext.Current.Response.Cookies["FaciliSelectedFacilityIDtyID"].Secure = true;
            }
        }

        public static bool HasSession { get; set; }
        

    }
}
