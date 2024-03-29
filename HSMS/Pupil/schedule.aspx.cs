using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using HSMS.Db;

namespace HSMS.Pupil
{
    public partial class schedule : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            ScheduleResult.Text = "";
            schedule_pupil.Visible = false;
            if (DateTime.Now.Month < 6)
            {
                int temp = DateTime.Now.Year - 1;
                Year_Schedule.Text = temp.ToString();
            }
            else
            {
                Year_Schedule.Text = DateTime.Now.Year.ToString();
            }
        }

        protected void FindClassSchedule_Click(object sender, EventArgs e)
        {
            string class_schedule = "";

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From link_pupil_class";
            int count = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupill_id"].ToString().Trim() == Session["login_id"].ToString().Trim()
                    && dr["year_start"].ToString().Trim() == Year_Schedule.Text.Trim())
                {
                    count++;
                    class_schedule = dr["class_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            if (count == 0)
            {
                ScheduleResult.Text = "Không có lớp học này.";
            }
            else
            {
                int temp = 0;
                cm.CommandText = "Select * from HSMSClassSchedule";
                OleDbDataReader dr1 = cm.ExecuteReader();
                while (dr1.Read())
                {
                    if (dr1["class_id"].ToString().Trim() == class_schedule.Trim())
                    {
                        temp++;
                    }
                }
                dr1.Dispose();
                dr1.Close();
                if (temp == 0)
                {
                    ScheduleResult.Text = "Chưa cập nhật thời khoá biểu!";
                }
                else
                {
                    schedule_pupil.Visible = true;
                    int i = 2, j = 1;
                    for (i = 2; i <= 7; i++)
                    {
                        for (j = 1; j <= 10; j++)
                        {
                            cm.CommandText = "SELECT * FROM HSMSClassSchedule";
                            OleDbDataReader dr2 = cm.ExecuteReader();
                            while (dr2.Read())
                            {
                                Int32 day = (Int32) dr2["day"];
                                Int32 tiet = (Int32) dr2["tiet"];
                                if (dr2["class_id"].ToString().Trim() == class_schedule.Trim()
                                    && day == i
                                    && tiet == j
                                    )
                                {
                                    HtmlInputText class_temp = null;
                                    string id = "T" + i + j;
                                    class_temp = FindControl(id) as HtmlInputText;
                                    if (class_temp != null)
                                    {
                                        class_temp.Value = dr2["subject_id"].ToString().Trim();
                                    }
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
            }
        }
    }
}