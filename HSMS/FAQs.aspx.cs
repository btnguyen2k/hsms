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
    public partial class FAQs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetListFAQ();
        }

        protected void GetListFAQ()
        {
            ContentQA.Text = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSFAQs ORDER BY FAQDate DESC";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["status"].ToString().Trim() == "1")
                {
                    ContentQA.Text += "Q: " + dr["FAQQues"].ToString() + "<br>";
                    ContentQA.Text += "A: " + dr["FAQAns"].ToString() + "<br><br>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void SubmitFAQ_Click(object sender, EventArgs e)
        {
            int status = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "INSERT INTO HSMSFAQs (FAQQues, status, FAQDate, Email) VALUES ('" +
                             ContentFAQ.Text + "'," + status + ",'" + DateTime.Now + "','" + EmailFAQ.Text + "')";
            cm.ExecuteNonQuery();

            conn.Dispose();
            conn.Close();
            conn.Dispose();
            conn.Close();
            Result.Text += "Câu hỏi đã gởi tới ban quản trị. Chúng tôi sẽ trả lời sớm nhất.";
        }
    }
}
