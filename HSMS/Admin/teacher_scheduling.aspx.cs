using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class teacher_scheduling : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            Finding_result.Text = "";
            Teacher_AddSchedule.Visible = false;
            Teacher_EditSchedule.Visible = false;
            schedule.Visible = false;
            //Result_Edit_Add.Text = "";
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

        protected void RefreshSchedule()
        {
            int i = 2, j = 1;
            for (i = 2; i <= 7; i++)
            {
                for (j = 1; j <= 10; j++)
                {
                    HtmlInputText class_temp = null;
                    string id = "T" + i + j;
                    class_temp = FindControl(id) as HtmlInputText;
                    class_temp.Value = "";
                }
            }
        }

        protected void Teacher_Finding_Click(object sender, EventArgs e)
        {
            //Result_Edit_Add.Text = "";
            Teacher_Finding.Enabled = false;
            Teacher_FindId.Enabled = false;

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select ulogin_name, ufull_name From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == Teacher_FindId.Text.Trim()))
                {
                    Finding_result.Text = "Giáo viên: " + dr["ufull_name"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();

            int count = 0;
            schedule.Visible = true;
            OleDbCommand cm1 = new OleDbCommand();
            cm1.Connection = conn;
            cm1.CommandText = "Select teacher_id From HSMSTeacherSchedule";
            OleDbDataReader dr1 = cm1.ExecuteReader();

            while (dr1.Read())
            {
                if (dr1["teacher_id"].ToString().Trim() == Teacher_FindId.Text.Trim())
                {
                    count++;
                }
            }
            dr1.Dispose();
            dr1.Close();
            cm1.Dispose();

            if (count == 0)
            {
                Teacher_EditSchedule.Visible = false;
                Teacher_AddSchedule.Visible = true;
                Finding_result.Text += ". Chưa có lịch dạy, hãy thêm vào.";
                RefreshSchedule();
            }
            else
            {
                Teacher_AddSchedule.Visible = false;
                Teacher_EditSchedule.Visible = true;
                Finding_result.Text += ". Đây lịch lịch công tác!";
                ViewSchedule(Teacher_FindId.Text.Trim());
                Teacher_FindId.Enabled = false;
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void ViewSchedule(string teacher_viewid)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            int i = 2, j = 1;
            for (i = 2; i <= 7; i++)
            {
                for (j = 1; j <= 10; j++)
                {
                    cm.CommandText = "SELECT * FROM HSMSTeacherSchedule";
                    OleDbDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        Int32 day = (Int32) dr["day"];
                        Int32 tiet = (Int32) dr["tiet"];
                        if (dr["teacher_id"].ToString().Trim() == teacher_viewid.Trim()
                            && day == i
                            && tiet == j
                            )
                        {
                            HtmlInputText class_temp = null;
                            string id = "T" + i + j;
                            class_temp = FindControl(id) as HtmlInputText;
                            if (class_temp != null)
                            {
                                class_temp.Value = dr["class_id"].ToString().Trim();
                            }
                        }
                    }
                    dr.Dispose();
                    dr.Close();
                }
            }
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected bool VerifyData()
        {
            Result_Edit_Add.Text = "";
            bool temp = true;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            int i = 2, j = 1;
            for (i = 2; i <= 7; i++)
            {
                for (j = 1; j <= 10; j++)
                {
                    HtmlInputText class_temp = null;
                    string id = "T" + i + j;
                    class_temp = FindControl(id) as HtmlInputText;
                    if (class_temp.Value.Trim() != "")
                    {
                        int count = 0;
                        bool check = true;
                        cm.CommandText = "Select * from HSMSClass";
                        OleDbDataReader dr = cm.ExecuteReader();
                        int temp_date = DateTime.Now.Year;
                        if (DateTime.Now.Month < 6)
                        {
                            temp_date -= 1;
                        }
                        while (dr.Read())
                        {
                            if (dr["class_id"].ToString().Trim() == class_temp.Value.Trim()
                                && temp_date.ToString().Trim() == dr["year"].ToString().Trim())
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            temp = false;
                            Result_Edit_Add.Text += "Thứ " + i + " tiết " + j + ". Tên lớp không tồn tại!! <br>";
                            check = false;
                        }
                        dr.Dispose();
                        dr.Close();
                        cm.CommandText = "Select * from HSMSTeacherSchedule";
                        OleDbDataReader dr1 = cm.ExecuteReader();
                        while (dr1.Read())
                        {
                            if (dr1["day"].ToString().Trim() == i.ToString().Trim()
                                && dr1["tiet"].ToString().Trim() == j.ToString().Trim()
                                && dr1["class_id"].ToString().Trim() == class_temp.Value.Trim()
                                && dr1["teacher_id"].ToString().Trim() != Teacher_FindId.Text.Trim())
                            {
                                temp = false;
                                Result_Edit_Add.Text += "Thứ " + i + " tiết " + j + ". MSGV " +
                                                        dr1["teacher_id"].ToString().Trim() + " đã dạy. <br>";
                                check = false;
                            }
                        }
                        if (!check)
                        {
                            class_temp.Value = "";
                        }
                        dr1.Dispose();
                        dr1.Close();
                        cm.CommandText = "Select * from HSMSClassFinal";
                        OleDbDataReader dr2 = cm.ExecuteReader();
                        while (dr2.Read())
                        {
                            int temp_count = 0;
                            string temp_rate = dr2["rate"].ToString().Trim();
                            if (dr2["hk"].ToString().Trim() == "2"
                                && dr2["class_id"].ToString().Trim() == class_temp.Value.Trim()
                                && dr2["year"].ToString().Trim() == temp_date.ToString().Trim()
                                && Int32.Parse(temp_rate) > 0)
                            {
                                temp_count++;
                                temp = false;
                            }

                            if (temp_count != 0)
                            {
                                    Result_Edit_Add.Text += "Thứ " + i + " tiết " + j +
                                                        ". Lớp đó đã kết thúc năm học rồi.<br>";
                            }
                        }
                        dr2.Dispose();
                        dr2.Close();
                    }
                }
            }
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp;
        }

        static protected bool HaveNoClassSchedule(string classid)
        {
            bool temp = true;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from hsmsclassschedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classid)
                {
                    temp = false;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        static protected void CreateNewClassSchedule(string classid)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            for (int i = 2; i <= 7;i++ )
            {
                for (int j=1;j<=10;j++)
                {
                    cm.CommandText = "INSERT INTO HSMSClassSchedule(class_id, day, tiet, subject_id) VALUES ('" + classid + "','" + i + "','" +
                                     j + "','" + "" + "')";
                    cm.ExecuteNonQuery();
                }
            }
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        static protected string GetTeacherSubject(string teacherid)
        {
            string temp="";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from hsmsteacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == teacherid)
                {
                    temp = dr["subject_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        static protected void UpDateHSMSClassSchedule(string teacherid, int ngay, int tiet, string classid)
        {
            if (HaveNoClassSchedule(classid))
            {
                CreateNewClassSchedule(classid);
            }
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "UPDATE HSMSClassSchedule SET subject_id='" + GetTeacherSubject(teacherid).Trim() +
                             "' Where class_id='" + classid + "' AND day=" + ngay + " AND tiet=" + tiet;
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Teacher_AddSchedule_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                int i = 2, j = 1;
                for (i = 2; i <= 7; i++)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        HtmlInputText class_temp = null;
                        string id = "T" + i + j;
                        class_temp = FindControl(id) as HtmlInputText;
                        if (class_temp != null)
                        {
                            cm.CommandText =
                                "INSERT INTO HSMSTeacherSchedule (teacher_id, day, tiet, class_id) VALUES ('" +
                                Teacher_FindId.Text.Trim() + "'," + i + "," + j + ",'" + class_temp.Value.Trim() + "')";
                            cm.ExecuteNonQuery();
                            if (class_temp.Value.Trim() != "")
                            {
                                UpDateHSMSClassSchedule(Teacher_FindId.Text.Trim(), i, j, class_temp.Value.Trim());
                            }
                        }
                    }
                }
                Result_Edit_Add.Text = "Thêm lịch công tác thành công!!";
                Teacher_Finding.Enabled = true;
                Teacher_FindId.Enabled = true;
                cm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            else
            {
                Teacher_Finding_Click(sender, e);
                Result_Edit_Add.Text += "Dữ liệu nhập vào không phù hợp";
            }
        }

        protected void Teacher_EditSchedule_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                int i = 2, j = 1;
                for (i = 2; i <= 7; i++)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        HtmlInputText class_temp = null;
                        string id = "T" + i + j;
                        class_temp = FindControl(id) as HtmlInputText;
                        if (class_temp != null)
                        {
                            cm.CommandText =
                                "UPDATE HSMSTeacherSchedule SET class_id = '" + class_temp.Value +
                                "' WHERE teacher_id = '" +
                                Teacher_FindId.Text.Trim() + "' AND day = " + i + "AND tiet = " + j;
                            cm.ExecuteNonQuery();
                            if (class_temp.Value.Trim() != "")
                            {
                                UpDateHSMSClassSchedule(Teacher_FindId.Text.Trim(), i, j, class_temp.Value.Trim());
                            }
                        }
                    }
                }
                Result_Edit_Add.Text = "Cập nhật lịch công tác thành công!!";
                Teacher_Finding.Enabled = true;
                Teacher_FindId.Enabled = true;
                cm.Dispose();
                conn.Close();
                conn.Dispose();
            }
            else
            {
                Teacher_Finding_Click(sender, e);
                Result_Edit_Add.Text += "Dữ liệu thay đổi không phù hợp";
            }
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