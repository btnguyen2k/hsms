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

namespace HSMS
{
    public partial class Notice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NoticeTable.Text = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSNews ORDER BY Time DESC";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string redirect_site = "DetailNews.aspx?newid=" + dr["newid"].ToString();
                NoticeTable.Text += "*&nbsp;&nbsp;" + "<a href=\"" + redirect_site + "\">" + dr["title"].ToString() +
                                    "</a>";
                for (int i=0;i<= 15;i++)
                {
                    NoticeTable.Text += "&nbsp;";
                }
                NoticeTable.Text += "<br><br>";
                //NoticeTable.Text += "(" + dr["Time"].ToString() + ")<br><br>";
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
