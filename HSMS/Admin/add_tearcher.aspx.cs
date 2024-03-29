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
            
            // init input values
            if (!IsPostBack)
            {
                Teacher_YearStart.Items.Add("");
                for (int i = DateTime.Now.Year - 65; i <= DateTime.Now.Year - 18; i++)
                {
                    Teacher_Year.Items.Add(i.ToString());
                }
                for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 65;i-- )
                {
                    Teacher_YearStart.Items.Add(i.ToString());
                }
                GetSubjectList();
                GetClassListHaveNonMainTeacher();    
            }
        }

        protected void GetClassListHaveNonMainTeacher()
        {
            Teacher_MainClass.Items.Add("");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                object temp = dr["teacher_id"];
                if ( temp == null || temp.ToString().Trim() == "" )
                {
                    Teacher_MainClass.Items.Add(dr["class_id"].ToString());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected  void GetSubjectList()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Teacher_Subject.Items.Add(dr["subject_name"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
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
       
        protected bool CheckClass(string name, string year)
        {
            bool temp = true;
            if (name == "" && year == "" )
            {
                Add_Result.Text += "Chưa nhập lớp học!!!<br>";
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

            if (Teacher_YearStart.SelectedItem.Value == "")
            {
                Add_Result.Text = "Năm bắt đầu giảng dạy chưa có!<br>";
            }

            bool check_class = CheckClass(Teacher_MainClass.SelectedItem.Value, Teacher_MainClass_Year.Value);
            if (!check_class) { temp = false; }
           
            bool check_id = CheckID(Teacher_id.Value);
            if (!check_id) { temp = false; }

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
                    "'," + Teacher_Day.SelectedItem.Value + "," +
                    Teacher_Month.SelectedItem.Value + "," + Teacher_Year.SelectedItem.Value + ")";
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
                cm.CommandText = "INSERT INTO HSMSTeacher (uid, teacher_id, subject_id, year_start, history, position) VALUES ('" +
                                 uid_user.Trim() + "','" + Teacher_id.Value +
                                 "','" + Teacher_Subject.SelectedItem.Value + "','" + Teacher_YearStart.SelectedItem.Value +
                                 "','" + HistoryTeacher.Text + "','" + Position.Text + "')";
                cm.ExecuteNonQuery();

                // Neu chua co lop chu nhiem thi chua nhap vao he thong
                if (Teacher_MainClass.SelectedItem.Value != "")
                {
                    cm.CommandText = "INSERT INTO HSMSClass (class_id, teacher_id, year) VALUES ('" + Teacher_MainClass.SelectedItem.Value +
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

        protected void Teacher_MainClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Teacher_MainClass.SelectedItem.Value != "")
            {
                int year_temp = DateTime.Now.Year;
                if (DateTime.Now.Month < 6)
                {
                    year_temp -= 1;
                }
                Teacher_MainClass_Year.Value = year_temp.ToString();
            }
        }
    }
}