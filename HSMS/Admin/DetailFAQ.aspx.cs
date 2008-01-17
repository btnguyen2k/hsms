using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class DetailFAQ : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSFAQs";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["FAQid"].ToString().Trim() == Request.QueryString.Get("id"))
                {
                    FAQQues.Text = dr["FAQQues"].ToString();
                    Email.Text = "EMAIL: " + dr["Email"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "UPDATE HSMSFAQs SET FAQAns ='" + FAQAns.Text + "', status = 1 WHERE FAQid ='" +
                             Request.QueryString.Get("id") + "'";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Result.Text = "Gởi trả lời thành công!.";
        }
    }
}