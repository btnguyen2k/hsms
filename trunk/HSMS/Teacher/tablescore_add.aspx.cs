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
            "\" type=\"text\" name=\"" + temp.Trim() + "\" readonly value=\"" + row.ToString() +
            "\"style=\"width:20px\" runat = \"server\"/>" +
            "</td>";
            
            temp = "Name" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"" + temp.Trim() + "\"value=\"" + fullname.Trim() +
            "\"readonly style=\"width:140px\" runat = \"server\"/>" +
            "</td>";

            temp = "MSHS" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"" + temp.Trim()+"\" " + "value=\"" + id.Trim() +
            "\"readonly style=\"width:70px\" runat = \"server\"/>" +
            "</td>";

            for (int i = 1; i <= 3; i++ )
            {
                temp = "Test_M" + row.ToString() + i.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:20px\" runat = \"server\"/>" +
                     "</td>";
            }

            for (int i = 1; i <= 5 ; i++)
            {
                temp = "Test_15" + row.ToString() + i.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:20px\" runat = \"server\"/>" +
                     "</td>";
            }

            for (int i = 1; i <= 7; i++ )
            {
                temp = "Test_1T" + row.ToString() + i.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:20px\" runat = \"server\"/>" +
                     "</td>";
            }

            string get_averagescore = GetExistAverageScore(ClassName.Text.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id);
            temp = "TBM" + row.ToString();
            if (get_averagescore.ToString().Trim() != "")
                {
                    ResultScore.Text += "<td>" +
                         "<input id=\"" + temp.Trim() +
                         "\" type=\"text\" name=\"" + temp.Trim() + "\" readonly value=\"" + get_averagescore.Trim() +
                         "\"style=\"width:40px\" runat = \"server\"/>" +
                         "</td>";
                }
            else
            {
                ResultScore.Text += "<td>" +
                             "<input id=\"" + temp.Trim() +
                             "\" type=\"text\" name=\"" + temp.Trim() + "\" readonly " +
                             "style=\"width:40px\" runat = \"server\"/>" +
                             "</td>";
            }


            temp = "HK" + row.ToString();
            ResultScore.Text += "<td>" +
                 "<input id=\"" + temp.Trim() +
                 "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:40px\" runat = \"server\"/>" +
                 "</td>";

            temp = "TBMHK" + row.ToString(); 
            ResultScore.Text += "<td>" +
                 "<input id=\"" + temp.Trim() +
                 "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:40px\" runat = \"server\"/>" +
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
                HK_Select.Enabled = false;
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

        protected int GetClassListNumber(string name, string year)
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
                if (dr["class_id"].ToString().Trim() == name.Trim()
                    && dr["year_start"].ToString().Trim() == year.Trim())
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

        protected void DeleteCurrentScore(string classid, string year, string subject, int HK, string pupilid)
        {

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            // delete from hsmssubjectscore
            cm.CommandText = "DELETE FROM HSMSSubjectScore WHERE class_id = '" 
                + classid.Trim() + "' AND year = '" + year.Trim() + 
                "' AND subject_id = '" + subject.Trim() + 
                "' AND HK = " + HK + " AND pupil_id = '" + pupilid.Trim() + "'";
            cm.ExecuteNonQuery();
            
            // delete from hsmssubjectaveragescore
            cm.CommandText = "DELETE FROM HSMSSubjectAverageScore WHERE class_id = '"
                + classid.Trim() + "' AND year = '" + year.Trim() +
                "' AND subject_id = '" + subject.Trim() +
                "' AND HK = " + HK + " AND pupil_id = '" + pupilid.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void AddNewScore(string classid, string year, string subject, int HK, string pupilid, int stt)
        {

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            // add score into HSMSSubjectScore
            
            // test_mode = M
            for (int i=1; i <= 3; i++)
            {
                string temp_id = "Test_M" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id.Trim()];
                if (temp_value != "")
                {
                    cm.CommandText =
                    "INSERT INTO HSMSSubjectScore(pupil_id, class_id, year, subject_id, HK, score, test_mode) VALUES ( '" +
                    pupilid.Trim() + "','" + classid.Trim() + "','" + year.Trim() + "','" + subject.Trim() +
                    "'," + HK + "," + temp_value.Trim() + ", 'M' )";
                    cm.ExecuteNonQuery();
                }
            }
            //test_mode = 15
            for (int i = 1; i <= 5; i++)
            {
                string temp_id = "Test_15" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id.Trim()];
                if (temp_value != "")
                {
                    cm.CommandText =
                        "INSERT INTO HSMSSubjectScore(pupil_id, class_id, year, subject_id, HK, score, test_mode) VALUES ( '" +
                        pupilid.Trim() + "','" + classid.Trim() + "','" + year.Trim() + "','" + subject.Trim() +
                        "'," + HK + "," + temp_value.Trim() + ", '15' )";
                    cm.ExecuteNonQuery();
                }
            }

            //test_mode = 1T
            for (int i = 1; i <= 7; i++)
            {
                string temp_id = "Test_1T" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id.Trim()];
                if (temp_value != "")
                {
                    cm.CommandText =
                    "INSERT INTO HSMSSubjectScore(pupil_id, class_id, year, subject_id, HK, score, test_mode) VALUES ( '" +
                    pupilid.Trim() + "','" + classid.Trim() + "','" + year.Trim() + "','" + subject.Trim() +
                    "'," + HK + "," + temp_value.Trim() + ", '1T' )";
                    cm.ExecuteNonQuery();
                }
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Save_ScoreTable_Click(object sender, EventArgs e)
        {
            int HK = 1;
            switch(HK_Select.SelectedIndex)
            {
                case  0:
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
            int ClassListNumber = GetClassListNumber(ClassName.Text.Trim(), ClassYear.Text.Trim());
            if (ClassListNumber == 0)
            {
                ResultScoreText.Text = "Không có học sinh để lưư";
            }
            else
            {
                for (int i = 1; i <= ClassListNumber; i++)
                {
                    string temp_MSHS = "MSHS" + i.ToString();
                    string id = Request.Form[temp_MSHS];
                    Response.Write(id.Trim());
                    bool check_existaveragescore = CheckExistAverageScore(ClassName.Text.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id.Trim());
                    if (check_existaveragescore)
                    {
                        ResultScoreText.Text = "Đã có điểm TBM!!!";
                    }
                    //DeleteCurrentScore(ClassName.Text.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id.Trim());
                    AddNewScore(ClassName.Text.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id.Trim(), i);
                    
                    ResultScoreText.Text += "Cập nhật dữ liệu thành công!!!";

                }
            }
        }
    }
}
