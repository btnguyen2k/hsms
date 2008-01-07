using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected void NewSave_Click(object sender, EventArgs e)
        {
            if (ImageUpLoad.HasFile)
            {
                ImageUpLoad.SaveAs(@"~\images\" + ImageUpLoad.FileName);
            }
            if (FileUpLoad1.HasFile)
            {
                FileUpLoad1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + FileUpLoad1.FileName);
                //FileUpLoad1.SaveAs("C:\\Inetpub\\wwwroot\\HSMS\\Files\\" + FileUpLoad1.FileName);
            }

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            
            cm.CommandText =
                    "INSERT INTO HSMSNews (title, image, NewContent, NewFile_upload, Userid, Time) VALUES (N'" + NewTitle.Text
 + "','" + ImageUpLoad.FileName + "',N'" + FreeTextBox1.Text + "',N'" + FileUpLoad1.FileName + "',N'" + Session["login_id"] +"','"  + DateTime.Now +"')";

            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            ResultAction.Text = "Thêm thông báo thành công!";
            // NewTitle.Text = "";
            //FreeTextBox1.Text = "";
        }
    }
}
