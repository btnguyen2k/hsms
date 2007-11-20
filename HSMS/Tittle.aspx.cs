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

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void LoginProcess_Click(object sender, EventArgs e)
        {
            int count = 0;
            String connStr =
                "Provider=SQLNCLI;Server=.\\SQLExpress;AttachDbFilename=|App_Data|hsms.mdf; Database=dbname;Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select ulogin_name," + "upassword From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString() == LoginName.Text) && (dr["upassword"].ToString() == Password.Text))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Response.Redirect("Admin/main_admin.aspx");
            }
            else
            {
                Response.Write("asdasdas");
            }
            dr.Close();
            conn.Close();
        }     
    }
}
