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
using HSMS.Db;

namespace HSMS.Teacher
{
    public partial class AddExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected void AddNewEx_Click(object sender, EventArgs e)
        {
            if (ImageUpLoad.HasFile)
            {
                ImageUpLoad.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "images\\" + ImageUpLoad.FileName);
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
                    "INSERT INTO HSMSExercise (ExTitle, ExImage, ExNote,  ExFile, ExTeaccherId, ExDateTime) VALUES (N'" + ExTitle.Text
 + "','" + ImageUpLoad.FileName + "',N'" + FreeTextBox1.Text + "',N'" + FileUpLoad1.FileName + "',N'" + Session["login_id"] + "','" + DateTime.Now + "')";

            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            Result.Text = "Thêm bài tập thành công!";
            // NewTitle.Text = "";
            //FreeTextBox1.Text = "";
        }
    }
}
