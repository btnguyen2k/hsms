using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Pupil
{
    public partial class changepass_pupil : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected void ChangePass_Click(object sender, EventArgs e)
        {
            // Kiem tra du lieu nhap co dung hay khong???
            bool cond = true;
            if (Session["login_pass"].ToString().Trim() != OldPass.Text.Trim())
            {
                ResultOldPass.Text = "Mật mã cũ không hợp lệ!!!";
                cond = false;
            }
            else
            {
                ResultOldPass.Text = "";
            }
            if (NewPass.Text.Trim() != NewPassConfirm.Text.Trim())
            {
                ResultNewPass.Text = "Mật mã mới không tương thích!!!";
                cond = false;
            }
            else
            {
                ResultNewPass.Text = "";
            }

            // Thay doi mat ma user
            if (cond)
            {
                // make connection to database
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;

                // change passwprd
                cm.CommandText = "UPDATE HSMSUser SET upassword = '" + NewPass.Text + "' WHERE ulogin_name = '" +
                                 Session["login_id"].ToString().Trim() + "'";
                cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
                conn.Dispose();

                ResultOldPass.Text = "Thay đổi mật mã thành công!!!";
                Session["login_pass"] = NewPass.Text;
            }
        }
    }
}