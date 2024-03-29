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
    public partial class PupilInformation : System.Web.UI.Page
    {
        private int CurrentDate = DateTime.Now.Year;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Month < 7)
            {
                CurrentDate -= 1;
            }
            if (!IsPostBack)
            {
                GetInformation(CurrentDate);
                GetListYear();
            }
        }

        protected void GetListYear()
        {
            for (int i=CurrentDate; i >= CurrentDate-10; i--)
            {
                YearList.Items.Add(i.ToString());
            }
        }

        static protected int GetCountPupil(string Information, int year)
        {
            int count_index = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while( dr.Read())
            {
                string temp_check = dr["class_id"].ToString().Trim();
                if (Information == "all")
                {
                    if (dr["year_start"].ToString().Trim() == year.ToString().Trim())
                    {
                        count_index++;
                    }
                }
                if (Information == "10" || Information == "11" || Information == "12")
                {
                    if (dr["year_start"].ToString().Trim() == year.ToString().Trim()
                        && dr["class_id"].ToString().Substring(0,2) == Information)
                    {
                        count_index++;
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return count_index;
        }

        static protected int GetCountClass(string Information, int year)
        {
            int count_index = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_check = dr["class_id"].ToString().Trim();
                if (Information == "all")
                {
                    if (dr["year"].ToString().Trim() == year.ToString().Trim())
                    {
                        count_index++;
                    }
                }
                if (Information == "10" || Information == "11" || Information == "12")
                {
                    if (dr["year"].ToString().Trim() == year.ToString().Trim()
                        && dr["class_id"].ToString().Substring(0, 2) == Information)
                    {
                        count_index++;
                    }
                }
               
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return count_index;
        }
        
        static protected int GetDetailCountPupil(string classname, int year)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname
                    && dr["year_start"].ToString().Trim() == year.ToString().Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return count;
        }

        static protected void GetDetail(Label text_table, string khoi, int year)
        {
            text_table.Text = "<table width=100% border=1>";
            text_table.Text += "<tr> <td align=center> Tên lớp </td>" +
                            "<td align=center> Số học sinh </td>" +
                            "<td align=center> GVCN </td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_class = dr["class_id"].ToString().Trim();
                object temp_teacher = dr["teacher_id"];
                if (temp_class.Substring(0,2) == khoi 
                    && dr["year"].ToString().Trim() == year.ToString().Trim())
                {
                    string redirect_site = "DetailListPupil.aspx?id=" + temp_class.Trim() + "&year=" +
                                           year.ToString().Trim();
                    text_table.Text += "<tr> <td align=center><a href =" + redirect_site + ">"  + temp_class.Trim() + "</a></td>";
                    text_table.Text += "<td align=center>" + GetDetailCountPupil(temp_class, year) + "</td>";
                    if (temp_teacher != null && temp_teacher.ToString().Trim() != "" )
                    {
                        text_table.Text += "<td align=center>" + temp_teacher.ToString().Trim() + "</td></tr>";
                    }
                    else
                    {
                        text_table.Text += "<td align=center>Chưa cập nhật</td></tr>";
                    }
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            text_table.Text += "</table>";
        }

        protected void GetInformation(int year)
        {
            Label1.Text = "NĂM HỌC " + year;
            Label3.Text = "Tổng số lớp " + GetCountClass("all", year);
            Label2.Text = "Trường có tổng cộng " + GetCountPupil("all", year) + " học sinh.";
            DetailK.Text = "<table width=100% border=1>";
            DetailK.Text += "<tr> <td align=center> Khối </td>" +
                            "<td align=center> Số lớp </td>" +
                            "<td align=center> Số học sinh </td></tr>";

            string redirect_site = "PupilInformation.aspx#" + "K10";
            DetailK.Text += "<tr> <td align=center><a href =" + redirect_site + "> 10 </a></td>" +
                            "<td align=center>" + GetCountClass("10", year)  + "</td>" +
                            "<td align=center>" + GetCountPupil("10", year)  + "</td></tr>";
            redirect_site = "PupilInformation.aspx#" + "K11";
            DetailK.Text += "<tr> <td align=center><a href =" + redirect_site + "> 11 </a></td>" + 
                            "<td align=center>" + GetCountClass("11", year) + "</td>" +
                            "<td align=center>" + GetCountPupil("11", year) + "</td></tr>";
            redirect_site = "PupilInformation.aspx#" + "K12";
            DetailK.Text += "<tr> <td align=center><a href =" + redirect_site + "> 12 </a></td>" + 
                            "<td align=center>" + GetCountClass("12", year) + "</td>" +
                            "<td align=center>" + GetCountPupil("12", year) + "</td></tr>";
            DetailK.Text += "</table>";
            GetDetail(DetailK10, "10", year);
            GetDetail(DetailK11, "11", year);
            GetDetail(DetailK12, "12", year);
        }

        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInformation(Int32.Parse(YearList.SelectedItem.Value));
        }
    }
}
