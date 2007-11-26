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

namespace HSMS.Admin
{
    public partial class edit_del_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            Information.Visible = false;
            Teacher_DelInf.Visible = false;
            Teacher_EditInf.Visible = false;
            TeacherFindResultText.Text = "";
            Teacher_EditResult.Text = "";
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Find_Teacher_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == Teacher_FindId.Text.Trim()))
                {
                    Teacher_name.Value = dr["ufull_name"].ToString().Trim();
                    Teacher_Day.Value = dr["udob_day"].ToString().Trim();
                    Teacher_Month.Value = dr["udob_mont"].ToString().Trim();
                    Teacher_Year.Value = dr["udob_year"].ToString().Trim();
                    Teacher_id.Value = dr["ulogin_name"].ToString().Trim();
                    Teacher_Email.Value = dr["uemail"].ToString().Trim();

                    OleDbCommand cm1 = new OleDbCommand();
                    cm1.Connection = conn;
                    cm1.CommandText = "Select * FROM HSMSTeacher";
                    OleDbDataReader dr1 = cm1.ExecuteReader();
                    while (dr1.Read())
                    {
                        if (dr1["teacher_id"].ToString().Trim() == Teacher_FindId.Text.Trim())
                        {
                            Teacher_Subject.Value = dr1["subject_id"].ToString().Trim();
                            Teacher_YearStart.Value = dr1["year_start"].ToString().Trim();
                        }
                    }
                    
                    dr1.Dispose();
                    dr1.Close();
                    cm1.Dispose();

                    cm1 = new OleDbCommand();
                    cm1.Connection = conn;
                    cm1.CommandText = "Select * FROM HSMSClass";
                    dr1 = cm1.ExecuteReader();
                    while (dr1.Read())
                    {
                        if (dr1["teacher_id"].ToString().Trim() == Teacher_FindId.Text.Trim())
                        {
                            Teacher_MainClass.Value = dr1["class_id"].ToString().Trim();
                            Teacher_MainClass_Year.Value = dr1["year"].ToString().Trim();
                        }
                    }
                    dr1.Dispose();
                    dr1.Close();
                    cm1.Dispose();

                    Information.Visible = true;
                    Teacher_DelInf.Visible = true;
                    Teacher_EditInf.Visible = true;
                    TeacherFindResultText.Text = "";
                }
                else
                {
                    TeacherFindResultText.Text = "Tìm không thấy dữ liệu";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Teacher_FindId.Text = null;
        }
    }
}
