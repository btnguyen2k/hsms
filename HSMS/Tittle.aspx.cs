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
using System.Data.SqlClient;

namespace HSMS
{
    public partial class Tittle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 5;
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void LoginProcess_Click(object sender, EventArgs e)
        {
            int count = 0;
            
            // Trang thai chua login
            Session["login_state"] = "not_login";

            //String connStr =
            //    "Provider=SQLNCLI;Server=.\\SQLExpress;AttachDbFilename=C:\\Inetpub\\wwwroot\\HSMS\\App_Data\\hsms.mdf; Database=dbname;Trusted_Connection=Yes;";
            
            // Make connection to databse
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            conn.Open();

            // Access database
            cm.CommandText = "Select ulogin_name," + "upassword From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == LoginName.Text) && (dr["upassword"].ToString().Trim() == Password.Text))
                {
                    count++;
                }
            }
            dr.Close();
            conn.Close();
            if (count > 0)
            {
                // Luu trang thai login
                Session["login_id"] = LoginName.Text;
                Session["login_pass"] = Password.Text;
                Session["login_state"] = "login";

                Session.Timeout = 60;
                Response.Redirect("Admin/main_admin.aspx");
            }
            else
            {
                Response.Write("asdasdas");
            }
            
        }     
    }
}
