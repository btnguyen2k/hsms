using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.TEST
{
    public partial class showthongtin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From testFTB where id=16";
            OleDbDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                Test_title.Text = dr["Title"].ToString().Trim();
                Test_content.Text = dr["Test_content"].ToString().Trim();
                File_Upload.Text = dr["FileUpload"].ToString().Trim();
                image_upload.ImageUrl = "~/images/"+ File_Upload.Text+"";
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }
    }
}
