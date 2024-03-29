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

namespace HSMS.Admin
{
    public partial class class_manager2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            ResultContent.Text = "";
            ResultAction.Text = "";
            if (!IsPostBack)
            {
                if (DateTime.Now.Month < 6)
                {
                    int temp = DateTime.Now.Year - 1;
                    ClassYear.Text = temp.ToString();
                }
                else
                {
                    ClassYear.Text = DateTime.Now.Year.ToString();
                }
                GetClassList();
                GetTeacherList();
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                MainTeacherID.Visible = false;
                MainTeacherId_New.Visible = false;
                MainTeacherId_Old.Visible = false;
                CreateNewClassFinal.Visible = false;
                ChangeMainTeacher.Visible = false;
                NewUpClass.Visible = false;
                NewClassName.Visible = false;
                NewClassYear.Visible = false;
                NewClassMainTeacher.Visible = false;
                mode.Visible = false;
            }
        }

        protected void GetTeacherList()
        {
            TeacherValue.Items.Add("");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select teacher_id From HSMSTeacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                TeacherValue.Items.Add(dr["teacher_id"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void GetClassList()
        {
            ClassValue.Items.Add("");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select DISTINCT class_id From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                ClassValue.Items.Add(dr["class_id"].ToString());
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void ClassList_Click(object sender, EventArgs e)
        {
            ResultContent.Text = "<table width=100% border=\"1\"> <tr> <td align=center>Tên lớp</td> <td align=center>Năm học</td><td align=center>MS GVCN</td></tr>";

            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                object temp = dr["teacher_id"];
                if (dr["class_id"].ToString().Trim() != "")
                {
                    ResultContent.Text += "<tr><td align=center style=\"color:black\">" + dr["class_id"].ToString().Trim() +
                                    "</td><td align=center style=\"color:black\">" +
                                    dr["year"].ToString().Trim() + "</td>";
                    if (temp == null || temp.ToString().Trim() == "")
                    {
                        ResultContent.Text += "<td align=center style=\"color:black\">Chưa có GVCN" +
                                    dr["teacher_id"].ToString().Trim() + "</td></tr>";  
                    }
                    else
                    {
                        ResultContent.Text += "<td align=center style=\"color:black\">" +
                                    dr["teacher_id"].ToString().Trim() + "</td></tr>";    
                    }
                    
                }
                
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            ResultContent.Text += "</table>";
        }
        protected void CreateNewClass_Click(object sender, EventArgs e)
        {
            bool check = CheckExist_Class(ClassName.Text.Trim(), ClassYear.Text.Trim());
            if (check)
            {
                ResultContent.Text = "Lớp học này đã có rồi!!!";
            }
            else
            {
                mode.Text = "1";
                Label3.Visible = true;
                MainTeacherID.Visible = true;
                CreateNewClassFinal.Visible = true;
                ChangeTeacher.Visible = false;
                EndYear.Visible = false;
                ClassList.Visible = false;
                CreateNewClass.Visible = false;
                Label9.Visible = false;
                ClassValue.Visible = false;
            }
        }
       

        static protected bool CheckExist_Teacher(string teacherid_check)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSTeacher";
            OleDbDataReader dr = cm.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == teacherid_check.Trim())
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

        static protected bool CheckExist_Class(string classname_check, string classyear_check)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            
            cm.CommandText = "Select * From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname_check.Trim()
                    && dr["year"].ToString().Trim() == classyear_check.Trim()
                    && dr["class_id"].ToString().Trim() != "")
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            if (count == 0) {
                return false; }
            else
            {
                return true;
            }
            
        }

        static protected bool CheckClass(string classname, string year)
        {
            bool temp = true;
            if (classname == "" || year == "")
            {
                temp = false;
            }
            int intValue;
            if (!Int32.TryParse(year, out intValue))
            {
                temp = false;
            }
            else
            {
                if (Int32.Parse(year) < 1990)
                {
                    temp = false;
                }
            }
            return temp;
        }


        protected void CreateNewClassFinal_Click(object sender, EventArgs e)
        {

            bool check = CheckExist_Teacher(MainTeacherID.Text.Trim());
            if (check || MainTeacherID.Text == "")
            {
                if (MainTeacherID.Text == "")
                {
                    check = true;
                }
                if (check) { check = CheckClass(ClassName.Text, ClassYear.Text); }
                if (check)
                {
                    OleDbConnection conn = DbUtils.GetSQLDbConnection();
                    conn.Open();
                    OleDbCommand cm = new OleDbCommand();
                    cm.Connection = conn;
                    cm.CommandText = "INSERT INTO HSMSClass (class_id, teacher_id, year) VALUES ('" + ClassName.Text.Trim() + "','" +
                                     MainTeacherID.Text.Trim() +
                                     "','" + ClassYear.Text.Trim() + "')";
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    conn.Dispose();
                    conn.Close();
                    ResultContent.Text = "Thêm lớp học mới thành công";
                    ChangeTeacher.Visible = true;
                    EndYear.Visible = true;
                    ClassList.Visible = true;
                    CreateNewClass.Visible = true;
                    ClassName.Text = "";
                    ClassYear.Text = "";
                    mode.Text = "";
                    CreateNewClass.Visible = false;
                    ChangeTeacher.Visible = false;
                    EndYear.Visible = false;
                    ClassList.Visible = false;
                    Label3.Visible = false;
                    MainTeacherID.Visible = false;
                    CreateNewClassFinal.Visible = false;
                }
                else
                {
                    ResultAction.Text = "Không tồn tại tên lớp như thế này!";
                    Label3.Visible = true;
                    MainTeacherID.Visible = true;
                    MainTeacherID.Text = "";
                    CreateNewClassFinal.Visible = true;
                    ClassName.Text = "";
                    ClassYear.Text = "";
                }
            }
            else
            {
                ResultAction.Text = "Không tồn tại mã số giáo viên này!";
                Label3.Visible = true;
                MainTeacherID.Visible = true;
                MainTeacherID.Text = "";
                CreateNewClassFinal.Visible = true;
                ClassName.Text = "";
                ClassYear.Text = "";
            }
        }

        protected void ChangeTeacher_Click(object sender, EventArgs e)
        {
            bool check = CheckExist_Class(ClassName.Text.Trim(), ClassYear.Text.Trim());
            if (check)
            {
                mode.Text = "2";
                Label4.Visible = true;
                Label5.Visible = true;
                MainTeacherId_Old.Visible = true;
                MainTeacherId_New.Visible = true;
                ChangeMainTeacher.Visible = true;
                CreateNewClass.Visible = false;
                EndYear.Visible = false;
                ClassList.Visible = false;
                ChangeTeacher.Visible = false;
                GetOldMainTeacher(ClassName.Text.Trim(), ClassYear.Text.Trim());
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
            }
            else
            {
                ResultContent.Text = "Không tồn tại lớp học này!!!";
            }
        }

        protected void GetOldMainTeacher(string classname_get, string classyear_get)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "Select * From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname_get.Trim()
                    && dr["year"].ToString().Trim() == classyear_get.Trim())
                {
                    MainTeacherId_Old.Text = dr["teacher_id"].ToString().Trim();
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void ChangeMainTeacher_Click(object sender, EventArgs e)
        {
            bool check = CheckExist_Teacher(MainTeacherId_New.Text.Trim());
            if (check)
            {
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "UPDATE HSMSClass SET teacher_id = '" + MainTeacherId_New.Text.Trim() + "' WHERE class_id = '" +
                             ClassName.Text.Trim() + "' AND year = '" + ClassYear.Text.Trim() + "'";
                cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Dispose();
                conn.Close();

                ResultContent.Text = "Thay đổi giáo viên chủ nhiệm thành công!";
                MainTeacherId_New.Text = "";
                MainTeacherId_Old.Text = "";
                ChangeTeacher.Visible = true;
                EndYear.Visible = true;
                ClassList.Visible = true;
                CreateNewClass.Visible = true;
                ClassName.Text = "";
                ClassYear.Text = "";
                mode.Text = "";
                //Response.Redirect("~/class_manager.aspx");
                CreateNewClass.Visible = false;
                ChangeTeacher.Visible = false;
                EndYear.Visible = false;
                ClassList.Visible = false;
                Label4.Visible = false;
                MainTeacherId_Old.Visible = false;
                MainTeacherId_New.Visible = false;
                Label5.Visible = false;
                ChangeMainTeacher.Visible = false;

            }
            else
            {
                ResultAction.Text = "Không tồn tại giáo viên này!!!";
                Label4.Visible = true;
                Label5.Visible = true;
                MainTeacherId_Old.Visible = true;
                MainTeacherId_New.Visible = true;
                ChangeMainTeacher.Visible = true;
                MainTeacherId_New.Text = "";
            }
        }

        protected void EndYear_Click(object sender, EventArgs e)
        {
            bool check = CheckExist_Class(ClassName.Text.Trim(), ClassYear.Text.Trim());
            if (check)
            {
                mode.Text = "3";
                Label6.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                NewClassName.Visible = true;
                NewClassYear.Visible = true;
                NewClassMainTeacher.Visible = true;
                NewUpClass.Visible = true;

                CreateNewClass.Visible = false;
                ChangeTeacher.Visible = false;
                EndYear.Visible = false;
                ClassList.Visible = false;
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
                
                int temp = Int32.Parse(ClassYear.Text) + 1;
                NewClassYear.Text = temp.ToString();
                
                int max = ClassName.Text.Length;
                string first = ClassName.Text.Substring(0, 2);
                string last = ClassName.Text.Substring(2, max-2);
                int first_1 = Int32.Parse(first) + 1;
                NewClassName.Text = first_1.ToString().Trim() + last.Trim();
            }
            else
            {
                ResultContent.Text = "Không tồn tại lớp học này!!!";
            }
        }

        protected void Refresh()
        {
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            NewClassName.Visible = true;
            NewClassYear.Visible = true;
            NewClassMainTeacher.Visible = true;
            NewUpClass.Visible = true;
            NewClassName.Text = "";
            NewClassYear.Text = "";
        }

        static protected bool CheckEndYear(string classname, string year)
        {
            bool temp = false;
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
                    && dr["hk"].ToString().Trim() == "3")
                {
                    temp = true;
                }
            }
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp;
        }

        protected void NewUpClass_Click(object sender, EventArgs e)
        {
            bool check_class = CheckExist_Class(NewClassName.Text.Trim(), NewClassYear.Text.Trim());
            bool check_teacher = CheckExist_Teacher(NewClassMainTeacher.Text.Trim());
            if (check_class)
            {
                ResultAction.Text = "Lớp học này đã tồn tại rồi!!";
                Refresh();
            }
            else
            {
                if (check_teacher || NewClassMainTeacher.Text == "" )
                {
                    int intValue;
                    if (Int32.TryParse(NewClassYear.Text, out intValue))
                    {
                        if (CheckEndYear(ClassName.Text.Trim() , ClassYear.Text.Trim()))
                        {
                            CreateNewClassup(NewClassName.Text.Trim(), NewClassYear.Text.Trim(), NewClassMainTeacher.Text.Trim());
                            ResultContent.Text = "Chuyển thành công!!!";
                            if (NewClassMainTeacher.Text == "")
                            {
                                ResultContent.Text += "Nhưng chưa có GVCN, hãy thêm sau.";
                            }
                            Label6.Visible = false;
                            NewClassName.Visible = false;
                            NewClassYear.Visible = false;
                            NewClassMainTeacher.Visible = false;
                            Label7.Visible = false;
                            Label8.Visible = false;
                            NewUpClass.Visible = false;    
                        }
                        else
                        {
                            ResultContent.Text = "Lớp học chưa có điểm tổng kết sao kết thúc!";
                            Refresh();
                        }
                    }
                    else
                    {
                        ResultContent.Text = "Năm học không chính xác!";
                        Refresh();
                    }
                }
                else
                {
                    ResultAction.Text = "Không tồn tại giáo viên này!!";
                    Refresh();
                }
            }
        }

        static protected bool GetHKResult(string classid, string pupilid, string year, int hk)
        {
            bool temp = true;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classid.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["hk"].ToString().Trim() == hk.ToString().Trim()
                    && dr["pupil_id"].ToString().Trim() == pupilid.Trim())
                {
                    string temp_rate = dr["rate"].ToString().Trim();
                    int temp_rate_int = Int32.Parse(temp_rate);
                    if (temp_rate_int > 3)
                    {
                        temp = false;
                    }
                }
            }
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            return temp;
        }

        protected void CreateNewClassup(string classname_up, string classyear_up, string classmainteacher_up)
        {
            // Create new data to HSMSClass
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            
            cm.CommandText =
                "INSERT INTO HSMSClass (class_id, teacher_id, year) VALUES ('" + classname_up.Trim() + "','" +
                classmainteacher_up.Trim() + "','" + classyear_up.Trim() + "')";
                
            cm.ExecuteNonQuery();

            // Create new data to link_pupil_class
            cm.CommandText = "Select * From link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_pupilid = "";
                OleDbCommand cm1 = new OleDbCommand();
                cm1.Connection = conn;
                if (dr["class_id"].ToString().Trim() == ClassName.Text.Trim() 
                    && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                {
                    temp_pupilid = dr["pupill_id"].ToString().Trim();
                    if (GetHKResult(ClassName.Text.Trim(), temp_pupilid, ClassYear.Text.Trim(), 3))
                    {
                        cm1.CommandText = "INSERT INTO link_pupil_class (pupill_id, class_id, year_start) VALUES ('" +
                                      temp_pupilid.Trim() + "','"
                                      + classname_up.Trim() + "','" + classyear_up.Trim() + "')";
                    }
                    else
                    {
                        cm1.CommandText = "INSERT INTO link_pupil_class (pupill_id, class_id, year_start) VALUES ('" +
                                  temp_pupilid.Trim() + "','"
                                  + classname_up.Trim() + "','" + ClassYear.Text.Trim() + "')";
                    }

                    cm1.ExecuteNonQuery();
                }
                cm1.Dispose();
            }

            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void ClassValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClassValue.SelectedItem.Value.Trim() != "")
            {

                ClassName.Text = ClassValue.SelectedItem.Value.Trim();
            }
        }

        protected void TeacherValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeacherValue.SelectedItem.Value.Trim() != "")
            {
                MainTeacherID.Text = TeacherValue.SelectedItem.Value.Trim();
                MainTeacherId_New.Text = TeacherValue.SelectedItem.Value.Trim();
                NewClassMainTeacher.Text = TeacherValue.SelectedItem.Value.Trim();
            }
        }
    }
}
