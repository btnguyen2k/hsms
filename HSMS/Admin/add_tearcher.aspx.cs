using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class add_tearcher : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            Add_Result.Text = "";
        }

        protected void ViewClassList_Click(object sender, EventArgs e)
        {
            Add_Result.Text = "<table width=50% border=\"1\"> <tr> <td align=center>Lớp</td> <td align=center>Năm</td><td align=center>MS GVCN</td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
               if (dr["teacher_id"].ToString().Trim() == "")
               {
                   Add_Result.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                      "<td align=center style=\"color:black\"> " + dr["year"].ToString().Trim() + "<td align=center style=\"color:black\">X</td>" +
                      "</tr>";
               }
               else
               {
                   Add_Result.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                       "<td align=center style=\"color:black\"> " + dr["year"].ToString().Trim() + 
                       "<td align=center style=\"color:black\"> " + dr["teacher_id"].ToString().Trim() + "</tr>";
               }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Add_Result.Text += "</table>";
        }

        protected void ViewSubjectList_Click(object sender, EventArgs e)
        {
            Add_Result.Text =
                 "<table width=100% border=\"1\"> <tr> <td align=center>Môn học</td> <td align=center>Hệ số</td></tr>";


            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Add_Result.Text += "<tr><td align=center style=\"color:black\">" +
                                        dr["subject_name"].ToString().Trim() +
                                        "</td><td align=center style=\"color:black\">" +
                                        dr["subject_heso"].ToString().Trim() + "</td></tr>";
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            Add_Result.Text += "</table>";
        }
        
        protected bool CheckSubject(string subject)
        {
            bool temp = true;
            if (subject == "")
            {
                temp = false;
                Add_Result.Text += "Môn học chưa nhập!!!<br>";
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
                if (count==0)
                {
                    temp = false;
                    Teacher_Subject.Value = "";
                    Add_Result.Text += "Tên môn học không chính xác<br>";
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
            if (name == "" && year == "" )
            {
                Add_Result.Text += "Chưa nhập lớp học!!!<br>";
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
                        if (dr["teacher_id"].ToString().Trim() != "")
                        {
                            temp = false;
                            Teacher_MainClass.Value = "";
                            Teacher_MainClass_Year.Value = "";
                            Add_Result.Text += "Lớp này đã có gvcn<br>";
                        }
                    }
                }
                if (count == 0)
                {
                    temp = false;
                    Teacher_MainClass.Value = "";
                    Teacher_MainClass_Year.Value = "";
                    Add_Result.Text += "Không có lớp học này<br>";
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
                Add_Result.Text += "Không có MSGV!!!";
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
                        Add_Result.Text += "Đã có MSGV này<br>";
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
            Add_Result.Text = "";
            if (Teacher_name.Value == "")
            {
                Add_Result.Text = "Tên giáo viên chưa có!!! <br>";
            }

            int Intvalue;
            if (Int32.TryParse(Teacher_Day.Value, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 31)
                {
                    Add_Result.Text += "Ngày sinh không hợp lệ!<br>";
                    temp = false;
                    Teacher_Day.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Ngày sinh không hợp lệ!<br>";
                temp = false;
                Teacher_Day.Value = "";
            }

            if (Int32.TryParse(Teacher_Month.Value, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 12)
                {
                    Add_Result.Text += "Tháng sinh không hợp lệ!<br>";
                    temp = false;
                    Teacher_Month.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Tháng sinh không hợp lệ!<br>";
                temp = false;
                Teacher_Month.Value = "";
            } 
            
            if (Int32.TryParse(Teacher_Year.Value, out Intvalue))
            {
                if (Intvalue < 1900)
                {
                    Add_Result.Text += "Năm sinh không hợp lệ!<br>";
                    temp = false;
                    Teacher_Year.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Năm sinh không hợp lệ!<br>";
                temp = false;
                Teacher_Year.Value = "";
            }


            if (Int32.TryParse(Teacher_YearStart.Value, out Intvalue))
            {
                if (Intvalue < 1990)
                {
                    Add_Result.Text += "Năm giảng dạy không hợp lệ!<br>";
                    temp = false;
                    Teacher_YearStart.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Năm giảng dạy không hợp lệ!<br>";
                temp = false;
                Teacher_YearStart.Value = "";
            }

            bool check_subject = CheckSubject(Teacher_Subject.Value);
            if (!check_subject) {temp = false;}

            bool check_class = CheckClass(Teacher_MainClass.Value, Teacher_MainClass_Year.Value);
            if (!check_class) { temp = false; }
           
            bool check_id = CheckID(Teacher_id.Value);
            if (!check_class) { temp = false; }

            return temp;
        }

        protected void Add_Teacher_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;

                // Them thong tin vao cac table HSMSUser, HSMSTeacher, HSMSCLass
                cm.CommandText =
                    "INSERT INTO HSMSUser (ulogin_name, upassword, uemail, ufull_name, udob_day, udob_mont, udob_year) VALUES ('" +
                    Teacher_id.Value + "', '" + Teacher_id.Value + "','" + Teacher_Email.Value + "','" + Teacher_name.Value +
                    "'," + Teacher_Day.Value + "," +
                    Teacher_Month.Value + "," + Teacher_Year.Value + ")";
                cm.ExecuteNonQuery();

                cm.CommandText = "Select uid, ulogin_name From HSMSUser";
                OleDbDataReader dr = cm.ExecuteReader();
                string uid_user = "";
                while (dr.Read())
                {
                    if ((dr["ulogin_name"].ToString().Trim() == Teacher_id.Value.Trim()))
                    {
                        uid_user = dr["uid"].ToString().Trim();
                    }
                }
                dr.Dispose();
                cm.CommandText = "INSERT INTO HSMSTeacher (uid, teacher_id, subject_id, year_start) VALUES ('" +
                                 uid_user.Trim() + "','" + Teacher_id.Value +
                                 "','" + Teacher_Subject.Value + "','" + Teacher_YearStart.Value + "')";
                cm.ExecuteNonQuery();

                // Neu chua co lop chu nhiem thi chua nhap vao he thong
                if (Teacher_MainClass.Value != "")
                {
                    cm.CommandText = "INSERT INTO HSMSClass (class_id, teacher_id, year) VALUES ('" + Teacher_MainClass.Value +
                                 "','" + Teacher_id.Value + "','" + Teacher_MainClass_Year.Value +
                                 "')";
                    cm.ExecuteNonQuery();
                }


                cm.Dispose();
                conn.Close();
                conn.Dispose();

                Add_Result.Text = "Thêm thông tin giáo viên thành công!!!";
            }
        }
    }
}