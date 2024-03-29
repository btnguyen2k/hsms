using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Admin
{
    public partial class class_manager : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            Find_Sub_Result.Text = "";
            Add_sub_result.Text = "";
            Subject_del.Visible = false;
            if (!IsPostBack)
            {
                GetSubjectList();
            }
        }

        protected void GetSubjectList()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "select * from hsmssubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                SubjectName.Items.Add(dr["subject_name"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Find_Subject_Click(object sender, EventArgs e)
        {
            Find_Sub_Result.Text = "";
            Subject_del.Visible = false;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                if (dr["subject_name"].ToString().Trim() == SubjectName.SelectedItem.Value.Trim())
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
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
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
                int intValue;
                if (Int32.TryParse(Subject_addhs.Text, out intValue))
                {
                    if (Int32.Parse(Subject_addhs.Text) > 0 && Int32.Parse(Subject_addhs.Text) < 4)
                    {
                        cm.CommandText = "INSERT INTO HSMSSubject (subject_name, subject_heso) VALUES ('" +
                                         Subject_addname.Text.Trim() + "'," + Subject_addhs.Text.Trim() + ")";
                        cm.ExecuteNonQuery();
                        Add_sub_result.Text = "Môn học thêm vào thành công!";
                    }
                    else
                    {
                        Add_sub_result.Text = "Hệ số môn học không dúng!!";
                        Subject_addhs.Text = "";
                    }
                }
                else
                {
                    Add_sub_result.Text = "Hệ số môn học không dúng!!";
                    Subject_addhs.Text = "";

                }
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Subject_del_Click(object sender, EventArgs e)
        {
            
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "DELETE FROM HSMSSubject WHERE subject_name = '" + SubjectName.SelectedItem.Value.Trim() + "'";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            Find_Sub_Result.Text = "Xoá thành công!";
            Subject_del.Visible = false;
        }
    }
}