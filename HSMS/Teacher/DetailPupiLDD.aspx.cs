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
    public partial class DetailPupiLDD : System.Web.UI.Page
    {
        private string classname = "";
        private string year = "";
        private string hk_string = "";
        private int hk = 1;
        private string pupilid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            classname = Request.QueryString.Get("class_id");
            year = Request.QueryString.Get("year");
            hk_string = Request.QueryString.Get("hk");
            hk = Int32.Parse(hk_string);
            pupilid = Request.QueryString.Get("pupil_id");
            ResultTrack.Text = "<table width=100% border=\"1\"> <tr> <td align=center>Nội dung</td> <td align=center>Giáo viên</td></tr>";
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
                    ResultTrack.Text += "<tr><td align=center style=\"color:black\">" + dr["content"].ToString().Trim() +
                    "<td align=center style=\"color:black\"> " + temp_fullname + "</tr>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultTrack.Text += "</table>";
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
            while (dr.Read())
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
    }
}
