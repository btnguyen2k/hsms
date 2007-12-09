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
using HSMS.Db;

namespace HSMS.Teacher
{
    public partial class main_class_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected void ClassName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ViewClassList_Click(object sender, EventArgs e)
        {
            ResultContent.Text = "<table width=50% border=\"1\"> <tr> <td align=center>Lớp</td> <td align=center>Năm</td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim())
                {
                    ResultContent.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                    "<td align=center style=\"color:black\"> " + dr["year"].ToString().Trim() + "</tr>";
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultContent.Text += "</table>";
        }

        
        static protected bool GetReturn(int count)
        {
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool CheckClass(string classname, string year)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim()
                    && dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().ToString().Trim() == year.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return GetReturn(count);
        }

        protected void ConfirmClassList_Click(object sender, EventArgs e)
        {
            bool check_class = CheckClass(ClassName.Text, ClassYear.Text);
            if (check_class)
            {
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
                ClassListTable.Visible = true;
                int index_row = 0;
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                // View all pupil in this class
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "SELECT * FROM link_pupil_class";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == ClassName.Text.Trim()
                    &&  dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                    {
                        index_row++;
                    }
                }

                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Dispose();
                conn.Close();
            }
            else
            {
                ResultContent.Text = "Lớp không hợp lệ!!!";
                ClassName.Text = "";
                ClassYear.Text = "";
            }
        }
    }
}
