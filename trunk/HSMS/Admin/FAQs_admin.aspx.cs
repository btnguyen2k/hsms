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

namespace HSMS.Admin
{
    public partial class FAQs_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            ListTable.Text = "<table width=100% border=1>";
            ListTable.Text += "<tr><td align=center>Stt</td>";
            ListTable.Text += "<td align=center>Email</td>";
            ListTable.Text += "<td align=center>Ngày tháng</td></tr>";

            int index = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSFAQs ORDER BY FAQDAte DESC";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_email = dr["Email"].ToString().Trim();
                if (dr["status"].ToString().Trim() == "0")
                {
                    index++;
                    string redirect_site = "DetailFAQ.aspx?id=" + dr["FAQid"].ToString().Trim();
                    ListTable.Text += "<tr><td align=center><a href =" + redirect_site.Trim() + ">" + index + "</a></td>";
                    if (temp_email == "")
                    {
                        ListTable.Text += "<td align=center>Không có</td>";
                    }
                    else
                    {
                        ListTable.Text += "<td align=center>" + temp_email.Trim() + "</td>";
                    }
                    ListTable.Text += "<td align=center>" + dr["FAQDate"].ToString().Trim() + "</td></tr>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ListTable.Text += "</table>";
            GetAnswer();
        }

        protected void GetAnswer()
        {
            ListTable1.Text = "<table width=100% border=1>";
            ListTable1.Text += "<tr><td align=center>Stt</td>";
            ListTable1.Text += "<td align=center>Email</td>";
            ListTable1.Text += "<td align=center>Ngày tháng</td></tr>";

            int index = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSFAQs ORDER BY FAQDAte DESC";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_email = dr["Email"].ToString().Trim();
                if (dr["status"].ToString().Trim() == "1")
                {
                    index++;
                    ListTable1.Text += "<tr><td align=center>" + index + "</td>";
                    if (temp_email == "" || temp_email == null)
                    {
                        ListTable1.Text += "<td align=center>Không có</td>";
                    }
                    else
                    {
                        ListTable1.Text += "<td align=center>" + temp_email.Trim() + "</td>";
                    }
                    
                    ListTable1.Text += "<td align=center>" + dr["FAQDate"].ToString().Trim() + "</td></tr>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ListTable1.Text += "</table>";
        }
    }
}
