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
    public partial class DetailSearching : System.Web.UI.Page
    {
        private string status, ms;
        protected void Page_Load(object sender, EventArgs e)
        {
            status = Request.QueryString.Get("status");
            ms = Request.QueryString.Get("id");
            GetShareInformation();
            Result.Text = "<table border=1 width=100%>";
            if (status == "1")
            {
                GetDetailPupil();
            }
            else
            {
                GetDetailTeacher();
            }
            Result.Text += "</table>";
        }

        protected void GetShareInformation()
        {
            
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSUser";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ulogin_name"].ToString().Trim() == ms.Trim())
                {
                    Result.Text += "<tr><td align=left>TÊN HỌ ĐẦY ĐỦ</td>";
                    Result.Text += "<td align=left>" + dr["ufull_name"].ToString().Trim() + "</td></tr>";

                    Result.Text += "<tr><td align=left>MÃ SỐ</td>";
                    Result.Text += "<td align=left>" + ms.Trim() + "</td></tr>";

                    Result.Text += "<tr><td align=left>NGÀY THÁNG NĂM SINH</td>";
                    Result.Text += "<td align=left>" + dr["udob_day"].ToString().Trim() + "/" +
                        dr["udob_mont"].ToString().Trim() + "/" + dr["udob_year"].ToString().Trim() + "</td></tr>";

                    Result.Text += "<tr><td align=left>EMAIL</td>";
                    object temp_email = dr["uemail"];
                    if (temp_email != null)
                    {
                        Result.Text += "<td align=left>" + temp_email.ToString() + "</td></tr>";
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        static protected string GetClassName(string id)
        {
            string temp = "";
            int temp_date = DateTime.Now.Year;
            if (DateTime.Now.Month < 7)
            {
                temp_date -= 1;
            }
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupill_id"].ToString().Trim() == id
                    && dr["year_start"].ToString().Trim() == temp_date.ToString().Trim())
                {
                    temp = dr["class_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        protected void GetDetailPupil()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSPupil";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupill_id"].ToString().Trim() == ms.Trim())
                {
                    Result.Text += "<tr><td align=left>Theo học trường từ năm</td>";
                    Result.Text += "<td align=left>" + dr["enroll_year"].ToString().Trim() + "</td></tr>";

                    Result.Text += "<tr><td align=left>Hiện đang học lớp</td>";
                    Result.Text += "<td align=left>" + GetClassName(ms.Trim()) + "</td></tr>";
                                        
                    object temp_position = dr["Position"];
                    if (temp_position != null && temp_position.ToString().Trim() != "")
                    {
                        Result.Text += "<tr><td align=left>Chức vụ hiện tại trong lớp</td>";
                        Result.Text += "<td align=left>" + temp_position.ToString() + "</td></tr>";
                    }

                    object temp_history = dr["history"];
                    if (temp_history != null && temp_history.ToString().Trim() != "")
                    {
                        Result.Text += "<tr><td align=left>Thành tích cá nhân</td>";
                        Result.Text += "<td align=left>" + temp_history.ToString() + "</td></tr>";
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        static protected string GetMainClass(string id)
        {
            string temp = "";
            int temp_date = DateTime.Now.Year;
            if (DateTime.Now.Month < 7)
            {
                temp_date -= 1;
            }
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSCLass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == id
                    && dr["year"].ToString().Trim() == temp_date.ToString().Trim())
                {
                    temp = dr["class_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        protected void GetDetailTeacher()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSTeacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == ms.Trim())
                {
                    Result.Text += "<tr><td align=left>Theo dạy trường từ năm</td>";
                    Result.Text += "<td align=left>" + dr["year_start"].ToString().Trim() + "</td></tr>";

                    Result.Text += "<tr><td align=left>Dạy môn</td>";
                    Result.Text += "<td align=left>" + dr["subject_id"].ToString().Trim() + "</td></tr>";

                    Result.Text += "<tr><td align=left>Hiện đang là chủ nhiệm lớp</td>";
                    Result.Text += "<td align=left>" + GetMainClass(ms.Trim()) + "</td></tr>";

                    object temp_position = dr["position"];
                    if (temp_position != null && temp_position.ToString().Trim() != "")
                    {
                        Result.Text += "<tr><td align=left>Chức vụ trong trường hiện tại là</td>";
                        Result.Text += "<td align=left>" + temp_position.ToString() + "</td></tr>";
                    }
                                        
                    object temp_history = dr["history"];
                    if (temp_history != null && temp_history.ToString().Trim() != "")
                    {
                        Result.Text += "<tr><td align=left>Thành tích cá nhân</td>";
                        Result.Text += "<td align=left>" + temp_history.ToString() + "</td></tr>";
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }
    }
}
