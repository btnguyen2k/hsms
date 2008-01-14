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
            NoticeView.Text = "Đây là phần dành cho giáo viên nhập điểm chi tiết của học sinh.<br>";
            NoticeView.Text += "Bao gồm các điểm 15', Miệng, 1 tiết hay điểm thi HK.<br>";
            NoticeView.Text += "(Ghi chú: điểm TBMH hay TBMHK sẽ được tự tính và khi đã có điểm Tổng kết sẽ<br>";
            NoticeView.Text += "không thể thay đổi được điểm số đã nhập vào)";
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


        protected void View_ClassTeaching_Click(object sender, EventArgs e)
        {
            // can sua lai, lay thong tin trong hsmsteacherschedule.
            // thong tin trong hsmsclass ton tai nhung lop giao vien nay ko day
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

        static protected bool  Check_ExistClass(string name_check, string year_check)
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
            return GetReturn(count);
        }

        
        protected string GetSubject(string id)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSTeacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == id.Trim())
                {
                    temp = dr["subject_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
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
                ClassName.Enabled = true;
                ClassYear.ReadOnly = true;
                Confirm_ClassName_Year.Visible = false;
                string temp_subject = GetSubject(Session["login_id"].ToString().Trim());
                SubjectName.Text = temp_subject;
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
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
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

        static protected bool Check_ExistSubject(string subject_check, string name_check, string year_check)
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
            return GetReturn(count);
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

        static protected bool CheckExistAverageScore(string classid, string year, string subject, int HK, string pupilid)
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
            return GetReturn(count);
        }

        static protected string GetExistAverageScore(string table, string classid, string year, string subject, int HK, string pupilid)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM " + table.Trim();
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["class_id"].ToString().Trim() == classid.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["subject_id"].ToString().Trim() == subject.Trim()
                    && dr["HK"].ToString().Trim() == HK.ToString().Trim())
                {
                    if (table == "HSMSSubjectAverageScore")
                    {
                        return dr["average_score"].ToString().Trim();
                    }
                    else
                    {
                        return dr["average_scoreI"].ToString().Trim();
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return "";
        }

        static protected string GetMode(string mode, int row)
        {
            string temp = "";
            switch (mode)
            {
                case "M":
                    {
                        temp = "Test_M" + row.ToString();
                        break;
                    }
                case "15":
                    {
                        temp = "Test_15" + row.ToString();
                        break;
                    }
                case "1T":
                    {
                        temp = "Test_1T" + row.ToString();
                        break;
                    }
                case "HK":
                    {
                        temp = "HK" + row.ToString();
                        break;
                    }
            }
            return temp.Trim();
        }

        protected int GetCout(string classname, string year, string subject,string pupilid,int hk,string mode, int row)
        {
            int count = 0;
            string temp_test_mode = GetMode(mode, row);
            
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubjectScore";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["subject_id"].ToString().Trim() == subject.Trim()
                    && dr["HK"].ToString().Trim() == hk.ToString().Trim()
                    && dr["test_mode"].ToString().Trim() == mode.Trim())
                {
                    count++;
                    if (mode != "HK")
                    {
                        ResultScore.Text += "<td>" +
                        "<input id=\"" + temp_test_mode.Trim() + count.ToString() +
                         "\" type=\"text\" name=\"" + temp_test_mode.Trim() + count.ToString() + "\"" + "value= \"" + dr["score"].ToString().Trim() + "\"" +
                        "style=\"width:20px\" runat = \"server\"/>" +
                        "</td>";
                    }
                    else
                    {
                        ResultScore.Text += "<td>" +
                        "<input id=\"" + temp_test_mode.Trim() +
                         "\" type=\"text\" name=\"" + temp_test_mode.Trim() + "\"" + "value= \"" + dr["score"].ToString().Trim() + "\"" +
                        "style=\"width:40px\" runat = \"server\"/>" +
                        "</td>";
                    }
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return count;
        }


        protected void CreateNewRow(int row,string fullname, string id, int HK)
        {
            ResultScore.Text += "<tr>";

            // cot so thu tu
            string temp = "STT" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"" + temp.Trim() + "\" readonly value=\"" + row.ToString() +
            "\"style=\"width:20px\" runat = \"server\"/>" +
            "</td>";
            
            // cot ten hs
            temp = "Name" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"" + temp.Trim() + "\"value=\"" + fullname.Trim() +
            "\"readonly style=\"width:140px\" runat = \"server\"/>" +
            "</td>";

            // cot mshs
            temp = "MSHS" + row.ToString();
            ResultScore.Text += "<td>" +
             "<input id=\"" + temp.Trim() +
            "\" type=\"text\" name=\"" + temp.Trim()+"\" " + "value=\"" + id.Trim() +
            "\"readonly style=\"width:70px\" runat = \"server\"/>" +
            "</td>";

            // cot diem M
            int index_count =
                   GetCout(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), id, HK, "M", row);
            for (int i = 1; i <= 3; i++)
            {
                temp = "Test_M" + row.ToString() + i.ToString();
                if (i > index_count)
                {
                    ResultScore.Text += "<td>" +
                         "<input id=\"" + temp.Trim() +
                         "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:20px\" runat = \"server\"/>" +
                         "</td>";
                }
            }

            // cot diem 15'
            index_count =
                        GetCout(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), id, HK, "15", row);
            for (int i = 1; i <= 5; i++)
            {
                temp = "Test_15" + row.ToString() + i.ToString();
                if (i > index_count)
                {
                    ResultScore.Text += "<td>" +
                 "<input id=\"" + temp.Trim() +
                 "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:20px\" runat = \"server\"/>" +
                 "</td>";    
                }
            }

            //cot diem 1T
            index_count =
                   GetCout(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), id, HK, "1T", row);
            for (int i = 1; i <= 7; i++)
            {
                temp = "Test_1T" + row.ToString() + i.ToString();
                if (i > index_count)
                {
                    ResultScore.Text += "<td>" +
                         "<input id=\"" + temp.Trim() +
                         "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:20px\" runat = \"server\"/>" +
                         "</td>";
                }
            }
            
            // cot diem TBM
            string table = "HSMSSubjectAverageScore";
            string get_averagescore = GetExistAverageScore(table, ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id);
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


            // cot diem thi HK
            index_count =
                  GetCout(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), id, HK, "HK", row);
            if (index_count == 0)
            {
                temp = "HK" + row.ToString();
                ResultScore.Text += "<td>" +
                     "<input id=\"" + temp.Trim() +
                     "\" type=\"text\" name=\"" + temp.Trim() + "\" style=\"width:40px\" runat = \"server\"/>" +
                     "</td>";
            }

            // cot diem TBMHK
            table = "HSMSSubjectTBMHKScore";
            get_averagescore = GetExistAverageScore(table, ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id);
            temp = "TBMHK" + row.ToString();
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
            
            ResultScore.Text += "</tr>";
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

        protected void Confirm_ClassSubject_Click(object sender, EventArgs e)
        {
            bool check_subject = Check_ExistSubject(SubjectName.Text.Trim(), ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim());
            if (check_subject)
            {
                
                Save_ScoreTable.Visible = true;
                Calculate_TBM.Visible = true;
                SubjectName.ReadOnly = true;
                HK_Select.Enabled = false;
                initTable();
                int index_row = 0;
                int HK = GetHK(HK_Select.SelectedIndex);

                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "SELECT * FROM link_pupil_class";
                OleDbDataReader dr = cm.ExecuteReader();
                while(dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim() 
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

        static protected int GetClassListNumber(string name, string year)
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

        static protected void DeleteCurrentScore(string classid, string year, string subject, int HK, string pupilid)
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
            //delete from hsmssubjecttbmhkscore
            cm.CommandText = "DELETE FROM HSMSSubjectTBMHKScore WHERE class_id = '"
                + classid.Trim() + "' AND year = '" + year.Trim() +
                "' AND subject_id = '" + subject.Trim() +
                "' AND HK = " + HK + " AND pupil_id = '" + pupilid.Trim() + "'";
            cm.ExecuteNonQuery();

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected bool VerifyData(int stt)
        {
            bool temp = true;
            // test_mode = M
            for (int i = 1; i <= 3; i++)
            {
                string temp_id = "Test_M" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id.Trim()];
                if (temp_value != "")
                {
                    int intValue;
                    if (Int32.TryParse(temp_value, out intValue))
                    {
                        if (intValue.ToString() != temp_value
                            || intValue < 0 || intValue > 10)
                        {
                            temp = false;
                            ResultScoreText.Text += "STT" + stt + ": Cột điểm Miệng thứ " + i + "nhập sai!<br>";
                        }
                    }
                    else
                    {
                        temp = false;
                        ResultScoreText.Text += "STT" + stt + ": Cột điểm Miệng thứ " + i + "nhập sai!<br>";
                    }
                }
                
                
            }
            //test_mode = 15
            for (int i = 1; i <= 5; i++)
            {
                string temp_id = "Test_15" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id];
                
                if (temp_value != "")
                {
                    int intValue;
                    if (Int32.TryParse(temp_value, out intValue))
                    {
                        if (intValue.ToString() != temp_value
                            || intValue < 0 || intValue > 10)
                        {
                            temp = false;
                            ResultScoreText.Text += "STT" + stt + ": Cột điểm 15' thứ " + i + "nhập sai!<br>";
                        }
                    }
                    else
                    {
                        temp = false;
                        ResultScoreText.Text += "STT" + stt + ": Cột điểm 15' thứ " + i + "nhập sai!<br>";
                    }
                }

            }

            //test_mode = 1T
            for (int i = 1; i <= 7; i++)
            {
                string temp_id = "Test_1T" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id.Trim()];
                if (temp_value != "")
                {
                    int intValue;
                    if (Int32.TryParse(temp_value, out intValue))
                    {
                        if (intValue.ToString() != temp_value
                            || intValue < 0 || intValue > 10)
                        {
                            temp = false;
                            ResultScoreText.Text += "STT" + stt + ": Cột điểm 1T thứ " + i + "nhập sai!<br>";
                        }
                    }
                    else
                    {
                        temp = false;
                        ResultScoreText.Text += "STT" + stt + ": Cột điểm 1T thứ " + i + "nhập sai!<br>";
                    }
                }
            }

            //test_mode = HK
            string temp_HK_id = "HK" + stt.ToString();
            string temp_HK_value = Request.Form[temp_HK_id];
            if (temp_HK_value != "")
            {
                int intValue;
                if (Int32.TryParse(temp_HK_value, out intValue))
                {
                    if (intValue.ToString() != temp_HK_value
                        || intValue < 0 || intValue > 10)
                    {
                        temp = false;
                        ResultScoreText.Text += "STT" + stt + ": Cột điểm HK nhập sai!<br>";
                    }
                }
                else
                {
                    temp = false;
                    ResultScoreText.Text += "STT" + stt + ": Cột điểm HK nhập sai!<br>";
                }
            }
            return temp;
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
                    "INSERT INTO HSMSSubjectScore VALUES ( '" +
                    pupilid.Trim() + "','" + classid.Trim() + "','" + year.Trim() + "','" + subject.Trim() +
                    "'," + HK + "," + temp_value.Trim() + ", 'M' )";
                    cm.ExecuteNonQuery();
                }
            }
            //test_mode = 15
            for (int i = 1; i <= 5; i++)
            {
                string temp_id = "Test_15" + stt.ToString() + i.ToString();
                string temp_value = Request.Form[temp_id];
                if (temp_value != "")
                {
                    cm.CommandText =
                        "INSERT INTO HSMSSubjectScore VALUES ( '" +
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
                    "INSERT INTO HSMSSubjectScore (pupil_id, class_id, year, subject_id, HK, score, test_mode) VALUES ( '" +
                    pupilid.Trim() + "','" + classid.Trim() + "','" + year.Trim() + "','" + subject.Trim() +
                    "'," + HK + "," + temp_value.Trim() + ", '1T' )";
                    cm.ExecuteNonQuery();
                }
            }

            //test_mode = HK
            string temp_HK_id = "HK" + stt.ToString();
            string temp_HK_value = Request.Form[temp_HK_id];
            if (temp_HK_value != "")
            {
                cm.CommandText =
            "INSERT INTO HSMSSubjectScore (pupil_id, class_id, year, subject_id, HK, score, test_mode) VALUES ( '" +
            pupilid.Trim() + "','" + classid.Trim() + "','" + year.Trim() + "','" + subject.Trim() +
            "'," + HK + "," + temp_HK_value + ", 'HK' )";
                cm.ExecuteNonQuery();
            }

            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        static protected int GetHK(int hk)
        {
            int temp = 1;
            switch(hk)
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

        static protected bool AllowToChange(string classname, string year, int hk)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["hk"].ToString().Trim() == hk.ToString().Trim()
                    && dr["TBHK"].ToString().Trim() != "-1")
                {
                    count++;
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return !GetReturn(count);
        }

        protected void Save_ScoreTable_Click(object sender, EventArgs e)
        {
            int HK = GetHK(HK_Select.SelectedIndex);
            ResultScoreText.Text = "";
            int ClassListNumber = GetClassListNumber(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim());
            if (ClassListNumber == 0)
            {
                ResultScoreText.Text = "Không có học sinh để lưư";
            }
            else
            {
                bool check_data = true;
                for (int i = 1; i <= ClassListNumber; i++)
                {
                    bool temp = true;
                    temp = VerifyData(i);
                    if (!temp)
                    {
                        check_data = false;
                    }
                }
                if (check_data)
                    {
                        bool check_allow = AllowToChange(ClassName.SelectedItem.Value.Trim(), ClassYear.Text, HK);
                        if (check_allow)
                        {
                            for (int i = 1; i <= ClassListNumber; i++)
                            {
                                Calculate_TBM.Enabled = true;
                                string temp_MSHS = "MSHS" + i.ToString();
                                string id = Request.Form[temp_MSHS];
                                bool check_existaveragescore = CheckExistAverageScore(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id.Trim());
                                if (check_existaveragescore)
                                {
                                    ResultScoreText.Text = "Đã có điểm TBM!!! Cần phải tính lại TBM!! <br>";
                                }
                                DeleteCurrentScore(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id.Trim());
                                AddNewScore(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK, id.Trim(), i);

                                // cap nhat lai bang diem 
                                //Confirm_ClassSubject_Click(sender, e);
                            }
                            Confirm_ClassSubject_Click(sender, e);
                            ResultScoreText.Text += "Cập nhật dữ liệu thành công!!!";
                        }
                        else
                        {
                            Confirm_ClassSubject_Click(sender, e);
                            ResultScoreText.Text = "Đã vào sổ điểm, không thể thay đổi nữa!!!";
                        }
                    }
                    else
                    {
                        //Confirm_ClassSubject_Click(sender, e);
                        //ResultScoreText.Text = "Đã vào sổ điểm, không thể thay đổi nữa!!!"; 
                    }
            }
        }

        protected void CalculateAverageScore(string id, string classname, string classyear, string subject, int hk)
        {
            int count = 0, heso = 1, HK_mark = -1;
            double total_TBM = 0; 
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * From HSMSSubjectScore";
            OleDbDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
               if (dr["pupil_id"].ToString().Trim() == id.Trim()
                   && dr["class_id"].ToString().Trim() == classname.Trim()
                   && dr["year"].ToString().Trim() == classyear.Trim()
                   && dr["subject_id"].ToString().Trim() == subject.Trim()
                   && dr["HK"].ToString().Trim() == hk.ToString().Trim()
                   && dr["test_mode"].ToString().Trim() != "HK")
               {
                   if (dr["test_mode"].ToString().Trim() == "1T")
                   {
                       count += 2;
                       heso = 2;
                   }
                   else
                   {
                       count++;
                   }
                   string temp = dr["score"].ToString().Trim();
                   total_TBM += Int32.Parse(temp) * heso;
               }
               if (dr["pupil_id"].ToString().Trim() == id.Trim()
                   && dr["class_id"].ToString().Trim() == classname.Trim()
                   && dr["year"].ToString().Trim() == classyear.Trim()
                   && dr["subject_id"].ToString().Trim() == subject.Trim()
                   && dr["HK"].ToString().Trim() == hk.ToString().Trim()
                   && dr["test_mode"].ToString().Trim() == "HK")
                {
                   string temp = dr["score"].ToString().Trim();
                   HK_mark = Int32.Parse(temp);
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            if (count == 0)
            {
                ResultScoreText.Text += "Học sinh:" + GetFullName(id) + "chưa có điểm <br>";
            }
            else
            {
                total_TBM = total_TBM/count;
                total_TBM = Math.Round(total_TBM, 1);
                OleDbCommand cm1 = new OleDbCommand();
                cm1.Connection = conn;
                cm1.CommandText = "INSERT INTO HSMSSubjectAverageScore VALUES ('" +
                                 id.Trim() + "','" + classname.Trim() + "','" + classyear.Trim() +
                                 "','" + subject.Trim() + "'," + hk + "," + total_TBM + ")";
                cm1.ExecuteNonQuery();
                cm1.Dispose();
                if (HK_mark != -1)
                {
                    double TBM_HK = (total_TBM*2 + HK_mark)/3;
                    TBM_HK = Math.Round(TBM_HK, 1);
                    OleDbCommand cm2 = new OleDbCommand();
                    cm2.Connection = conn;
                    cm2.CommandText = "INSERT INTO HSMSSubjectTBMHKScore VALUES ('" +
                                     id.Trim() + "','" + classname.Trim() + "','" + classyear.Trim() +
                                     "','" + subject.Trim() + "','" + TBM_HK + "'," + hk + ")";
                    cm2.ExecuteNonQuery();
                    cm2.Dispose();
                }
            }
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void Calculate_TBM_Click(object sender, EventArgs e)
        {
            int HK = GetHK(HK_Select.SelectedIndex);
            ResultScoreText.Text = "";
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
                    CalculateAverageScore(id, ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(), SubjectName.Text.Trim(), HK);
                    // cap nhat lai bang diem 
                    Confirm_ClassSubject_Click(sender, e);
                    ResultScoreText.Text = "Tính toán thành công!!!";
                    Calculate_TBM.Enabled = false;
                }
            }
        }
    }
}
