using System;
using System.Web.UI;
using HSMS.Bo.Config;
using HSMS.Bo.User;

namespace HSMS
{
    public partial class MasterMain : MasterPage
    {
        public void SetPageHeader(string header)
        {
            PageHeader.Text = header != null ? header.Trim() : ConfigManager.GetSchoolName();
        }

        public void SetLeftMenu(Control control)
        {
            CONTENT_LEFT_MENU.Controls.Add(control);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //SetPageHeader(ConfigManager.GetSchoolName());
            SmallUserNote.Text = "";

            HSMSUser user = UserSessionManager.GetCurrentUser();
            if (user == null)
            {
                //not logged in
                TopMenuSeparatorLogin.Visible = true;
                TopMenuItemLogin.Visible = true;
                TopMenuSeparatorLogout.Visible = false;
                TopMenuItemLogout.Visible = false;
                TopMenuSeparatorMyProfile.Visible = false;
                TopMenuItemMyProfile.Visible = false;
                SmallUserNote.Visible = false;
            }
            else
            {
                //logged in
                TopMenuSeparatorLogin.Visible = false;
                TopMenuItemLogin.Visible = false;
                TopMenuSeparatorLogout.Visible = true;
                TopMenuItemLogout.Visible = true;
                TopMenuSeparatorMyProfile.Visible = true;
                TopMenuItemMyProfile.Visible = true;
                PageHeader.Visible = true;
                SmallUserNote.Text = "Chào bạn <b>" + user.FullName + " (" + user.LoginName + ")</b> | ";
            }

            bool permAdmin = UserManager.HasPermission(user, PermissionConstants.PERMISSION_ADMIN);
            TopMenuSeparatorAdminPage.Visible = permAdmin;
            TopMenuItemAdminPage.Visible = permAdmin;

            bool permTeacher = UserManager.HasPermission(user, PermissionConstants.PERMISSION_TEACHER);
            TopMenuSeparatorTeacherPage.Visible = permTeacher;
            TopMenuItemTeacherPage.Visible = permTeacher;

            bool permPupil = UserManager.HasPermission(user, PermissionConstants.PERMISSION_PUPIL);
            TopMenuSeparatorPupilPage.Visible = permPupil;
            TopMenuItemPupilPage.Visible = permPupil;

            bool permParent = UserManager.HasPermission(user, PermissionConstants.PERMISSION_PARENT);
            TopMenuSeparatorParentPage.Visible = permParent;
            TopMenuItemParentPage.Visible = permParent;
        }
    }
}