using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using HSMS.Db;

namespace HSMS.Teacher
{
    public partial class scheduling : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            ScheduleResult.Text = "";
            schedule.Visible = false;

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select teacher_id From HSMSTeacherSchedule";
            int count = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            if (count == 0)
            {
                ScheduleResult.Text = "Chưa có lịch công tác.";
            }
            else
            {
                ScheduleResult.Text = "Lịch công tác cho năm học " + DateTime.Now.Year;
                schedule.Visible = true;
                int i = 2, j = 1;
                for (i = 2; i <= 7; i++)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        cm.CommandText = "SELECT * FROM HSMSTeacherSchedule";
                        OleDbDataReader dr1 = cm.ExecuteReader();
                        while (dr1.Read())
                        {
                            Int32 day = (Int32) dr1["day"];
                            Int32 tiet = (Int32) dr1["tiet"];
                            if (dr1["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim()
                                && day == i
                                && tiet == j
                                )
                            {
                                HtmlInputText class_temp = null;
                                string id = "T" + i + j;
                                class_temp = FindControl(id) as HtmlInputText;
                                string classname = dr1["class_id"].ToString().Trim();
                                if (class_temp != null)
                                {
                                    class_temp.Value = classname;
                                    int temp_year = DateTime.Now.Year;
                                    if (DateTime.Now.Month < 7)
                                    {
                                        temp_year -= 1; 
                                    }
                                    if (classname.Trim() != "")
                                    {
                                        string classroom = GetClassRoom(classname, temp_year, j);
                                        class_temp.Value += "(" + classroom + ")";
                                    }
                                }
                            }
                        }
                        dr1.Dispose();
                        dr1.Close();
                    }
                }
                cm.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        protected string GetClassRoom(string classname, int year, int tiet)
        {
            string temp_room = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "select * from hsmsclassroom";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_class = "";
                if (tiet > 5)
                {
                    temp_class = dr["class_id_c"].ToString().Trim();
                }
                else
                {
                    temp_class = dr["class_id_s"].ToString().Trim();
                }
                if (temp_class == classname)
                {
                    temp_room = dr["room_name"].ToString().Trim();
                }
            }
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            
            return temp_room;
        }
    }
}