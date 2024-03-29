using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS
{
    public partial class People : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSubjectList();
            }
            Label5.Visible = false;
            SubjectDetail.Visible = false;
        }

        protected void GetSubjectList()
        {
            SubjectList.Items.Add("");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                SubjectList.Items.Add(dr["subject_name"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            SubjectList.Items.Add("Tất cả");
        }

        protected void GetDetail()
        {
            int index = 0;
            SubjectDetail.Text = "<table width=100% border=\"1\"> <tr> <td align=center>STT</td>" +
                "<td align=center>Môn học</td>" +
                "<td align=center>Số lương GV</td>" +
                "</tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT subject_id, count(subject_id) as number FROM HSMSTeacher group by subject_id order by subject_id";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                index++;
                SubjectDetail.Text += "<tr>";
                SubjectDetail.Text += "<td align=center>" + index + "</td>";
                SubjectDetail.Text += "<td align=center>" + dr["subject_id"].ToString() + "</td>";
                SubjectDetail.Text += "<td align=center>" + dr["number"].ToString() + "</td>";
                SubjectDetail.Text += "</tr>";
            }
            cm.Dispose();
            dr.Dispose();
            dr.Close();
            SubjectDetail.Text += "</table>";

        }

        protected void GetTeacherList()
        {
            int index = 0;
            TeacherTable.Text = "<table width=100% border=\"1\"> <tr> <td align=center>STT</td>" +
                "<td align=center>Tên GV</td>" +
                "<td align=center>MSGV</td>" +
                "<td align=center>Dạy môn</td>" +
                "<td align=center>Chức vụ</td>" +
                "</tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            if (SubjectList.SelectedItem.Value.Trim() != "Tất cả")
            {
                cm.CommandText = "SELECT * FROM HSMSTeacher Where subject_id ='" + SubjectList.SelectedItem.Value.Trim() + "' ORDER BY subject_id";
            }
            else
            {
                cm.CommandText = "SELECT * FROM HSMSTeacher ORDER BY subject_id";
            }
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string id = dr["teacher_id"].ToString();
                TeacherTable.Text += "<tr>";
                index++;
                TeacherTable.Text += "<td align=center>" + index + "</td>";
                OleDbCommand cm1 = new OleDbCommand();
                cm1.Connection = conn;
                cm1.CommandText = "SELECT * FROM HSMSUser";
                OleDbDataReader dr1 = cm1.ExecuteReader();
                while (dr1.Read())
                {
                    if (dr1["ulogin_name"].ToString().Trim() == id.Trim())
                    {
                        string redirect_site = "DetailSearching.aspx?status=2&id=" + id.Trim();
                        TeacherTable.Text += "<td align=center><a href = " + redirect_site.ToString() + ">" +
                            dr1["ufull_name"].ToString() + "</a></td>";
                    }
                }
                cm1.Dispose();
                dr1.Dispose();
                dr1.Close();

                TeacherTable.Text += "<td align=center style=\"color:black\">" + dr["teacher_id"].ToString().Trim() + "</td>";
                TeacherTable.Text += "<td align=center style=\"color:black\">" + dr["subject_id"].ToString().Trim() + "</td>";
                object temp = dr["position"];
                if (temp == null || temp.ToString() == "")
                {
                    TeacherTable.Text += "<td align=center style=\"color:black\">Chưa cập nhật</td>";
                }
                else
                {
                    TeacherTable.Text += "<td align=center style=\"color:black\">" + dr["position"].ToString().Trim() + "</td>";
                }
                TeacherTable.Text += "</tr>";
            }
            Label4.Text = "Có tổng cộng " + index.ToString() + " giáo viên";

            cm.Dispose();
            dr.Dispose();
            dr.Close();
            TeacherTable.Text += "</table>";
        }

        protected void SubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubjectList.SelectedItem.Value.Trim() != "")
            {
                GetTeacherList();
                if (SubjectList.SelectedItem.Value.Trim() == "Tất cả")
                {
                    Label5.Visible = true;
                    SubjectDetail.Visible = true;
                    GetDetail();
                }
            }
        }
    }
}