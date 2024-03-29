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

namespace HSMS.Teacher
{
    public partial class Track_learning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            Notice.Text = "Đây là phần ghi chú giành cho giáo viên đối với các học sinh." +
                " Gồm những sai pham hay những biểu hiện tốt của 1 học sinh," +
                " để cuối học kỳ có thể căn cứ vào đây mà xếp loại hạnh kiểm.<br>";
            Notice.Text += "(vd: Học sinh A vào ngày xx/xx/xxxx đi học trễ)";
            if (DateTime.Now.Month < 6)
            {
                int temp = DateTime.Now.Year - 1;
                ClassYear.Text = temp.ToString();
            }
            else
            {
                ClassYear.Text = DateTime.Now.Year.ToString();
            }

            if (!IsPostBack)
            {
                GetClassList();
            }
        }

        protected void GetClassList()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select DISTINCT class_id From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                ClassName.Items.Add(dr["class_id"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        static protected bool GetReturn(int count)
        {
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static protected bool Check_ExistClass(string name_check, string year_check)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == name_check.Trim()
                    && dr["year"].ToString().Trim() == year_check.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return GetReturn(count);
        }

        protected void ViewClassList_Click(object sender, EventArgs e)
        {
            ResultContent.Text = "<table width=50% border=\"1\"> <tr> <td align=center>Lớp</td> <td align=center>Năm</td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                // nen check la giao vien co day lop nay hay ko
                ResultContent.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                    "<td align=center style=\"color:black\"> " + dr["year"].ToString().Trim() + "</tr>";
                
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultContent.Text += "</table>";
        }

        protected void Check_Class_Click(object sender, EventArgs e)
        {
            bool check_class = Check_ExistClass(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim());
            if (check_class)
            {
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
                Check_Class.Enabled = false;
                ViewClassList.Enabled = false;
                Label3.Visible = true;
                mshs.Visible = true;
                Check_id.Visible = true;
                ViewPupilList.Visible = true;
                HK_Select.Visible = true;
                ResultContent.Text = "";
                mshs.Text = ClassName.SelectedItem.Value.Trim() + ClassYear.Text.Substring(2,2).Trim();
            }
            else
            {
                ResultContent.Text = "Không có lớp học này!!!";
            }
        }

        static protected string GetFullName(string id)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSUSer";
            OleDbDataReader dr = cm.ExecuteReader();
            while(dr.Read())
            {
                if (dr["ulogin_name"].ToString().Trim() == id.Trim())
                {
                    temp = dr["ufull_name"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp.Trim();
        }
        
        protected void ViewPupilList_Click(object sender, EventArgs e)
        {
            ResultTracking.Text = "<table width=50% border=\"1\"> <tr> <td align=center>Tên</td> <td align=center>MSHS</td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                {
                    string temp_id = dr["pupill_id"].ToString().Trim();
                    string temp_fullname = GetFullName(temp_id);
                    ResultTracking.Text += "<tr><td align=center style=\"color:black\">" + temp_fullname +
                    "<td align=center style=\"color:black\"> " + temp_id + "</tr>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultTracking.Text += "</table>";
        }

        protected bool CheckPupilId(string id)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year_start"].ToString().Trim() == ClassYear.Text
                    && dr["pupill_id"].ToString().Trim() == id.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return GetReturn(count);
        }

        protected int GetHK()
        {
            int temp = 1;
            switch (HK_Select.SelectedIndex)
            {
                case 0:
                    {
                        temp = 1;
                        break;
                    }
                case 1:
                    {
                        temp = 2;
                        break;
                    }
            }
            return temp;
        }

        protected bool CheckTeacher(string id)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year"].ToString().Trim() == ClassYear.Text
                    && dr["teacher_id"].ToString().Trim() == id.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return GetReturn(count);
        }
        
        protected void  ViewTrackPupil(string classname, string year, string pupilid, int hk, string teacher_id)
        {
            ResultTracking.Text = "Những đánh giá về học sinh này.<br>";
            ResultTracking.Text += "<table width=100% border=\"1\"> <tr> <td align=center>Nội dung</td> <td align=center>Giáo viên</td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSPupilTrackLearning";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname
                    && dr["year"].ToString().Trim() == year
                    && dr["pupil_id"].ToString().Trim() == pupilid
                    && dr["hk"].ToString().Trim() == hk.ToString().Trim()
                    )
                {
                    string temp_fullname = GetFullName(dr["teacher_id"].ToString());
                    ResultTracking.Text += "<tr><td align=center style=\"color:black\">" + dr["content"].ToString().Trim() +
                    "<td align=center style=\"color:black\"> " + temp_fullname +  "</tr>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultTracking.Text += "</table>";
        }

        protected void Check_id_Click(object sender, EventArgs e)
        {
            ResultTracking.Text = "";
            bool check_id = CheckPupilId(mshs.Text);
            if (check_id)
            {
                mshs.Enabled = false;
                HK_Select.Enabled = false;
                Check_id.Enabled = false;
                ViewPupilList.Enabled = false;
                AddContent.Visible = true;
                Content.Visible = true;
                ChangePupil.Visible = true;
                ChangeClass.Visible = true;
                bool check_teacher = CheckTeacher(Session["login_id"].ToString().Trim());
                if (check_teacher)
                {
                    int hk = GetHK();
                    ViewTrackPupil(ClassName.SelectedItem.Value.Trim(), ClassYear.Text, mshs.Text, hk, Session["login_id"].ToString().Trim());
                }
            }
            else
            {
                ResultTracking.Text = "Lớp học ko có học sinh này!!!";
                mshs.Text = "";
            }
        }

        protected void ChangePupil_Click(object sender, EventArgs e)
        {
            mshs.Text = "";
            mshs.Enabled = true;
            HK_Select.Enabled = true;
            Check_id.Enabled = true;
            ViewPupilList.Enabled = true;
            AddContent.Visible = false;
            Content.Visible = false;
            ChangePupil.Visible = false;
            ChangeClass.Visible = false;
            ResultTracking.Text = "";
        }

        protected void ChangeClass_Click(object sender, EventArgs e)
        {
            mshs.Text = "";
            mshs.Enabled = true;
            HK_Select.Enabled = true;
            Check_id.Enabled = true;
            ViewPupilList.Enabled = true;
            AddContent.Visible = false;
            Content.Visible = false;
            ChangePupil.Visible = false;
            ChangeClass.Visible = false;
            ResultTracking.Text = "";
            
            mshs.Visible = false;
            ResultContent.Text = "";
            HK_Select.Visible = false;
            Label3.Visible = false;
            Check_id.Visible = false;
            ViewPupilList.Visible = false;
            ClassName.Enabled = true;
            ClassYear.Enabled = true;
            Check_Class.Enabled = true;
            ViewClassList.Enabled = true;
        }

        protected void AddContent_Click(object sender, EventArgs e)
        {
            int hk = GetHK();
            
            string temp_teacherid = Session["login_id"].ToString().Trim();
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "INSERT INTO HSMSPupilTrackLearning VALUES ('" +
                             ClassName.SelectedItem.Value.Trim() + "','" + ClassYear.Text + "','" +
                             mshs.Text + "'," + hk + ",'" + temp_teacherid + "','" +
                             Content.Text + "')";
            cm.ExecuteNonQuery();
            
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Content.Text = "";
            AddResult.Text = "Thêm vào thành công!";
        }
    }
}
