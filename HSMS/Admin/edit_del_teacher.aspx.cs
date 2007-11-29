using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class edit_del_teacher : Page
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
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
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

        protected void Teacher_EditInf_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            // do cm
            cm.CommandText = "UPDATE HSMSUser SET uemail = '" + Teacher_Email.Value + "',ufull_name = '" +
                             Teacher_name.Value + "', udob_day = '" + Teacher_Day.Value + "', udob_mont = '" +
                             Teacher_Month.Value + "', udob_year = '" + Teacher_Year.Value + "' WHERE ulogin_name = '" +
                             Teacher_id.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "UPDATE HSMSTeacher SET subject_id = '" + Teacher_Subject.Value + "',year_start = '" +
                             Teacher_YearStart.Value + "' WHERE teacher_id = '" +
                             Teacher_id.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "UPDATE HSMSClass SET class_id = '" + Teacher_MainClass.Value + "', year = '" +
                             Teacher_MainClass_Year.Value + "' WHERE teacher_id = '" +
                             Teacher_id.Value.Trim() + "'";

            cm.ExecuteNonQuery();

            // close cm
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            Teacher_EditResult.Text = "Cập nhật mới thành công!";
        }

        protected void Teacher_DelInf_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "DELETE FROM HSMSUser WHERE ulogin_name = '" + Teacher_id.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "DELETE FROM HSMSTeacher WHERE teacher_id = '" + Teacher_id.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "DELETE FROM HSMSClass WHERE teacher_id = '" + Teacher_id.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Teacher_EditResult.Text = "Xoá thành công!";
        }
    }
}