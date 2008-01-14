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
            if (status == "1")
            {
                GetDetailPupil();
            }
            else
            {
                GetDetailTeacher();
            }
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
                    Response.Write("TÊN HỌ ĐẦY ĐỦ: " + dr["ufull_name"].ToString().Trim() + "<br>");
                    Response.Write("MÃ SỐ: " + ms.Trim() + "<br>" );
                    Response.Write("NGÀY THÁNG NĂM SINH: " + dr["udob_day"].ToString().Trim() + "/" +
                        dr["udob_mont"].ToString().Trim() + "/" + dr["udob_year"].ToString().Trim() + "<br>");
                    Response.Write("Email: " + dr["uemail"].ToString().Trim() + "<br>");
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
                    Response.Write("Theo học trường từ năm: " + dr["enroll_year"].ToString().Trim() + "<br>");
                    Response.Write("Hiện đang học lớp: " + GetClassName(ms.Trim()) + "<br>");
                    Response.Write("Chức vụ hiện tại trong lớp:" + dr["Position"].ToString() + "<br>");
                    Response.Write("Thành tích cá nhận: " + dr["history"].ToString().Trim() + "<br>");
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
                    Response.Write("Theo dạy trường từ năm: " + dr["year_start"].ToString().Trim() + "<br>");
                    Response.Write("Dạy môn: " + dr["subject_id"].ToString().Trim() + "<br>");
                    Response.Write("Hiện đang là chủ nhiệm lớp: " + GetMainClass(ms.Trim()) + "<br>");
                    Response.Write("Chức vụ trong trường hiện tại là:" + dr["position"].ToString() + "<br>");
                    Response.Write("Thành tích cá nhận: " + dr["history"].ToString().Trim() + "<br>");
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
