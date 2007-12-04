using System;
using System.Web.UI;
using HSMS.Bo.Config;
using HSMS.Bo.User;

namespace HSMS
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = ConfigManager.GetSchoolName() + " - Đăng Xuất";
            Message.Text = "Đăng xuất thành công, xin vui lòng chờ đợi giây lát...";
            //MetaRedirect.Content = "1;Default.aspx"; //chờ 1 giây & quay về trang Default.aspx
            UserSessionManager.Logout();
            //Response.Redirect("~/Default.aspx");
        }
    }
}