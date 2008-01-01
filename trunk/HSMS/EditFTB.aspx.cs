using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;


namespace HSMS
{
    public partial class EditFTB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void find_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From testFTB where id=6";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                FreeTextBox1.Text = dr["test_content"].ToString().Trim();
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }
    }
}
