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
    public partial class tablescore_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
        }

        protected void View_ClassTeaching_Click(object sender, EventArgs e)
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

        protected bool  Check_ExistClass(string name_check, string year_check)
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
                if ( dr["class_id"].ToString().Trim() == name_check.Trim()
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
            if (count == 0) 
            {
                return false; 
            }
            else
            {
                return true;
            }
        }

        protected void Confirm_ClassName_Year_Click(object sender, EventArgs e)
        {
            bool check_class = Check_ExistClass(ClassName.Text.Trim(), ClassYear.Text.Trim());
            if (check_class)
            {
                Label3.Visible = true;
                SubjectName.Visible = true;
                Confirm_ClassSubject.Visible = true;
                SubjectList.Visible = true;
                HK_Select.Visible = true;
                ClassName.ReadOnly = true;
                ClassYear.ReadOnly = true;
                Confirm_ClassName_Year.Visible = false;
            }
            else
            {
                ResultContent.Text = "Không có lớp học này!!!";
                ClassName.Text = "";
                ClassYear.Text = "";
            }
        }

        protected void SubjectList_Click(object sender, EventArgs e)
        {
            ResultAction.Text = "<table width=30% border=\"1\"> <tr> <td align=center>Môn học</td></tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT DISTINCT subject_id, class_id, year FROM HSMSClassSchedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while( dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.Text.Trim()
                    && dr["year"].ToString().Trim() == ClassYear.Text.Trim())
                {
                    ResultAction.Text += "<tr><td align=center style=\"color:black\">" +
                                         dr["subject_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            ResultAction.Text += "</table>";
        }

        protected bool Check_ExistSubject(string subject_check, string name_check, string year_check)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClassSchedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == name_check.Trim()
                    && dr["year"].ToString().Trim() == year_check.Trim()
                    && dr["subject_id"].ToString().Trim() == subject_check.Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void initTable()
        {
            ResultScore.Text = "<table border=\"1\" id=\"TableScore\" runat=\"server\">" +
                           "<tr><td align = \"center\" nowrap=\"nowrap\" readonly>STT</td> " +
                           "<td  align = \"center\" readonly>Tên HS</td>" +
                           "<td  align = \"center\" readonly>MSHS</td>" +
                           "<td  align = \"center\" readonly>M</td>" +
                           "<td  align = \"center\" readonly>M</td>" +
                           "<td  align = \"center\" readonly>M</td>" +
                           "<td  align = \"center\" readonly>15' </td>" +
                           "<td  align = \"center\" readonly>15' </td>" +
                           "<td  align = \"center\" readonly>15' </td>" +
                           "<td  align = \"center\" readonly>15' </td>" +
                           "<td  align = \"center\" readonly>15' </td>" +
                           "<td  align = \"center\" readonly>1T </td>" +
                           "<td  align = \"center\" readonly>1T </td>" +
                           "<td  align = \"center\" readonly >1T </td>" +
                           "<td  align = \"center\" readonly>1T </td>" +
                           "<td  align = \"center\" readonly>1T </td>" +
                           "<td  align = \"center\" readonly>1T </td>" +
                           "<td  align = \"center\" readonly>1T </td>" +
                           "<td  align = \"center\" readonly>TBM </td>" +
                           "<td  align = \"center\" readonly>HK </td>" +
                           "<td  align = \"center\" readonly>TBM HK </td>" +
                           "</tr>";
        }

        protected bool CheckExistAverageScore(string classid, string year, string subject, int HK, string pupilid)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubjectAverageScore";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["class_id"].ToString().Trim() == classid.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["subject_id"].ToString().Trim() == subject.Trim()
                    && dr["HK"].ToString().Trim() == HK.ToString().Trim())
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected string GetExistAverageScore(string classid, string year, string subject, int HK, string pupilid)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubjectAverageScore";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["class_id"].ToString().Trim() == classid.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["subject_id"].ToString().Trim() == subject.Trim()
                    && dr["HK"].ToString().Trim() == HK.ToString().Trim())
                {
                    return dr["average_score"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return "";
        }

        protected void CreateNewRow(int row,string fullname, string id, int HK)
        {
            ResultScore.Text += "<tr>";

            string temp = "STT" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"STT\" readonly value=\"" + row.ToString() +
            "\"style=\"width:20px\" runat = \"server\"/>" +
            "</td>";
            
            temp = "Name" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"STT\" " + "value=\"" + fullname.Trim() +
            "\"readonly style=\"width:140px\" runat = \"server\"/>" +
            "</td>";

            temp = "MSHS" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"STT\" " + "value=\"" + id.Trim() +
            "\"readonly style=\"width:70px\" runat = \"server\"/>" +
            "</td>";

            for (int i = 1; i <= 3; i++ )
            {
                temp = "Test_M" + row.ToString() + i.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"STT\" style=\"width:20px\" runat = \"server\"/>" +
                     "</td>";
            }

            for (int i = 1; i <= 5 ; i++)
            {
                temp = "Test_15" + row.ToString() + i.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"STT\" style=\"width:20px\" runat = \"server\"/>" +
                     "</td>";
            }

            for (int i = 1; i <= 7; i++ )
            {
                temp = "Test_1T" + row.ToString() + i.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"STT\" style=\"width:20px\" runat = \"server\"/>" +
                     "</td>";
            }

            string get_averagescore = GetExistAverageScore(ClassName.Text.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id);
            temp = "TBM" + row.ToString();
            if (get_averagescore.ToString().Trim() != "")
                {
                    ResultScore.Text += "<td>" +
                         "<input id=\"" + temp.Trim() +
                         "\" type=\"text\" name=\"STT\" readonly value=\"" + get_averagescore.Trim() +
                         "\"style=\"width:40px\" runat = \"server\"/>" +
                         "</td>";
                }
            else
            {
                ResultScore.Text += "<td>" +
                             "<input id=\"" + temp.Trim() +
                             "\" type=\"text\" name=\"STT\" readonly " +
                             "style=\"width:40px\" runat = \"server\"/>" +
                             "</td>";
            }


            temp = "HK" + row.ToString();
            ResultScore.Text += "<td>" +
                 "<input id=\"" + temp.Trim() +
                 "\" type=\"text\" name=\"STT\" style=\"width:40px\" runat = \"server\"/>" +
                 "</td>";

            temp = "TBMHK" + row.ToString(); 
            ResultScore.Text += "<td>" +
                 "<input id=\"" + temp.Trim() +
                 "\" type=\"text\" name=\"STT\" style=\"width:40px\" runat = \"server\"/>" +
                 "</td>";

            ResultScore.Text += "</tr>";
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

        protected void Confirm_ClassSubject_Click(object sender, EventArgs e)
        {
            bool check_subject = Check_ExistSubject(SubjectName.Text.Trim(), ClassName.Text.Trim(), ClassYear.Text.Trim());
            if (check_subject)
            {
                
                Save_ScoreTable.Visible = true;
                Calculate_TBM.Visible = true;
                Calculate_TBMHK.Visible = true;
                SubjectName.ReadOnly = true;
                initTable();
                int index_row = 0, index_col, HK =1;
                switch (HK_Select.SelectedIndex)
                {
                    case 0:
                        {
                            HK = 1;
                            break;
                        }
                    case 1:
                        {
                            HK = 2;
                            break;
                        }
                }

                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "SELECT * FROM link_pupil_class";
                OleDbDataReader dr = cm.ExecuteReader();
                while(dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == ClassName.Text.Trim() 
                        && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                    {
                        index_row++;
                        string fullname = GetFullName(dr["pupill_id"].ToString().Trim());
                        CreateNewRow(index_row, fullname, dr["pupill_id"].ToString().Trim(), HK);
                        
                        string value = Request.Form["abc"];
                    }
                }
                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Dispose();
                conn.Close();
            }
            else
            {
                ResultAction.Text = "Không có môn học này!!!";
                SubjectName.Text = "";
            }
        }

        protected void Save_ScoreTable_Click(object sender, EventArgs e)
        {

        }
    }
}
