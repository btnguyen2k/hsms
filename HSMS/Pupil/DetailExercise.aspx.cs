using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using System.Security.AccessControl;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HSMS.Db;

namespace HSMS.Pupil
{
    public partial class DetaiExercisel : System.Web.UI.Page
    {
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            ExTitle.ReadOnly = true;
            FreeTextBox1.ReadOnly = true;
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
                        //string site = AppDomain.CurrentDomain.BaseDirectory + "Files\\" +
                        //              dr["ExImage"].ToString();
                        string site = "http://localhost/hsms/images/" + dr["ExImage"].ToString();
                        ImageEx.Text = "<a href = " + site + ">Download Image</a>";
                    }
                    if (dr["ExFile"].ToString() != null)
                    {
                        string site = AppDomain.CurrentDomain.BaseDirectory + "Files\\" +
                                      dr["ExFile"].ToString();
                        //string site = "http://localhost/hsms/Files/" + dr["ExFile"].ToString();
                        ImageEx.Text = "<a href = " + site + ">Download File</a>";
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

     /*   protected void SubmitSolution_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                // save new file
                FileUpLoad1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "UploadSolutionFiles\\" + FileUpLoad1.FileName);

                // Save to database
                id = Request.QueryString.Get("Exid");
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;

                cm.CommandText =
                    "INSERT INTO HSMSUploadSolution (Exid, Pupil_id, filenam, Time) VALUES (" + id +
                    ",'" + Session["login_id"].ToString() + "',N'" + FileUpLoad1.FileName + "'," + DateTime.Now + ")";

                cm.ExecuteNonQuery();

                cm.Dispose();
                conn.Close();
                conn.Dispose();

                Result.Text = "Nộp bài thành công!";
            }
            else
            {
                Result.Text = "Không có file!";
            }
        } */

        static protected bool CheckExist(string id, string pupilid)
        {
            bool temp = false;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSUploadSolution";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Exid"].ToString().Trim() == id.Trim()
                    && dr["Pupil_id"].ToString().Trim() == pupilid.Trim())
                {
                    temp = true;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                id = Request.QueryString.Get("Exid");
                bool check_exist = CheckExist(id, Session["login_id"].ToString());
                if (check_exist)
                {
                    Result.Text = "Đã nộp rồi, không phải nộp tiếp";
                }
                else
                {
                    // save new file
                    FileUpLoad1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "UploadSolution\\" + FileUpLoad1.FileName);

                    // Save to database
                    OleDbConnection conn = DbUtils.GetSQLDbConnection();
                    conn.Open();
                    OleDbCommand cm = new OleDbCommand();
                    cm.Connection = conn;

                    cm.CommandText =
                        "INSERT INTO HSMSUploadSolution (Exid, Pupil_id, filename, ULDate) VALUES ('" + id +
                        "','" + Session["login_id"].ToString() + "','" + FileUpLoad1.FileName + "','" + DateTime.Now + "')";
                    cm.ExecuteNonQuery();

                    cm.Dispose();
                    conn.Close();
                    conn.Dispose();

                    Result.Text = "Nộp bài thành công!";
                }
            }
            else
            {
                Result.Text = "Không có file!";
            }
        }
    }
}
