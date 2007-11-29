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
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            Add_Result.Text = "";
        }

        protected void AddPupil_Click(object sender, EventArgs e)
        {
            // ADD INFORMATION INTO ALL DATABASE

            // add User information into HSMSUser database

            // Make connection to databse
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            // do cm
            cm.CommandText =
                "INSERT INTO HSMSUser (ulogin_name, upassword, uemail, ufull_name, udob_day, udob_mont, udob_year) VALUES ('" +
                Pupil_id.Text + "', '" + Pupil_id.Text + "','" + Email.Text + "','" + Name.Text + "'," + Day.Text + "," +
                Month.Text + "," + Year.Text + ")";
            cm.ExecuteNonQuery();
            // close cm
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            // add User information into HSMSPupil

            //get uid from HSMSUser
            conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select uid, ulogin_name From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            string uid_user = "";
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == Pupil_id.Text))
                {
                    uid_user = dr["uid"].ToString().Trim();
                }
            }
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "INSERT INTO HSMSPupil (uid, pupill_id, enroll_year) VALUES ('" + uid_user.Trim() + "','" +
                             Pupil_id.Text +
                             "','" + Year_Enroll.Text + "')";
            cm.ExecuteNonQuery();
            // close cm
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            // add information into link_pupil_class

            conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "INSERT INTO link_pupil_class (pupill_id, class_id, year_start) VALUES ('" + Pupil_id.Text +
                             "','" + Class.Text + "','" + Year_Enroll.Text +
                             "')";
            cm.ExecuteNonQuery();
            // close cm
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            // Return defalut values all textbox
            Name.Text = "";
            Day.Text = "";
            Month.Text = "";
            Year.Text = "";
            Year_Enroll.Text = "";
            Class.Text = "";
            Pupil_id.Text = "";
            Email.Text = "";

            Add_Result.Text = "Thêm vào thành công!";
        }
    }
}