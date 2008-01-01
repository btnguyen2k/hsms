using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewSave_Click(object sender, EventArgs e)
        {
            if (ImageUpLoad.HasFile)
            {
                ImageUpLoad.SaveAs(@"F:\HSMS\HSMS\images\" + ImageUpLoad.FileName);
            }
            if (FileUpLoad1.HasFile)
            {
                FileUpLoad1.SaveAs(@"F:\HSMS\HSMS\Files\" + FileUpLoad1.FileName);
            }

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText =
                    "INSERT INTO HSMSNews (NewTitle,NewImage,NewContent,File_Upload) VALUES (N'" + NewTitle.Text
 + "',N'" + ImageUpLoad.FileName + "',N'" + FreeTextBox1.Text + "',N'" + FileUpLoad1.FileName + "')";

            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
