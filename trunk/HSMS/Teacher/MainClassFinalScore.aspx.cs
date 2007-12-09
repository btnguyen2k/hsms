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
    public partial class MainClassFinalScore : System.Web.UI.Page
    {
        private string[] subjectlist = new string[15];
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
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

        protected bool CheckClass(string classname, string year)
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
                if (dr["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim()
                    && dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().ToString().Trim() == year.Trim())
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
        protected void MainClassList_Click(object sender, EventArgs e)
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
                if (dr["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim())
                {
                    ResultContent.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                    "<td align=center style=\"color:black\"> " + dr["year"].ToString().Trim() + "</tr>";
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultContent.Text += "</table>";
        }

        protected int GetHK()
        {
            int temp = 1;
            switch(HK_Select.SelectedIndex)
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

        protected int initTable(string classname, string classyear)
        {
            int subject_index = 0;
            ResultContent.Text = "<table border=\"1\" id=\"TableScore\" runat=\"server\">" +
                                 "<tr><td align = \"center\" nowrap=\"nowrap\" style=\"color:black\" readonly>STT</td> " +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Tên HS</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>MSHS</td>";
            // List all subject
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT DISTINCT subject_id, class_id, year FROM HSMSClassSchedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_subject = dr["subject_id"].ToString().Trim();
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == classyear.Trim()
                    && dr["subject_id"].ToString().Trim() != "" )
                {
                    subject_index++;
                    string name_subject = "Subject" + subject_index.ToString().Trim();
                    
                    //ResultContent.Text += "<td>" +
                    //    "<input id=\"" + name_subject.Trim() +
                    //    "\" type=\"text\" name=\"" + name_subject.Trim() + "\" readonly value=\"" +
                    //    temp_subject.Trim() +
                    //    "\"style=\"width:40px\" runat = \"server\"/>" +
                    //    "</td>";
                                        
                    ResultContent.Text += "<td id=\"" + name_subject.Trim() +
                        "\" name=\"" + name_subject.Trim() + 
                        "\" align=center style=\"color:black\" readonly>" + 
                        dr["subject_id"].ToString().Trim() + "</td>";

                    subjectlist[subject_index] = temp_subject.Trim();
                    //Response.Write(subject_index.ToString() + dr["subject_id"].ToString().Trim() + "<br>");
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            ResultContent.Text += "<td  align = \"center\" style=\"color:black\" readonly>TBHK </td>" +
                           "<td  align = \"center\" style=\"color:black\" readonly>Đạo đức </td>" +
                           "<td  align = \"center\" style=\"color:black\" readonly>Xếp loại </td>" +
                           "</tr>";
            return subject_index;
        }

        protected string GetFullName(string id)
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

        protected double GetMark(string classname, string year, int hk, string pupilid, string subjectname)
        {
            double temp = -1;
            string string_mark = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubjectTBMHKScore";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim() 
                    && dr["HK"].ToString().Trim() == hk.ToString().Trim()
                    && dr["subject_id"].ToString().Trim() == subjectname.Trim())
                {
                    string_mark = dr["average_scoreI"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            if (string_mark != "")
            {
                temp = Double.Parse(string_mark.Trim());
            }
            return temp;
        }

        protected int GetSubjectHeso(string subject)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while(dr.Read())
            {
                if (dr["subject_name"].ToString().Trim() == subject.Trim())
                {
                    temp = dr["subject_heso"].ToString().Trim();
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return Int32.Parse(temp);
        }

        protected void CreateNewRow(int row, string classname,string classyear, string pupilid, int hk, int subjectcount)
        {
            ResultContent.Text += "<tr>";
            ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + row.ToString() + "</td>" ;
            string name = GetFullName(pupilid);
            ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + name + "</td>";
            ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + pupilid.Trim() + "</td>";

            // hien thi diem
            bool check_finish = true;
            double total_mark = 0;
            int hesochia = 0;
            for (int i = 1; i <= subjectcount; i++)
            {
                string temp_subject_name = "";
                //if (IsPostBack)
                //{
                    temp_subject_name = subjectlist[i];
                //}
                //else
                //{
                //    string temp_index = "Subject" + i.ToString();
                //    temp_subject_name = Request.Form[temp_index];
                //}
                
                double temp_mark = GetMark(classname, classyear, hk, pupilid, temp_subject_name);

                
                if (temp_mark != -1)
                {
                    ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + temp_mark + "</td>";
                    int temp_heso = GetSubjectHeso(temp_subject_name);
                    total_mark += temp_mark*temp_heso;
                    hesochia += temp_heso;
                }
                else
                {
                    ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>X</td>";
                    check_finish = false;
                }
            }
            if (check_finish)
            {
                // tinh diem tong ket ca hoc ki
                total_mark = total_mark/hesochia;
                total_mark = Math.Round(total_mark, 1);
                ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + total_mark + "</td>";
            }
            else
            {
                // chua cap nhat diem hoc ky
                ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>X</td>";
            }

            ResultContent.Text += "</tr>";
        }

        protected void ViewClassList_Click(object sender, EventArgs e)
        {
            bool check_class = CheckClass(ClassName.Text, ClassYear.Text);
            if (check_class)
            {
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
                HK_Select.Enabled = false;
                ViewClassList.Enabled = false;
                MainClassList.Enabled = false;

                int totalsubject = initTable(ClassName.Text, ClassYear.Text);
                //Response.Write(totalsubject.ToString());

                int index_row = 0;
                int hk = GetHK();
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "SELECT * FROM link_pupil_class";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == ClassName.Text.Trim()
                        && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                    {
                        index_row++;
                        CreateNewRow(index_row, ClassName.Text, ClassYear.Text, dr["pupill_id"].ToString().Trim(), hk, totalsubject );
                    }
                }
                ResultContent.Text += "</table>";

                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Dispose();
                conn.Close();

            }
            else
            {
                ResultContent.Text = "Lớp không hợp lệ!!!";
                ClassName.Text = "";
                ClassYear.Text = "";
            }
        }
    }
}
