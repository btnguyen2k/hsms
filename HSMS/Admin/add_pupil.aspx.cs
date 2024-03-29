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
            Year_Enroll.ReadOnly = true;
            if (!IsPostBack)
            {
                GetYear();
                int temp_yearenrool = DateTime.Now.Year;
                if (DateTime.Now.Month < 6)
                {
                    temp_yearenrool -= 1;
                }
                Year_Enroll.Text = temp_yearenrool.ToString();
                GetCurrentClass(temp_yearenrool.ToString());
            }
        }

        protected void GetCurrentClass(string year_temp)
        {
            Class.Items.Add("");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["year"].ToString().Trim() == year_temp.Trim())
                {
                    Class.Items.Add(dr["class_id"].ToString());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void GetYear()
        {
            for (int i=DateTime.Now.Year-25; i <= DateTime.Now.Year-13; i++)
            {
                Year.Items.Add(i.ToString());
            }
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

        protected bool CheckTK (string classname, string year)
        {
            bool temp = true;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year
                    && dr["hk"].ToString().Trim() == "2")
                {
                    temp = false;
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
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
            
            bool check_class = CheckClass(Class.SelectedItem.Value.Trim(), Year_Enroll.Text.Trim());
            if (!check_class) { temp = false; }

            bool check_id = CheckID(Pupil_id.Text.Trim());
            if (!check_id)
            {
                temp = false;   
            }

            bool check_Tk = CheckTK(Class.SelectedItem.Value.Trim(), Year_Enroll.Text.Trim());
            if (!check_Tk)
            {
                temp = false;
                Add_Result.Text += "Lớp học này đã kết thúc năm học rồi!<br>";
            }
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
                    Pupil_id.Text.Trim() + "', '" + Pupil_id.Text.Trim() + "','" + Email.Text.Trim() + "','" + Name.Text + "'," + Day.Text.Trim() + "," +
                    Month.Text.Trim() + "," + Year.Text.Trim() + ")";
                cm.ExecuteNonQuery();

                cm.CommandText = "Select uid, ulogin_name From HSMSUser";
                OleDbDataReader dr = cm.ExecuteReader();
                string uid_user = "";
                while (dr.Read())
                {
                    if ((dr["ulogin_name"].ToString().Trim() == Pupil_id.Text.Trim()))
                    {
                        uid_user = dr["uid"].ToString().Trim();
                    }
                }
                dr.Dispose();
                dr.Close();

                cm.CommandText = "INSERT INTO HSMSPupil (uid, pupill_id, enroll_year, Position, history) VALUES ('" + uid_user.Trim() + "','" +
                                 Pupil_id.Text.Trim() +
                                 "','" + Year_Enroll.Text.Trim() + "','" + Position.Text + 
                                 "','" + History.Text +  "')";
                cm.ExecuteNonQuery();

                cm.CommandText = "INSERT INTO link_pupil_class (pupill_id, class_id, year_start) VALUES ('" + Pupil_id.Text +
                                 "','" + Class.Text.Trim() + "','" + Year_Enroll.Text.Trim() +
                                 "')";
                cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
                conn.Dispose();

                // Return defalut values all textbox
                Name.Text = "";
                Email.Text = "";

                Add_Result.Text = "Thêm vào thành công!";
            }
        }

        protected void Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Class.SelectedItem.Value.Trim() != "")
            {
                Pupil_id.Text = Class.SelectedItem.Value.Trim() + Year_Enroll.Text.Substring(2, 2);
            }
        }
    }
}