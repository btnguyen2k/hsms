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
    public partial class DetailPupilTBMK : System.Web.UI.Page
    {
        private string classname = "";
        private string year = "";
        private string hk_string = "";
        private int hk = 1;
        private string pupilid = "";
        private string subject = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            classname = Request.QueryString.Get("class_id");
            year = Request.QueryString.Get("year");
            hk_string = Request.QueryString.Get("hk");
            hk = Int32.Parse(hk_string);
            pupilid = Request.QueryString.Get("pupil_id");
            subject = Request.QueryString.Get("subject_id");
            //Response.Write(classname + "<br>");
            //Response.Write(year + "<br>");
            //Response.Write(hk.ToString() + "<br>");
            //Response.Write(pupilid + "<br>");
            //Response.Write(subject + "<br>");
            GetFullName(pupilid);
            
            Response.Write("Diem M:  ");
            GetScoreDetail(pupilid, classname, year, subject, hk, "M");
            Response.Write("Diem 15':  ");
            GetScoreDetail(pupilid, classname, year, subject, hk, "15");
            Response.Write("Diem 1 tiet :  ");
            GetScoreDetail(pupilid, classname, year, subject, hk, "1T");
            Response.Write("Diem thi HK :  ");
            GetScoreDetail(pupilid, classname, year, subject, hk, "HK");
         }

        protected void GetScoreDetail(string id, string classname, string year, string subjectname, int hk, string mode)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubjectScore";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == id.Trim()
                    && dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["subject_id"].ToString().Trim() == subjectname.Trim()
                    && dr["HK"].ToString().Trim() == hk.ToString().Trim()
                    && dr["test_mode"].ToString().Trim() == mode.Trim())
                {
                    Response.Write(dr["score"].ToString().Trim() + "            ");
                }
            }
            Response.Write("<br>");
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void GetFullName(string pupilid)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSUSer";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ulogin_name"].ToString().Trim() == pupilid.Trim())
                {
                    temp = dr["ufull_name"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            Response.Write("Hoc sinh " + temp.ToUpper() + ":<br>");
        }
    }
}
