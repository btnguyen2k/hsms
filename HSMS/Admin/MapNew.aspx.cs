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
    public partial class MapNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            int NowMont = DateTime.Now.Month;
            if (NowMont > 9 || NowMont <= 6)
            {
                Response.Write("Đang còn trong năm học!");
            }
            else
            {
                DeleteDB();
                Response.Redirect("~/Admin/MapDetail.aspx");
            }
            //Response.Redirect("~/Admin/MapDetail.aspx");
        }

        static protected void DeleteDB()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Delete From HSMSClassRoom";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
        }
    }
}
