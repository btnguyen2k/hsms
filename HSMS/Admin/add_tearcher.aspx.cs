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
using NHibernate.Test.UserCollection;

namespace HSMS.Admin
{
    public partial class add_tearcher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            Add_Result.Text = "";
        }

        protected void Add_Teacher_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            
            // Them thong tin vao cac table HSMSUser, HSMSTeacher, HSMSCLass
            cm.CommandText =
               "INSERT INTO HSMSUser (ulogin_name, upassword, uemail, ufull_name, udob_day, udob_mont, udob_year) VALUES ('" +
               Teacher_id.Value + "', '" + Teacher_id.Value + "','" + Teacher_Email.Value + "','" + Teacher_name.Value + "'," + Teacher_Day.Value + "," +
               Teacher_Month.Value + "," + Teacher_Year.Value + ")";
            cm.ExecuteNonQuery();

            cm.CommandText = "Select uid, ulogin_name From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            string uid_user = "";
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == Teacher_id.Value.Trim()))
                {
                    uid_user = dr["uid"].ToString().Trim();
                }
            }
            dr.Dispose();
            cm.CommandText = "INSERT INTO HSMSTeacher (uid, teacher_id, subject_id, year_start) VALUES ('" + uid_user.Trim() + "','" + Teacher_id.Value +
                            "','" + Teacher_Subject.Value + "','" + Teacher_YearStart.Value + "')";
            cm.ExecuteNonQuery();

            cm.CommandText = "INSERT INTO HSMSClass (class_id, teacher_id, year) VALUES ('" + Teacher_MainClass.Value + "','" + Teacher_id.Value + "','" + Teacher_MainClass_Year.Value +
         "')";
            cm.ExecuteNonQuery();

            cm.Dispose();
            conn.Close();
            conn.Dispose();

            Add_Result.Text = "Thêm thông tin giáo viên thành công!!!";
        }

      
    }
}
