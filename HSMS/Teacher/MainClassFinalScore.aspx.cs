using System;
using System.Data.OleDb;
using System.Web.UI;
using HSMS.Db;

namespace HSMS.Teacher
{
    public partial class MainClassFinalScore : Page
    {
        private readonly string[] subjectlist = new string[15];
        private int CurrentDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            if (!IsPostBack)
            {
                if (DateTime.Now.Month < 7)
                {
                    CurrentDate = DateTime.Now.Year - 1;
                    ClassYear.Text = CurrentDate.ToString();
                }
                else
                {
                    ClassYear.Text = DateTime.Now.Year.ToString();
                    CurrentDate = DateTime.Now.Year;
                }
                GetClassList();
                ClassYear.Enabled = false;
            }
        }

        protected void GetClassList()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select DISTINCT class_id, teacher_id From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == Session["login_id"].ToString().Trim())
                {
                    ClassName.Items.Add(dr["class_id"].ToString());
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void ViewClassList_Click(object sender, EventArgs e)
        {
            bool check_class = CheckClass(ClassName.SelectedItem.Value.Trim(), ClassYear.Text);
            if (check_class)
            {
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
                HK_Select.Enabled = false;
                ViewClassList.Enabled = false;

                int totalsubject = initTable(ClassName.SelectedItem.Value.Trim(), ClassYear.Text);

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
                    if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                        && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                    {
                        index_row++;
                        CreateNewRow(index_row, ClassName.SelectedItem.Value.Trim(), ClassYear.Text,
                                     dr["pupill_id"].ToString().Trim(), hk, totalsubject);
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
            }
        }

        protected static bool GetReturn(int count)
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

        protected int GetHK()
        {
            int temp = 1;
            switch (HK_Select.SelectedIndex)
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

            cm.CommandText = "SELECT DISTINCT subject_id, class_id FROM HSMSClassSchedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_subject = dr["subject_id"].ToString().Trim();
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["subject_id"].ToString().Trim() != "")
                {
                    subject_index++;
                    string name_subject = "Subject" + subject_index.ToString().Trim();
                    ResultContent.Text += "<td id=\"" + name_subject.Trim() +
                                          "\" name=\"" + name_subject.Trim() +
                                          "\" align=center style=\"color:black\" readonly>" +
                                          dr["subject_id"].ToString().Trim() + "</td>";

                    subjectlist[subject_index] = temp_subject.Trim();
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

        protected static string GetFullName(string id)
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

        protected static double GetMark(string classname, string year, int hk, string pupilid, string subjectname)
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

        protected static int GetSubjectHeso(string subject)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSSubject";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
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

        protected static bool CheckExistDD(string classname, string year, string pupilid, int hk)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["hk"].ToString().Trim() == hk.ToString().Trim())
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

        protected static string GetDD(string classname, string year, int hk, string pupilid)
        {
            string temp = "1";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["hk"].ToString().Trim() == hk.ToString().Trim())
                {
                    temp = dr["personality"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            string temp_return = "A";
            switch (Int32.Parse(temp.Trim()))
            {
                case 1:
                    {
                        temp_return = "A";
                        break;
                    }
                case 2:
                    {
                        temp_return = "B";
                        break;
                    }
                case 3:
                    {
                        temp_return = "C";
                        break;
                    }
                case 4:
                    {
                        temp_return = "D";
                        break;
                    }
            }
            return temp_return.Trim();
        }

        protected static int GetRate(double diem, string dd)
        {
            int temp_reurn = 1;
            if (diem >= 8)
            {
                if (dd.Trim() == "B")
                {
                    temp_reurn = 2;
                }
                if (dd.Trim() == "C" || dd.Trim() == "D")
                {
                    temp_reurn = 3;
                }
            }

            if (diem < 8 && diem >= 6.5)
            {
                temp_reurn = 2;
                if (dd.Trim() == "C" || dd.Trim() == "D")
                {
                    temp_reurn = 3;
                }
            }
            if (diem < 6.5 && diem >= 5)
            {
                temp_reurn = 3;
                if (dd.Trim() == "D")
                {
                    temp_reurn = 4;
                }
            }
            if (diem < 5)
            {
                temp_reurn = 5;
            }
            return temp_reurn;
        }

        protected static void UpdateDatabase(string classname, string year, int hk, string pupilid, double mark,
                                             string dd, int rate)
        {
            int inputvalue = 1;
            if (dd == "B")
            {
                inputvalue = 2;
            }
            if (dd == "C")
            {
                inputvalue = 3;
            }
            if (dd == "D")
            {
                inputvalue = 4;
            }
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "UPDATE HSMSClassFinal SET TBHK =" + mark +
                             ", rate=" + rate + ", personality = " + inputvalue +
                             " Where class_id = '" +
                             classname.Trim() + "' AND year = '" + year.Trim() + "'AND hk =" +
                             hk + "AND pupil_id = '" + pupilid.Trim() + "'";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void CreateNewRow(int row, string classname, string classyear, string pupilid, int hk,
                                    int subjectcount)
        {
            ResultContent.Text += "<tr>";
            ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + row.ToString() + "</td>";
            string name = GetFullName(pupilid);
            ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" + name + "</td>";

            string temp_id = "MSHS" + row.ToString();

            ResultContent.Text += "<td><input id=\"" + temp_id.Trim() + "\" name=\"" + temp_id.Trim() +
                                  "\" align = \"center\" style=\"width:100%\" style=\"color:black\" readonly value =\"" +
                                  pupilid.Trim() +
                                  "\"></td>";

            // hien thi diem
            bool check_finish = true;
            double total_mark = 0;
            int hesochia = 0;

            // Diem TB tat ca cac mon hoc
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
                    string redirect_site = "DetailPupilTBMK.aspx?class_id=" + classname.Trim() +
                                           "&year=" + classyear.Trim() + "&hk=" + hk.ToString().Trim() + "&pupil_id=" +
                                           pupilid.Trim() + "&subject_id=" + temp_subject_name.Trim();
                    ResultContent.Text += "<td align = \"center\" style=\"color:black\" readonly>" +
                                          "<a href=\"" + redirect_site + "\">" + temp_mark + "</td>";
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

            //Diem TBHK co hay chua???
            temp_id = "Mark" + row.ToString();
            if (check_finish)
            {
                // tinh diem tong ket ca hoc ki
                total_mark = total_mark/hesochia;
                total_mark = Math.Round(total_mark, 1);
                ResultContent.Text += "<td><input style=\"color:black\" id=\" " +
                                      temp_id.Trim() + "\" name=\"" + temp_id.Trim() +
                                      "\" readonly style=\"width:100%\" value =\"" + total_mark + "\"></td>";
            }
            else
            {
                // chua cap nhat diem hoc ky
                ResultContent.Text += "<td align=center><input style=\"color:black\" id=\"" +
                                      temp_id.Trim() + "\" name=\"" + temp_id.Trim() +
                                      "\" readonly style=\"width:100%\" value=X></td>";
            }

            // Cot dao duc da them vao hay chua???
            temp_id = "Rate" + row.ToString();
            bool exist_dd = CheckExistDD(classname, classyear, pupilid, hk);
            if (exist_dd)
            {
                // da co diem DD
                string DD_value = GetDD(classname, classyear, hk, pupilid);
                string redirect_site = "DetailPupiLDD.aspx?class_id=" + classname.Trim() +
                                       "&year=" + classyear.Trim() + "&hk=" + hk.ToString().Trim() + "&pupil_id=" +
                                       pupilid.Trim();
                ResultContent.Text += "<td align=center><a href =\"" + redirect_site.Trim() + "\">" +
                                      DD_value.Trim() + " </td>";

                // Kiem tra databse
                if (check_finish)
                {
                    // co diem DD va TBHK -> update new databse
                    int temp_rate = GetRate(total_mark, DD_value);
                    UpdateDatabase(classname, classyear, hk, pupilid, total_mark, DD_value, temp_rate);
                    string temp_rate_output = "Gioi";
                    switch (temp_rate)
                    {
                        case 1:
                            {
                                temp_rate_output = "Gioi";
                                break;
                            }
                        case 2:
                            {
                                temp_rate_output = "Kha";
                                break;
                            }
                        case 3:
                            {
                                temp_rate_output = "TB";
                                break;
                            }
                        case 4:
                            {
                                temp_rate_output = "Yeu";
                                break;
                            }
                        case 5:
                            {
                                temp_rate_output = "Kem";
                                break;
                            }
                    }
                    ResultContent.Text += "<td align = \"center\" style=\"color:red\" id=\"" +
                                          temp_id.Trim() + "\" name=\"" + temp_id.Trim() +
                                          "\" readonly>" + temp_rate_output + "</td>";
                }
                else
                {
                    // chua co diem TBHK
                    ResultContent.Text += "<td align = \"center\" style=\"color:ead\" id=\"" +
                                          temp_id.Trim() + "\" name=\"" + temp_id.Trim() +
                                          "\" readonly>X</td>";
                }
            }
            else
            {
                // chua tong ket
                string temp_DD = "DaoDuc" + row.ToString();
                ResultContent.Text += "<td>" +
                                      "<input id=\"" + temp_DD.Trim() +
                                      "\" type=\"text\" name=\"" + temp_DD.Trim() + "\" " +
                                      "style=\"width:100%\" runat = \"server\"/>" +
                                      "</td>";
                ResultContent.Text += "<td align = \"center\" style=\"color:black\" id=\"" +
                                      temp_id.Trim() + "\" name=\"" + temp_id.Trim() +
                                      "\" readonly>X</td>";

                // Chua co data trong databse
                SaveResult.Visible = true;
            }


            ResultContent.Text += "</tr>";
        }


        protected int GetSiSo()
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
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
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

        protected static int SetDD(string dd)
        {
            int temp = 1;
            if (dd.ToUpper() == "B")
            {
                temp = 2;
            }
            if (dd.ToUpper() == "C")
            {
                temp = 3;
            }
            if (dd.ToUpper() == "D")
            {
                temp = 4;
            }
            return temp;
        }

        protected static void InsertTable(string classname, string year, int hk, string pupilid, double tbhk, int dd,
                                          int Rate)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "INSERT INTO HSMSClassFinal VALUES ('" +
                             classname + "','" + year + "'," + hk + ",'" + pupilid + "'," +
                             tbhk + "," + dd + "," + Rate + ")";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void SaveResult_Click(object sender, EventArgs e)
        {
            int class_ss = GetSiSo();
            int hk = GetHK();
            for (int i = 1; i <= class_ss; i++)
            {
                string temp = "MSHS" + i.ToString();
                string pupilid = Request.Form[temp.Trim()];
                temp = "Mark" + i.ToString();
                string tbhk_string = Request.Form[temp.Trim()];
                double tbhk = -1;
                if (tbhk_string != "X")
                {
                    tbhk = Double.Parse(tbhk_string);
                }
                temp = "DaoDuc" + i.ToString();
                string dd_string = Request.Form[temp.Trim()];
                int Rate = -1;
                if (tbhk != -1)
                {
                    Rate = GetRate(tbhk, dd_string);
                }
                int dd = SetDD(dd_string);
                InsertTable(ClassName.SelectedItem.Value.Trim(), ClassYear.Text, hk, pupilid, tbhk, dd, Rate);
            }

            // Update lai table
            ViewClassList_Click(sender, e);
            SaveResult.Visible = false;
        }
    }
}