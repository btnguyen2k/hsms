using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class DetailNews : Page
    {
        private string id;
        private int id_int;
        //private string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            id = Request.QueryString.Get("newid");

            //title = Request.QueryString.Get("title").ToString();
            if (!IsPostBack)
            {
                GetNews();
            }
        }

        protected void GetNews()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSNews";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["newid"].ToString() == id)
                {
                    NewTitle.Text = dr["title"].ToString();
                    FreeTextBox1.Text = dr["NewContent"].ToString();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void NewSave_Click(object sender, EventArgs e)
        {
            if (ImageUpLoad.HasFile)
            {
                ImageUpLoad.SaveAs(@"~\images\" + ImageUpLoad.FileName);
            }
            if (FileUpLoad1.HasFile)
            {
                FileUpLoad1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + FileUpLoad1.FileName);
                //FileUpLoad1.SaveAs(@"~\Files\" + FileUpLoad1.FileName);
            }

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            id = Request.QueryString.Get("newid");
            Response.Write(id.Trim());
            id_int = Int32.Parse(id);
            cm.CommandText =
                "UPDATE HSMSNews SET title = N'" + NewTitle.Text + "', image ='" +
                ImageUpLoad.FileName + "', NewContent = N'" + FreeTextBox1.Text +
                "', NewFile_upload = '" + FileUpLoad1.FileName + "',Userid = N'" +
                Session["login_id"] + "', Time = '" + DateTime.Now + "' WHERE newid = " +
                id_int; 
            cm.ExecuteNonQuery();
            
            cm.Dispose();
            conn.Close();
            conn.Dispose();

            ResultAction.Text = "Sữa thông báo thành công!";
            //NewTitle.Text = "";
            //FreeTextBox1.Text = "";
        }

        protected void DeleteNews_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            
            cm.CommandText = "Delete from HSMSNews where newid =" + id;
            cm.ExecuteNonQuery();
            
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            Response.Redirect("EditNews.aspx");
        }
    }
}