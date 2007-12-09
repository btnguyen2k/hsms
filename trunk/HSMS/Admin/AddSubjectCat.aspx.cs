using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using HSMS.Bo.Subject;
using HSMS.UI;

namespace HSMS.Admin
{
    public partial class AddSubjectCat : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCommon.AdminPage_PageLoad(Page, (MasterMain) Master);
        }

        protected void BtnCreateSubjectCat_Click(object sender, EventArgs e)
        {
            Regex regExp = new Regex("[\\w_]{1,10}");
            string id = InputSubjectCatId.Text.Trim().ToLower();
            string name = InputSubjectCatName.Text.Trim();
            string desc = InputSubjectCatDesc.Text.Trim();

            if (id.Length == 0)
            {
                ErrorMessage.Text = "Vui lòng nhập vào ID của bộ môn!";
            }
            else if (name.Length == 0)
            {
                ErrorMessage.Text = "Vui lòng nhập vào ID của bộ môn!";
            }
            else if (!regExp.IsMatch(id))
            {
                ErrorMessage.Text = "ID bộ môn không được chứa ký tự đặc biệt hoặc khoảng trắng!";
            }
            else if (SubjectManager.GetSubjectCat(id) != null)
            {
                ErrorMessage.Text = "Bộ môn với ID [" + id + "] đã tồn tại, vui lòng nhập vào ID khác!";
            }
            else
            {
                SubjectManager.CreateSubjectCat(id, name, desc);
                Response.Redirect("SubjectCatList.aspx");
            }
        }
    }
}