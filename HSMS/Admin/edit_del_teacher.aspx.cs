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
                Response.Redirect("~/main.aspx");
            }
            Information.Visible = false;
            Teacher_DelInf.Visible = false;
            Teacher_EditInf.Visible = false;
            TeacherFindResultText.Text = "";
            Teacher_EditResult.Text = "";
            if (!IsPostBack)
            {
                GetTeacherList();
                GetSubjectList();
            }
        }

        protected void GetSubjectList()
        {
            SubjectList.Items.Add("");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                SubjectList.Items.Add(dr["subject_name"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void GetTeacherList()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSTeacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Teacher_FindId.Items.Add(dr["teacher_id"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
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
                            HistoryTeacher.Text = dr1["history"].ToString();
                            Position.Text = dr1["Position"].ToString();
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
                    HistoryTeacher.Visible = true;
                    Label15.Visible = true;
                    Label3.Visible = true;
                    Label4.Visible = true;
                    Label5.Visible = true;
                    Position.Visible = true;
                    HyperLink1.Visible = true;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Teacher_FindId.Enabled = false;
        }

        protected void Teacher_EditInf_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;

                // do cm
                cm.CommandText = "UPDATE HSMSUser SET uemail = '" + Teacher_Email.Value + "',ufull_name = '" +
                                 Teacher_name.Value + "', udob_day = '" + Teacher_Day.Value + "', udob_mont = '" +
                                 Teacher_Month.Value + "', udob_year = '" + Teacher_Year.Value +
                                 "' WHERE ulogin_name = '" +
                                 Teacher_id.Value.Trim() + "'";
                cm.ExecuteNonQuery();

                cm.CommandText = "UPDATE HSMSTeacher SET subject_id = '" + Teacher_Subject.Value + "',year_start = '" +
                                 Teacher_YearStart.Value + "',history = '" + HistoryTeacher.Text + "',position = '" +
                                 Position.Text +
                                 "' WHERE teacher_id = '" +
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
                Teacher_FindId.Enabled = true;
                Label4.Visible = false;
                Label5.Visible = false;
                Label3.Visible = false;
                Position.Visible = false;
                HistoryTeacher.Visible = false;
                Label15.Visible = false;
                HyperLink1.Visible = false;
            }
            else
            {
                Find_Teacher_Click(sender, e);
                Teacher_EditResult.Text = "Thông tin nhập vào không hợp lệ";
            }
        }

        protected void Teacher_DelInf_Click(object sender, EventArgs e)
        {
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
            Teacher_FindId.Enabled = true;
            Label4.Visible = false;
            Label5.Visible = false;
            Label3.Visible = false;
            Position.Visible = false;
            HistoryTeacher.Visible = false;
            Label15.Visible = false;
            HyperLink1.Visible = false;
        }

        protected bool CheckSubject(string subject)
        {
            bool temp = true;
            if (subject == "")
            {
                temp = false;
                Teacher_EditResult.Text += "Môn học chưa nhập!!!<br>";
            }
            else
            {
                int count = 0;
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "Select * From HSMSSubject";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["subject_name"].ToString().Trim() == subject)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    temp = false;
                    Teacher_Subject.Value = "";
                    Teacher_EditResult.Text += "Tên môn học không chính xác<br>";
                }
                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return temp;
        }

        protected bool CheckClass(string name, string year)
        {
            bool temp = true;
            if (name == "" && year == "")
            {
                Teacher_EditResult.Text += "Chưa nhập lớp học!!!<br>";
            }
            else
            {
                int count = 0;
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "Select * From HSMSClass";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == name
                        && dr["year"].ToString().Trim() == year)
                    {
                        count++;
                        object temp_id = dr["teacher_id"];
                        if (temp_id.ToString().Trim() != ""
                            && temp_id.ToString().Trim() != Teacher_FindId.SelectedItem.Value.Trim())
                        {
                            temp = false;
                            Teacher_MainClass.Value = "";
                            Teacher_MainClass_Year.Value = "";
                            Teacher_EditResult.Text += "Lớp này đã có gvcn<br>";
                        }
                    }
                }
                if (count == 0)
                {
                    temp = false;
                    Teacher_MainClass.Value = "";
                    Teacher_MainClass_Year.Value = "";
                    Teacher_EditResult.Text += "Không có lớp học này<br>";
                }
                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return temp;
        }

        protected bool CheckID(string id)
        {
            bool temp = true;
            if (Teacher_id.Value == "")
            {
                temp = false;
                Teacher_EditResult.Text += "Không có MSGV!!!";
            }
            else
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "Select * From HSMSUser";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["ulogin_name"].ToString().Trim() == id)
                    {
                        temp = false;
                        Teacher_id.Value = "";
                        Teacher_EditResult.Text += "Đã có MSGV này<br>";
                    }
                }

                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return temp;
        }

        protected bool VerifyData()
        {
            bool temp = true;
            Teacher_EditResult.Text = "";
            if (Teacher_name.Value == "")
            {
                Teacher_EditResult.Text = "Tên giáo viên chưa có!!! <br>";
            }

            int Intvalue;
            if (Int32.TryParse(Teacher_Day.Value, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 31)
                {
                    Teacher_EditResult.Text += "Ngày sinh không hợp lệ!<br>";
                    temp = false;
                    Teacher_Day.Value = "";
                }
            }
            else
            {
                Teacher_EditResult.Text += "Ngày sinh không hợp lệ!<br>";
                temp = false;
                Teacher_Day.Value = "";
            }

            if (Int32.TryParse(Teacher_Month.Value, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 12)
                {
                    Teacher_EditResult.Text += "Tháng sinh không hợp lệ!<br>";
                    temp = false;
                    Teacher_Month.Value = "";
                }
            }
            else
            {
                Teacher_EditResult.Text += "Tháng sinh không hợp lệ!<br>";
                temp = false;
                Teacher_Month.Value = "";
            }

            if (Int32.TryParse(Teacher_Year.Value, out Intvalue))
            {
                if (Intvalue < 1900)
                {
                    Teacher_EditResult.Text += "Năm sinh không hợp lệ!<br>";
                    temp = false;
                    Teacher_Year.Value = "";
                }
            }
            else
            {
                Teacher_EditResult.Text += "Năm sinh không hợp lệ!<br>";
                temp = false;
                Teacher_Year.Value = "";
            }


            if (Int32.TryParse(Teacher_YearStart.Value, out Intvalue))
            {
                if (Intvalue < 1990)
                {
                    Teacher_EditResult.Text += "Năm giảng dạy không hợp lệ!<br>";
                    temp = false;
                    Teacher_YearStart.Value = "";
                }
            }
            else
            {
                Teacher_EditResult.Text += "Năm giảng dạy không hợp lệ!<br>";
                temp = false;
                Teacher_YearStart.Value = "";
            }

            bool check_subject = CheckSubject(Teacher_Subject.Value);
            if (!check_subject)
            {
                temp = false;
            }

            bool check_class = CheckClass(Teacher_MainClass.Value, Teacher_MainClass_Year.Value);
            if (!check_class)
            {
                temp = false;
            }

            bool check_id = CheckID(Teacher_id.Value);
            if (!check_class)
            {
                temp = false;
            }

            return temp;
        }

        protected void GetTeacherListDetail(string subjectname)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSTeacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["subject_id"].ToString().Trim() == subjectname.Trim())
                {
                    Teacher_FindId.Items.Add(dr["teacher_id"].ToString());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void SubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher_FindId.Items.Clear();
            if (SubjectList.SelectedItem.Value != "")
            {
                GetTeacherListDetail(SubjectList.SelectedItem.Value.Trim());
            }
            else
            {
                GetTeacherList();
            }
        }
    }
}