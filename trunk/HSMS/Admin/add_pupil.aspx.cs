using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class add_pupil : Page
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

        protected bool CheckClass(string name, string year)
        {
            bool temp = true;
            if (name == "" && year == "")
            {
                Add_Result.Text += "Chưa nhập lớp học!<br>";
                temp = false;
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
                    }
                }
                if (count == 0)
                {
                    temp = false;
                    Year_Enroll.Text = "";
                    Class.Text = "";
                    Add_Result.Text += "Không có lớp học này!<br>";
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
            if (Pupil_id.Text == "")
            {
                temp = false;
                Add_Result.Text += "Không có MSHS!";
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
                        Pupil_id.Text = "";
                        Add_Result.Text += "Đã có MSHS này!<br>";
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
            if (Name.Text == "")
            {
                Add_Result.Text = "Tên học sinh chưa có! <br>";
            }

            int Intvalue;
            if (Int32.TryParse(Day.Text, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 31)
                {
                    Add_Result.Text += "Ngày sinh không hợp lệ!<br>";
                    temp = false;
                    Day.Text = "";
                }
            }
            else
            {
                Add_Result.Text += "Ngày sinh không hợp lệ!<br>";
                temp = false;
                Day.Text = "";
            }

            if (Int32.TryParse(Month.Text, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 12)
                {
                    Add_Result.Text += "Tháng sinh không hợp lệ!<br>";
                    temp = false;
                    Month.Text = "";
                }
            }
            else
            {
                Add_Result.Text += "Tháng sinh không hợp lệ!<br>";
                temp = false;
                Month.Text = "";
            }

            if (Int32.TryParse(Year.Text, out Intvalue))
            {
                if (Intvalue < 1900)
                {
                    Add_Result.Text += "Năm sinh không hợp lệ!<br>";
                    temp = false;
                    Year.Text = "";
                }
            }
            else
            {
                Add_Result.Text += "Năm sinh không hợp lệ!<br>";
                temp = false;
                Year.Text = "";
            }

            bool check_class = CheckClass(Class.Text, Year_Enroll.Text);
            if (!check_class) { temp = false; }

            bool check_id = CheckID(Pupil_id.Text);
            if (!check_class) { temp = false; }

            return temp;
        }

        protected void AddPupil_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;

                cm.CommandText =
                    "INSERT INTO HSMSUser (ulogin_name, upassword, uemail, ufull_name, udob_day, udob_mont, udob_year) VALUES ('" +
                    Pupil_id.Text + "', '" + Pupil_id.Text + "','" + Email.Text + "','" + Name.Text + "'," + Day.Text + "," +
                    Month.Text + "," + Year.Text + ")";
                cm.ExecuteNonQuery();

                cm.CommandText = "Select uid, ulogin_name From HSMSUser";
                OleDbDataReader dr = cm.ExecuteReader();
                string uid_user = "";
                while (dr.Read())
                {
                    if ((dr["ulogin_name"].ToString().Trim() == Pupil_id.Text))
                    {
                        uid_user = dr["uid"].ToString().Trim();
                    }
                }
                dr.Dispose();
                dr.Close();

                cm.CommandText = "INSERT INTO HSMSPupil (uid, pupill_id, enroll_year) VALUES ('" + uid_user.Trim() + "','" +
                                 Pupil_id.Text +
                                 "','" + Year_Enroll.Text + "')";
                cm.ExecuteNonQuery();

                cm.CommandText = "INSERT INTO link_pupil_class (pupill_id, class_id, year_start) VALUES ('" + Pupil_id.Text +
                                 "','" + Class.Text + "','" + Year_Enroll.Text +
                                 "')";
                cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
                conn.Dispose();

                // Return defalut values all textbox
                Name.Text = "";
                Day.Text = "";
                Month.Text = "";
                Year.Text = "";
                Year_Enroll.Text = "";
                Class.Text = "";
                Pupil_id.Text = "";
                Email.Text = "";

                Add_Result.Text = "Thêm vào thành công!";
            }
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
    }
}