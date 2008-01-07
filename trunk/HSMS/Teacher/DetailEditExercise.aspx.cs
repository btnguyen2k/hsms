using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Security.AccessControl;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HSMS.Db;
using System.IO;

namespace HSMS.Teacher
{
    public partial class DetailEditExercise : System.Web.UI.Page
    {
        private string id;
        private int id_int;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            } 
            
            id = Request.QueryString.Get("Exid");

            //title = Request.QueryString.Get("title").ToString();
            if (!IsPostBack)
            {
                GetExercise();
            }
        }

        protected void GetExercise()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSExercise";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Exid"].ToString() == id)
                {
                    ExTitle.Text = dr["ExTitle"].ToString();
                    FreeTextBox1.Text = dr["ExNote"].ToString();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected string GetFile (string field)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            id = Request.QueryString.Get("newid");
            cm.CommandText = "Select * from HSMSExercise";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Exid"].ToString() == id)
                {
                    temp = dr[field].ToString();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp;
        }

        protected void AddNewEx_Click(object sender, EventArgs e)
        {
            if (ImageUpLoad.HasFile)
            {
                // delete old file 
                string filename = GetFile("ExImage");
                File.GetAccessControl(AppDomain.CurrentDomain.BaseDirectory + "images\\");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "images\\" + filename);

                //save new file
                ImageUpLoad.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "images\\" + ImageUpLoad.FileName);
            }
            if (FileUpLoad1.HasFile)
            {
                // delete old file
                string filename = GetFile("ExFile");
                FileSecurity security = File.GetAccessControl(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + filename);
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + filename);

                // save new file
                FileUpLoad1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + FileUpLoad1.FileName);
            }

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            id = Request.QueryString.Get("newid");
            Response.Write(id.Trim());
            id_int = Int32.Parse(id);
            cm.CommandText =
                "UPDATE HSMSEercise SET ExTitle = N'" + ExTitle.Text + "', ExImage ='" +
                ImageUpLoad.FileName + "', ExNote = N'" + FreeTextBox1.Text +
                "', NewFile_upload = '" + FileUpLoad1.FileName + "',ExTeaccherId = N'" +
                Session["login_id"] + "', ExDateTime = '" + DateTime.Now + "' WHERE Exid = " +
                id_int;
            cm.ExecuteNonQuery();

            cm.Dispose();
            conn.Close();
            conn.Dispose();

            Result.Text = "Sữa thông báo thành công!";
            //NewTitle.Text = "";
            //FreeTextBox1.Text = "";
        }

    }
}
