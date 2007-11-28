using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HSMS.Admin
{
    public partial class teacher_scheduling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            Finding_result.Text = "";
            Teacher_AddSchedule.Visible = false;
            Teacher_EditSchedule.Visible = false;
            schedule.Visible = false;
            Result_Edit_Add.Text = "";
        }

        protected void Teacher_Finding_Click(object sender, EventArgs e)
        {
            Result_Edit_Add.Text = "";
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select ulogin_name, ufull_name From HSMSUser";
            int count = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == Teacher_FindId.Text.Trim())) 
                {
                    count++;
                    Finding_result.Text = "Giáo viên: " + dr["ufull_name"].ToString().Trim(); 
                }
            }
            dr.Dispose();
            dr.Close();
            
            if (count == 0)
            {
                Finding_result.Text = "Không có thông tin về giáo viên này";
            } 
            else
            {
                count = 0;
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
                }
                else
                {
                    Teacher_AddSchedule.Visible = false;
                    Teacher_EditSchedule.Visible = true;
                    Finding_result.Text += ". Đây lịch lịch công tác!";
                    ViewSchedule(Teacher_FindId.Text.Trim());
                }
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Teacher_AddSchedule_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            int i = 2, j = 1;
            for (i=2; i <=7 ; i++ )
            {
                for (j=1;j<=10;j++)
                {
                    HtmlInputText class_temp = null;
                    string id = "T" + i + j;
                    class_temp = this.FindControl(id) as HtmlInputText;
                    if ( class_temp != null )
                    {
                        cm.CommandText =
                            "INSERT INTO HSMSTeacherSchedule (teacher_id, day, tiet, class_id) VALUES ('" +
                            Teacher_FindId.Text.Trim() + "'," + i + "," + j + ",'" + class_temp.Value.Trim() + "')";
                        cm.ExecuteNonQuery();    
                    }
                    
                }
            }
            Result_Edit_Add.Text = "Thêm lịch công tác thành công!!";
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
        protected void ViewSchedule(string teacher_viewid)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            int i = 2, j = 1;
            for (i=2; i <=7 ; i++ )
            {
                for (j = 1; j <= 10; j++)
                {
                    cm.CommandText = "SELECT * FROM HSMSTeacherSchedule";
                    OleDbDataReader dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        Int32 day = (Int32)dr["day"];
                        Int32 tiet = (Int32)dr["tiet"];
                        if ( dr["teacher_id"].ToString().Trim() == teacher_viewid.Trim() 
                            && day == i 
                            && tiet == j
                            )
                        {
                            HtmlInputText class_temp = null;
                            string id = "T" + i + j;
                            class_temp = this.FindControl(id) as HtmlInputText;
                            if ( class_temp!=null )
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

        protected void Teacher_EditSchedule_Click(object sender, EventArgs e)
        {
            String connStr =
               "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
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
                    class_temp = this.FindControl(id) as HtmlInputText;
                    if (class_temp != null)
                    {
                        cm.CommandText =
                            "UPDATE HSMSTeacherSchedule SET class_id = '" + class_temp.Value + "' WHERE teacher_id = '" +
                            Teacher_FindId.Text.Trim() + "' AND day = " + i + "AND tiet = " + j;
                        cm.ExecuteNonQuery();
                    }

                }
            }
            Result_Edit_Add.Text = "Cập nhật lịch công tác thành công!!";
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
