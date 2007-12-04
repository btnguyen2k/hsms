using System.Web;
using System.Web.SessionState;

namespace HSMS.Bo.User
{
    public class UserSessionManager
    {
        public const string SESSION_CURRENT_USER = "CURRENT_USER";
        //public const string SESSION_CURRENT_USER_ID = "CURRENT_USER_ID";

        public static void Logout()
        {
            HttpSessionState session = HttpContext.Current.Session;
            session[SESSION_CURRENT_USER] = null;
            //session[SESSION_CURRENT_USER_ID] = null;
        }

        public static bool Login(string loginname, string password)
        {
            if (loginname == null || loginname.Trim().Length == 0 || password == null || password.Trim().Length == 0)
            {
                return false;
            }
            HSMSUser user = UserManager.GetUser(loginname);
            if (user == null)
            {
                return false;
            }
            if (user.Authenticate(password))
            {
                HttpSessionState session = HttpContext.Current.Session;
                session[SESSION_CURRENT_USER] = user;
                //session[SESSION_CURRENT_USER_ID] = user.Id;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the currently logged in user.
        /// </summary>
        /// <returns></returns>
        public static HSMSUser GetCurrentUser()
        {
            HttpSessionState session = HttpContext.Current.Session;
            return session[SESSION_CURRENT_USER] as HSMSUser;
            /*
            if ( session[SESSION_CURRENT_USER_ID] == null ) return null;
            int userId = (int) session[SESSION_CURRENT_USER_ID];
            return UserManager.GetUser(userId);
            */
        }
    }
}