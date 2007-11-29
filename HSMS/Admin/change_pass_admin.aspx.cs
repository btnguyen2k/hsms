using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class change_pass_admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        protected void ChangePass_Click(object sender, EventArgs e)
        {
            // Kiem tra du lieu nhap co dung hay khong???
            bool cond = true;
            if (Session["login_pass"].ToString().Trim() != OldPass.Text.Trim())
            {
                lbOldPass.Text = "Mật mã cũ không hợp lệ!!!";
                cond = false;
            }
            else
            {
                lbOldPass.Text = "";
            }
            if (NewPass.Text.Trim() != NewPass_Confirm.Text.Trim())
            {
                lbNewPass.Text = "Mật mã mới không tương thích!!!";
                cond = false;
            }
            else
            {
                lbNewPass.Text = "";
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

                lbOldPass.Text = "Thay đổi mật mã thành công!!!";
                Session["login_pass"] = NewPass.Text;
            }
        }
    }
}