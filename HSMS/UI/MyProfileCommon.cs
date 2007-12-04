using System.Web;
using System.Web.UI;
using HSMS.Bo.Config;
using HSMS.Bo.User;

namespace HSMS.UI
{
    public class MyProfileCommon
    {
        public static void MyProfilePage_PageLoad(Page page, MasterMain master)
        {
            HttpResponse response = page.Response;

            HSMSUser user = UserSessionManager.GetCurrentUser();
            if (user == null)
            {
                response.Redirect("~/Login.aspx");
                return;
            }
            page.Title = ConfigManager.GetSchoolName() + " - Trang Cá Nhân";
            master.SetPageHeader("Trang Cá Nhân");

            master.SetLeftMenu(page.LoadControl("Inc_LeftMenu.ascx"));
        }
    }
}