using System;
using System.Web.UI;
using HSMS.Bo.User;
using HSMS.UI;

namespace HSMS.MyProfile
{
    public partial class ChangePassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyProfileCommon.MyProfilePage_PageLoad(Page, (MasterMain) Master);
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            HSMSUser user = UserSessionManager.GetCurrentUser();
            string currentPassword = InputOldPassword.Value.Trim();
            if ( !user.Authenticate(currentPassword) )
            {
                SetErrorMessage("Mật mã cũ không khớp!");
                return;
            }

            string newPassword = InputNewPassword.Value.Trim();
            if ( newPassword.Length == 0 )
            {
                SetErrorMessage("Vui lòng nhập vào mật mã mới!");
                return;
            }

            string newPassword2 = InputNewPassword2.Value.Trim();
            if (newPassword != newPassword2)
            {
                SetErrorMessage("Mật mã mới 2 lần nhập không khớp nhau!");
                return;
            }

            UserManager.ChangeUserPassword(user, newPassword);
            SetInfoMessage("Mật mã đã đổi thành công!");
        }

        private void SetErrorMessage(string msg)
        {
            Message.ForeColor = System.Drawing.Color.Red;
            Message.Text = msg;
            Message.Visible = true;
        }

        private void SetInfoMessage(string msg)
        {
            Message.ForeColor = System.Drawing.Color.Green;
            Message.Text = msg;
            Message.Visible = true;
        }
    }
}