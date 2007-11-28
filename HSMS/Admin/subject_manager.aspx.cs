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

namespace HSMS.Admin
{
    public partial class class_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
            Find_Sub_Result.Text = "";
            Add_sub_result.Text = "";
            Subject_del.Visible = false;
        }

        protected void SubjectName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Find_Subject_Click(object sender, EventArgs e)
        {
            Find_Sub_Result.Text = "";
            Subject_del.Visible = false;
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                if (dr["subject_name"].ToString().Trim() == SubjectName.Text.Trim())
                {
                    count++;
                    Find_Sub_Result.Text = "Môn: " + SubjectName.Text.Trim() + ", hệ số: " +
                                           dr["subject_heso"].ToString().Trim() + "!";
                    Subject_del.Visible = true;
                }
            }
            if (count == 0)
            {
                Find_Sub_Result.Text = "Không tồn tại môn học này!";
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Add_sub_result.Text = "";
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                if (dr["subject_name"].ToString().Trim() == Subject_addname.Text.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            if (count != 0)
            {
                Add_sub_result.Text = "Môn học này đã có trong hệ thống!";
            }
            else
            {
                cm.CommandText = "INSERT INTO HSMSSubject (subject_name, subject_heso) VALUES ('" +
                                 Subject_addname.Text.Trim() + "'," + Subject_addhs.Text.Trim() + ")";
                cm.ExecuteNonQuery();
                Add_sub_result.Text = "Môn học thêm vào thành công!";
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Subject_del_Click(object sender, EventArgs e)
        {
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "DELETE FROM HSMSSubject WHERE subject_name = '" + SubjectName.Text.Trim() + "'";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            Find_Sub_Result.Text = "Xoá thành công!";
            Subject_del.Visible = false;
        }

        protected void Find_SubjectAll_Click(object sender, EventArgs e)
        {
            Find_Sub_Result.Text = "<table width=100% border=\"1\"> <tr> <td align=center>Môn học</td> <td align=center>Hệ số</td></tr>";
            
            String connStr =
                "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Find_Sub_Result.Text += "<tr><td align=center style=\"color:black\">" + dr["subject_name"].ToString().Trim() + "</td><td align=center style=\"color:black\">" +
                                        dr["subject_heso"].ToString().Trim() + "</td></tr>";
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            Find_Sub_Result.Text += "</table>";
        }
    }
}
