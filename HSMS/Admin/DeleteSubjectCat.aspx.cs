using System;
using System.Drawing;
using System.Web.UI;
using HSMS.Bo.Subject;
using HSMS.UI;

namespace HSMS.Admin
{
    public partial class DeleteSubjectCat : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCommon.AdminPage_PageLoad(Page, (MasterMain) Master);

            string subjectCatId = Request.QueryString["id"];
            HSMSSubjectCat subjectCat = SubjectManager.GetSubjectCat(subjectCatId);
            if (subjectCat == null)
            {
                PanelForm.Visible = false;
                DisplayErrorMessage("Không tìm thấy bộ môn với id \"" + subjectCatId + "\"");
            }
            else
            {
                PanelForm.Visible = true;
                DisplayInfoMessage("Bạn có chắc muốn xóa bộ môn \"" + subjectCat.Name + "\"?");
            }
        }

        private void DisplayErrorMessage(string msg)
        {
            Message.Visible = true;
            Message.ForeColor = Color.Red;
            Message.Text = msg;
        }

        private void DisplayInfoMessage(string msg)
        {
            Message.Visible = true;
            Message.ForeColor = Color.Green;
            Message.Text = msg;
        }

        protected void BtnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubjectCatList.aspx");
        }

        protected void BtnYes_Click(object sender, EventArgs e)
        {
            string subjectCatId = Request.QueryString["id"];
            HSMSSubjectCat subjectCat = SubjectManager.GetSubjectCat(subjectCatId);
            if (subjectCat != null)
            {
                Response.Redirect("SubjectCatList.aspx");
            }
        }
    }
}