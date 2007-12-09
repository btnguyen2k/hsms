using System.Web;
using System.Web.UI;
using HSMS.Bo.Config;
using HSMS.Bo.User;

namespace HSMS.UI
{
    public class AdminCommon
    {
        public static void AdminPage_PageLoad(Page page, MasterMain master)
        {
            HttpResponse response = page.Response;

            HSMSUser user = UserSessionManager.GetCurrentUser();
            if (user == null || !UserManager.HasPermission(user, PermissionConstants.PERMISSION_ADMIN))
            {
                response.Redirect("~/Login.aspx");
                return;
            }
            page.Title = ConfigManager.GetSchoolName() + " - Trang Admin";
            master.SetPageHeader("Trang Admin");

            master.SetLeftMenu(page.LoadControl("Inc_LeftMenu.ascx"));
        }
    }
}