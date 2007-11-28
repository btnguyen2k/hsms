using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HSMS.Teacher
{
    public partial class change_pass_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
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
                String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
                OleDbConnection conn = new OleDbConnection(connStr);
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
