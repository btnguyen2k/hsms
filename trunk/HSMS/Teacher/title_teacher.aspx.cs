using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Teacher
{
    public partial class title_teacher : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            else
            {
                Session.Timeout = 60;
                string fullname = GetFullName(Session["login_id"].ToString());
                Welcome.Text = "Chào giáo viên, " + fullname.ToUpper();
                //Welcome.Text = "Chào giáo viên, " + Session["login_id"].ToString().Trim() + "!";
                // +Session["login_pass"] + Session["login_state"];
            }
        }

        static protected string GetFullName(string id)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ulogin_name"].ToString().Trim() == id.Trim())
                {
                    temp = dr["ufull_name"].ToString();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp;
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["login_state"] = "not_login";
            Session.Timeout = 5;
            Response.Redirect("~/main.aspx");
        }
    }
}