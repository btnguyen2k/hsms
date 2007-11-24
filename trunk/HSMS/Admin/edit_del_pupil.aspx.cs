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
    public partial class del_pupil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            Information.Visible = false;
            Del_Inf.Visible = false;
            Change_inf.Visible = false;
            Edit_Result.Text = "";
        }

        protected void FinPupil_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == Find_Pupil_id.Text))
                {
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
                }
                else
                {
                    Find_Result.Text = "Tìm không thấy dữ liệu";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Find_Pupil_id.Text = null;
        }

        protected void Del_Inf_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "DELETE FROM HSMSUSer WHERE ulogin_name = '" + PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();
            
            cm.CommandText = "DELETE FROM HSMSPupil WHERE pupill_id = '" + PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();
            
            cm.CommandText = "DELETE FROM link_pupil_class WHERE pupill_id = '" + PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            Edit_Result.Text = "Đã xoá thành công";
            
            Information.Visible = false;
            Del_Inf.Visible = false;
            Change_inf.Visible = false;

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Change_inf_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            // do cm
            cm.CommandText = "UPDATE HSMSUser SET uemail = '" + Email_Find.Value + "',ufull_name = '" + Name_Find.Value + "', udob_day = '" + Day_Find.Value + "', udob_mont = '" + Month_Find.Value + "', udob_year = '"  + Year_Find.Value + "' WHERE ulogin_name = '" +
                                PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.CommandText = "UPDATE HSMSPupil SET enroll_year = '" + EnrollYear_Find.Value + "' WHERE pupill_id = '" +
                             PupilId_Find.Value.Trim() + "'";
            cm.ExecuteNonQuery();
           
            
            cm.CommandText = "UPDATE link_pupil_class SET class_id = '" + Classid_find.Value + "', year_start = '" + EnrollYear_Find.Value + "' WHERE pupill_id = '" +
                             PupilId_Find.Value.Trim() + "'";
                                         
            cm.ExecuteNonQuery();
            
            // close cm
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            Find_Result.Text = "Thay đổi thành công!";
        }
    }
           
}
