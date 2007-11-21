using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HSMS.Admin
{
    public partial class change_pass_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
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
                String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                
                // change passwprd
                cm.CommandText = "UPDATE HSMSUser SET upassword = '" + NewPass.Text + "' WHERE ulogin_name = '" +
                                 Session["login_id"].ToString().Trim() +"'";
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
