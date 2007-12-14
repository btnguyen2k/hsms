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

namespace HSMS.Pupil
{
    public partial class ScoreTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected string GetClass(string pupilid, string year)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupill_id"].ToString().Trim() == pupilid.Trim()
                    && dr["year_start"].ToString().Trim() == year.Trim())
                {
                    temp = dr["class_id"].ToString().Trim();
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        protected void ConfirmYear_Click(object sender, EventArgs e)
        {
            string classname = GetClass(Session["login_id"].ToString(), ClassYear.Text);
            if (classname == "")
            {
                ResultContent.Text = "Không có năm học này!";
                ClassYear.Text = "";
            }
            else
            {
                ClassYear.Enabled = false;
                ConfirmYear.Enabled = false;
            }
        }
    }
}
