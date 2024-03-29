using System;
using System.Web.UI;
using HSMS.Bo.Config;
using HSMS.Bo.User;

namespace HSMS
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HSMSConfig config = ConfigManager.GetConfig(ConfigManager.CONFIG_NAME_SCHOOL_NAME);
            Page.Title = (config != null ? config.Value : "") + " - Đăng Nhập";
            PageHeader.Text = config != null ? config.Value : "";
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (UserSessionManager.Login(InputLoginName.Value, InputPassword.Value))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ErrorMessage.Text = "Sai tên đăng nhập hoặc mật mã!";
                ErrorMessage.Visible = true;
            }
        }
    }
}