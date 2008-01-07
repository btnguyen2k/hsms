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
    public partial class DetailNews : System.Web.UI.Page
    {
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString.Get("newid");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSNews";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["newid"].ToString()  == id)
                {
                    title.Text = dr["title"].ToString().ToUpper();
                    ContentNews.Text = dr["NewContent"].ToString();
                    ContentNews.Text += "<br><a href=Notice.aspx>Back</a>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
