using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class class_schedule : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            
        }

        protected void FindClass_Schedule_Click(object sender, EventArgs e)
        {
            Result_Edit_Add.Text = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select class_id, year From HSMSClass";
            int count = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["class_id"].ToString().Trim() == Classid_Name.Text.Trim())
                    && dr["year"].ToString().Trim() == Classid_Year.Text.Trim())
                {
                    count++;
                    Find_Result.Text = "Lớp : " + dr["class_id"].ToString().Trim() + ", năm học:" +
                                       dr["year"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();

            if (count == 0)
            {
                Find_Result.Text = "Không có thông tin về lớp học này!";
            }
            else
            {
                count = 0;
                schedule.Visible = true;
                OleDbCommand cm1 = new OleDbCommand();
                cm1.Connection = conn;
                cm1.CommandText = "Select class_id, year From HSMSClassSchedule";
                OleDbDataReader dr1 = cm1.ExecuteReader();

                while (dr1.Read())
                {
                    if (dr1["class_id"].ToString().Trim() == Classid_Name.Text.Trim()
                        && dr1["year"].ToString().Trim() == Classid_Year.Text.Trim())
                    {
                        count++;
                    }
                }
                dr1.Dispose();
                dr1.Close();
                cm1.Dispose();

                if (count == 0)
                {
                    AddClass_Schedule.Visible = true;
                    EditClass_Schedule.Visible = false;
                    Find_Result.Text += ". Chưa có thời khoá biểu, hãy thêm vào.";
                }
                else
                {
                    AddClass_Schedule.Visible = false;
                    EditClass_Schedule.Visible = true;
                    Find_Result.Text += ". Đây là thời khoá biểu!";
                    ViewClassSchedule(Classid_Name.Text.Trim(), Classid_Year.Text.Trim());
                }
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void ViewClassSchedule(string classname, string classyear)
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
                    cm.CommandText = "SELECT * FROM HSMSClassSchedule";
                    OleDbDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        Int32 day = (Int32) dr["day"];
                        Int32 tiet = (Int32) dr["tiet"];
                        if (dr["class_id"].ToString().Trim() == classname.Trim()
                            && dr["year"].ToString().Trim() == classyear.Trim()
                            && day == i
                            && tiet == j
                            )
                        {
                            HtmlInputText class_temp = null;
                            string id = "T" + i + j;
                            class_temp = FindControl(id) as HtmlInputText;
                            if (class_temp != null)
                            {
                                class_temp.Value = dr["subject_id"].ToString().Trim();
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

        protected void AddClass_Schedule_Click(object sender, EventArgs e)
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
                            "INSERT INTO HSMSClassSchedule (class_id, year, day, tiet, subject_id) VALUES ('" +
                            Classid_Name.Text.Trim() + "','" + Classid_Year.Text.Trim() + "'," + i + "," + j + ",'" +
                            class_temp.Value.Trim() + "')";
                        cm.ExecuteNonQuery();
                    }
                }
            }
            Result_Edit_Add.Text = "Thêm lịch công tác thành công!!";
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void EditClass_Schedule_Click(object sender, EventArgs e)
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
                            "UPDATE HSMSClassSchedule SET subject_id = '" + class_temp.Value + "' WHERE class_id = '" +
                            Classid_Name.Text.Trim() + "' AND year = '" + Classid_Year.Text.Trim() + "' AND day = " + i +
                            "AND tiet = " + j;
                        cm.ExecuteNonQuery();
                    }
                }
            }
            Result_Edit_Add.Text = "Cập nhật thời khoá biểu thành công!!";
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void ClassFind_ScheduleAll_Click(object sender, EventArgs e)
        {
            Find_Result.Text =
                "<table width=70% border=\"1\"> <tr> <td align=center>Tên lớp</td> <td align=center>Năm học</td></tr>";
            
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Find_Result.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                                    "</td><td align=center style=\"color:black\">" +
                                    dr["year"].ToString().Trim() + "</td></tr>";
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            Find_Result.Text += "</table>";
        }
    }
}