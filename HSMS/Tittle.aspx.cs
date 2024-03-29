using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS
{
    public partial class Tittle : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 5;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void LoginProcess_Click(object sender, EventArgs e)
        {
            int count = 0;

            // Trang thai chua login
            Session["login_state"] = "not_login";

            OleDbConnection conn = DbUtils.GetSQLDbConnection();

            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            conn.Open();

            // Access database
            cm.CommandText = "Select ulogin_name, upassword From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if ((dr["ulogin_name"].ToString().Trim() == LoginName.Text) &&
                    (dr["upassword"].ToString().Trim() == Password.Text))
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();

            if (count > 0)
            {
                // Luu trang thai login
                Session["login_id"] = LoginName.Text;
                Session["login_pass"] = Password.Text;
                Session["login_state"] = "login";
                Session.Timeout = 60;
                
              switch (RadioButton_Choice.SelectedIndex)
                {
                    case 0:
                        {
                            cm.CommandText = "SELECT * from HSMSAdmin";
                            OleDbDataReader dr1 = cm.ExecuteReader();
                            int check = 0;
                            while (dr1.Read())
                            {
                                if ((dr1["Admin_id"].ToString().Trim() == LoginName.Text))
                                {
                                    check++;
                                }
                            }
                            if (check > 0)
                            {
                                Response.Redirect("Admin/main_admin.aspx");
                            }
                            dr1.Dispose();
                            dr1.Close();
                            LoginName.Text = "";
                            break;
                        }
                    case 1:
                        {
                            cm.CommandText = "SELECT * from HSMSTeacher";
                            OleDbDataReader dr1 = cm.ExecuteReader();
                            int check = 0;
                            while (dr1.Read())
                            {
                                if ((dr1["teacher_id"].ToString().Trim() == LoginName.Text))
                                {
                                    check++;
                                }
                            }
                            if (check > 0)
                            {
                                Response.Redirect("Teacher/main_teacher.aspx");
                            }
                            dr1.Dispose();
                            dr1.Close();
                            LoginName.Text = "";
                            break;
                        }
                    case 2:
                        {
                            cm.CommandText = "SELECT * from HSMSPupil";
                            OleDbDataReader dr1 = cm.ExecuteReader();
                            int check = 0;
                            while (dr1.Read())
                            {
                                if ((dr1["pupill_id"].ToString().Trim() == LoginName.Text))
                                {
                                    check++;
                                }
                            }
                            if (check > 0)
                            {
                                Response.Redirect("Pupil/main_pupil.aspx");
                            }
                            dr1.Dispose();
                            dr1.Close();
                            LoginName.Text = "";
                            break;
                        }
              }
            }
            else
            {
                LoginName.Text = "";
                Response.Redirect("Main.aspx");
            }
            conn.Dispose();
            conn.Close();
            cm.Dispose();
        }
    }
}