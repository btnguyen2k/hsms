using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class del_pupil : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            Information.Visible = false;
            Del_Inf.Visible = false;
            Change_inf.Visible = false;
            Edit_Result.Text = "";
        }

        static protected bool CheckRightId(string id)
        {
            bool temp = false;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSPupil";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupill_id"].ToString().Trim() == id.Trim())
                {
                    temp = true;
                }
            }
            return temp;
        }

        protected void FinPupil_Click(object sender, EventArgs e)
        {
            bool check_id = CheckRightId(Find_Pupil_id.Text);
            if (check_id)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "Select * From HSMSUser";
                OleDbDataReader dr = cm.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    if ((dr["ulogin_name"].ToString().Trim() == Find_Pupil_id.Text))
                    {
                        count++;
                        Name_Find.Value = dr["ufull_name"].ToString().Trim();
                        Day_Find.Value = dr["udob_day"].ToString().Trim();
                        Month_Find.Value = dr["udob_mont"].ToString().Trim();
                        Year_Find.Value = dr["udob_year"].ToString().Trim();
                        PupilId_Find.Value = dr["ulogin_name"].ToString().Trim();
                        Email_Find.Value = dr["uemail"].ToString().Trim();

                        OleDbCommand cm1 = new OleDbCommand();
                        cm1.Connection = conn;
                        cm1.CommandText = "Select pupill_id, class_id, year_start FROM link_pupil_class";
                        OleDbDataReader dr1 = cm1.ExecuteReader();
                        while (dr1.Read())
                        {
                            if (dr1["pupill_id"].ToString().Trim() == Find_Pupil_id.Text)
                            {
                                EnrollYear_Find.Value = dr1["year_start"].ToString().Trim();
                                Classid_find.Value = dr1["class_id"].ToString().Trim();
                            }
                        }
                        dr1.Dispose();
                        dr1.Close();
                        cm1.Dispose();

                        Information.Visible = true;
                        Del_Inf.Visible = true;
                        Change_inf.Visible = true;
                        Find_Result.Text = "";
                        Find_Pupil_id.Enabled = false;
                    }
                }
                if (count == 0)
                {
                    Find_Result.Text = "Tìm không thấy dữ liệu!";
                }
                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Dispose();
                conn.Close();
            }
            else
            {
                Find_Pupil_id.Text = "";
            }


            //Find_Pupil_id.Text = null;
        }

        protected void Del_Inf_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "DELETE FROM HSMSUSer WHERE ulogin_name = '" + PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "DELETE FROM HSMSPupil WHERE pupill_id = '" + PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "DELETE FROM link_pupil_class WHERE pupill_id = '" + PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            Edit_Result.Text = "Đã xoá thành công!";

            Information.Visible = false;
            Del_Inf.Visible = false;
            Change_inf.Visible = false;

            cm.Dispose();
            conn.Dispose();
            conn.Close();
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
                    EnrollYear_Find.Value = "";
                    Classid_find.Value = "";
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
            if (PupilId_Find.Value == "")
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
                        PupilId_Find.Value = "";
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
            if (Name_Find.Value == "")
            {
                Add_Result.Text = "Tên học sinh chưa có! <br>";
            }

            int Intvalue;
            if (Int32.TryParse(Day_Find.Value, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 31)
                {
                    Add_Result.Text += "Ngày sinh không hợp lệ!<br>";
                    temp = false;
                    Day_Find.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Ngày sinh không hợp lệ!<br>";
                temp = false;
                Day_Find.Value = "";
            }

            if (Int32.TryParse(Month_Find.Value, out Intvalue))
            {
                if (Intvalue < 0 || Intvalue > 12)
                {
                    Add_Result.Text += "Tháng sinh không hợp lệ!<br>";
                    temp = false;
                    Month_Find.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Tháng sinh không hợp lệ!<br>";
                temp = false;
                Month_Find.Value = "";
            }

            if (Int32.TryParse(Year_Find.Value, out Intvalue))
            {
                if (Intvalue < 1900)
                {
                    Add_Result.Text += "Năm sinh không hợp lệ!<br>";
                    temp = false;
                    Year_Find.Value = "";
                }
            }
            else
            {
                Add_Result.Text += "Năm sinh không hợp lệ!<br>";
                temp = false;
                Year_Find.Value = "";
            }

            bool check_class = CheckClass(Classid_find.Value, EnrollYear_Find.Value);
            if (!check_class) { temp = false; }

            //bool check_id = CheckID(PupilId_Find.Value);
            //if (!check_class) { temp = false; }

            return temp;
        }
        
        protected void Change_inf_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;

                // do cm
                cm.CommandText = "UPDATE HSMSUser SET uemail = '" + Email_Find.Value + "',ufull_name = '" + Name_Find.Value +
                                 "', udob_day = '" + Day_Find.Value + "', udob_mont = '" + Month_Find.Value +
                                 "', udob_year = '" + Year_Find.Value + "' WHERE ulogin_name = '" +
                                 PupilId_Find.Value.Trim() + "'";
                cm.ExecuteNonQuery();

                cm.CommandText = "UPDATE HSMSPupil SET enroll_year = '" + EnrollYear_Find.Value + "' WHERE pupill_id = '" +
                                 PupilId_Find.Value.Trim() + "'";
                cm.ExecuteNonQuery();


                cm.CommandText = "UPDATE link_pupil_class SET class_id = '" + Classid_find.Value + "', year_start = '" +
                                 EnrollYear_Find.Value + "' WHERE pupill_id = '" +
                                 PupilId_Find.Value.Trim() + "'";

                cm.ExecuteNonQuery();

                // close cm
                cm.Dispose();
                conn.Close();
                conn.Dispose();

                Find_Result.Text = "Thay đổi thành công!";
            }
            else
            {
                FinPupil_Click(sender, e);
            }
        }
    }
}