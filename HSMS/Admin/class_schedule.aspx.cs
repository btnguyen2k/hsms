using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class class_schedule : Page
    {
        private int temp_date;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            temp_date = DateTime.Now.Year;
            if (DateTime.Now.Month < 7)
            {
                temp_date -= 1;
            }
            if (!IsPostBack)
            {
                GetClassList();
            }
        }

        protected void GetClassList()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select DISTINCT class_id, year From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["year"].ToString().Trim() == temp_date.ToString().Trim())
                {
                    Classid_Name.Items.Add(dr["class_id"].ToString());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void FindClass_Schedule_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            int count = 0;
            schedule.Visible = true;
            cm.CommandText = "Select class_id From HSMSClassSchedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == Classid_Name.SelectedItem.Value.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            if (count == 0)
            {
                Find_Result.Text += ". Chưa có thời khoá biểu.";
            }
            else
            {
                Find_Result.Text += ". Đây là thời khoá biểu!";
                ViewClassSchedule(Classid_Name.SelectedItem.Value.Trim(), temp_date.ToString().Trim());
            }


            Classid_Name.Enabled = false;
            FindClass_Schedule.Enabled = false;
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
    }
}