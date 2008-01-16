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
    public partial class DetailListPupil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "DANH SÁCH HỌC SINH LỚP " + Request.QueryString.Get("id") + " NĂM HỌC " +
                          Request.QueryString.Get("year");
            int index = 0;
            ListPupil.Text = "<table width=100% border=1";
            ListPupil.Text += "<tr><td align=center>STT</td>" +
                "<td align=center>Tên học sinh</td></tr>";

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == Request.QueryString.Get("id").Trim()
                    && dr["year_start"].ToString().Trim() == Request.QueryString.Get("year").Trim())
                {
                    index++;
                    ListPupil.Text += "<tr><td align=center>" + index + "</td>";
                    GetFullName(dr["pupill_id"].ToString().Trim());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ListPupil.Text += "</table>";
        }

        protected void GetFullName(string pupil_id)
        {

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSUSer";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ulogin_name"].ToString().Trim() == pupil_id.Trim())
                {
                    string redirect_site = "DetailSearching.aspx?status=1&id=" + pupil_id.Trim();
                    ListPupil.Text += "<td align=canter><a href=" + redirect_site + ">" +
                                     dr["ufull_name"].ToString().Trim() +
                                     "</a></td></tr>";
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
