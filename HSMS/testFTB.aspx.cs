using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS
{
    public partial class testFTB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {

                FileUpLoad1.SaveAs(@"F:\HSMS\HSMS\temp\" + FileUpLoad1.FileName);
                
            }

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText =
                    "INSERT INTO testFTB (title,test_content,fileupload) VALUES (N'" + title.Text
 + "',N'"+ FreeTextBox1.Text +"',N'" + FileUpLoad1.FileName + "')";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
