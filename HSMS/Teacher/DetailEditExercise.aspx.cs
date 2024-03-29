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
                    if (dr["ExImage"].ToString() != null)
                    {
                    
                    }
                    if (dr["ExFile"].ToString() != null)
                    {
                    
                    }
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

            id = Request.QueryString.Get("Exid");
            cm.CommandText = "Select * from HSMSExercise";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Exid"].ToString().Trim() == id.Trim())
                {
                    temp = dr[field].ToString();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp.Trim();
        }

        protected void AddNewEx_Click(object sender, EventArgs e)
        {
            if (ImageUpLoad.HasFile)
            {
                // delete old file 
                string filename = GetFile("ExImage");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "images\\" + filename);

                //save new file
                ImageUpLoad.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "images\\" + ImageUpLoad.FileName);
            }
            if (FileUpLoad1.HasFile)
            {
                // delete old file
                string filename = GetFile("ExFile");
                //Response.Write(filename);
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + filename);

                // save new file
                FileUpLoad1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + FileUpLoad1.FileName);
            }

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            id = Request.QueryString.Get("Exid");
            id_int = Int32.Parse(id);
            cm.CommandText =
                "UPDATE HSMSExercise SET ExTitle = N'" + ExTitle.Text + "', ExImage ='" +
                ImageUpLoad.FileName + "', ExNote = N'" + FreeTextBox1.Text +
                "', ExFile = '" + FileUpLoad1.FileName + "',ExTeaccherId = N'" +
                Session["login_id"] + "', ExDateTime = '" + DateTime.Now + "' WHERE Exid = " +
                id_int;
            cm.ExecuteNonQuery();

            cm.Dispose();
            conn.Close();
            conn.Dispose();

            Result.Text = "Sữa bài tập thành công!";
            //NewTitle.Text = "";
            //FreeTextBox1.Text = "";
        }

        static protected void DeleteFolder(int id_ex, string Folder, string SrcData)
        {
            string temp = "";
            if (SrcData == "HSMSExercise")
            {
                if (Folder == "images\\")
                {
                    temp = "ExImage";
                }
                else
                {
                    temp = "ExFile";
                }
            }
            else
            {
                temp = "filename";
            }
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from " + SrcData;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string exid = dr["Exid"].ToString();
                object file = dr[temp];
                if (exid.Trim() == id_ex.ToString().Trim() && file != null)
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + Folder + file.ToString());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void DeleteExercise_Click(object sender, EventArgs e)
        {
            id = Request.QueryString.Get("Exid");
            id_int = Int32.Parse(id);
            
            //delete file from folder images, Files and UpLoadSolution
            DeleteFolder(id_int, "images\\", "HSMSExercise");
            DeleteFolder(id_int, "Files\\", "HSMSExercise");
            DeleteFolder(id_int, "UploadSolution\\", "HSMSUploadSolution");

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            
            //delete data from HSMSExercise
            cm.CommandText = "Delete from HSMSExercise where Exid =" + id_int;
            cm.ExecuteNonQuery();
            // delete data from HSMSUploadSolution
            cm.CommandText = "Delete from HSMSUploadSolution where Exid =" + id_int;
            cm.ExecuteNonQuery();
            
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            
            Result.Text = "xoá bài tập thành công!";
            ExTitle.Text = "";
            FreeTextBox1.Text = "";
        }

    }
}
