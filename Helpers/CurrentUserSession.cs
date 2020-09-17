using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Helpers
{
    public class CurrentUserSession
    {
        private static HttpContextAccessor _HttpContextAccessor = new HttpContextAccessor();

        public static CurrentUser User
        {
            get
            {
                CurrentUser User = _HttpContextAccessor.HttpContext.Session.GetObject<CurrentUser>("CurrentUser");
                return User;
            }
            set
            {
                _HttpContextAccessor.HttpContext.Session.SetObject("CurrentUser", value);
            }
        }

       

        public static int UserID
        {
            get
            {
                if (User != null)
                    return User.UserID;
                else
                    return -1;
            }
        }

        public static int RoleID
        {
            get
            {
                if (User != null)
                    return User.RoleID;
                else
                    return -1;
            }
        }

        public static string FirstName
        {
            get
            {
                if (User != null)
                    return User.Name;
                else
                    return string.Empty;
            }
        }

      
        public static string UserName
        {
            get
            {
                if (User != null)
                    return User.UserName;
                else
                    return string.Empty;
            }
        }

        public static string Email
        {
            get
            {
                if (User != null)
                    return User.Email;
                else
                    return string.Empty;
            }
        }
       
        public static bool IsAdminRole
        {
            get
            {
                if (User != null)
                    return User.IsAdminRole;
                else
                    return false;
            }
        }

        
    }

    [Serializable]
    public class CurrentUser
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdminRole { get; set; }
    }
}

