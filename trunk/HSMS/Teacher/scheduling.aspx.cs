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
                                if (class_temp != null)
                                {
                                    class_temp.Value = dr1["class_id"].ToString().Trim();
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
    }
}