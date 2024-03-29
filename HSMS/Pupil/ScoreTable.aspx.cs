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

namespace HSMS.Pupil
{
    public partial class ScoreTable : System.Web.UI.Page
    {
        private string[] subjectlist = new string[15];
        private string[] TBHK = new string[3],
                         dd = new string[3],
                         rate = new string[3];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            if (DateTime.Now.Month < 6)
            {
                int temp = DateTime.Now.Year - 1;
                ClassYear.Text = temp.ToString();
            }
            else
            {
                ClassYear.Text = DateTime.Now.Year.ToString();
            }
        }

        static protected string GetClass(string pupilid, string year)
        {
            string temp = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM link_pupil_class";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupill_id"].ToString().Trim() == pupilid.Trim()
                    && dr["year_start"].ToString().Trim() == year.Trim())
                {
                    temp = dr["class_id"].ToString().Trim();
                }
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        protected void initTable()
        {
            ResultContent.Text = "<table border=\"1\" style=\"width:100%\" id=\"TableScore\" runat=\"server\">" +
                                 "<tr><td align = \"center\" nowrap=\"nowrap\" style=\"color:black\" readonly>Môn học</td> " +
                                 "<td  align = \"center\" style=\"color:black\" readonly>HK I</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>HK II</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>TB cả năm</td>" +
                                 "</tr>";
        }

        protected int GetSubject(string classname, string year)
        {
            int temp_subject = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT DISTINCT subject_id, class_id FROM HSMSClassSchedule";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["subject_id"].ToString().Trim() != "")
                {
                    temp_subject++;
                    subjectlist[temp_subject] = dr["subject_id"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();

            return temp_subject;
        }

        static protected string GetScore(string subject, string classname, string year, string pupilid, int hk)
        {
            string temp = "";
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
                    && dr["subject_id"].ToString().Trim() == subject.Trim()
                    && dr["HK"].ToString().Trim() == hk.ToString().Trim() )
                {
                    temp = dr["average_scoreI"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
            return temp;
        }

        protected void CreateNewRow(string subject, string classname, string year, string pupilid)
        {
            bool check_TBCN = true;
            ResultContent.Text += "<tr>";
            ResultContent.Text += "<td  align = \"center\" style=\"color:black\" readonly>" + subject + "</td>";
            string diem1 = GetScore(subject, classname, year, pupilid, 1);
            if (diem1 == "")
            {
                check_TBCN = false;
                ResultContent.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td></tr>";
            }
            string diem2 = GetScore(subject, classname, year, pupilid, 2);
            if (diem2 == "")
            {
                check_TBCN = false;
                ResultContent.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td></tr>";
            }
            if (check_TBCN)
            {
                string redirect_site = "../Teacher/DetailPupilTBMK.aspx?class_id=" + classname.Trim() +
                                      "&year=" + year.Trim() + "&hk=" + 1 + "&pupil_id=" +
                                      pupilid.Trim() + "&subject_id=" + subject;
                ResultContent.Text += "<td align=center><a href =\"" + redirect_site.Trim() + "\">" +
                    diem1.Trim() + " </td>";
                redirect_site = "../Teacher/DetailPupilTBMK.aspx?class_id=" + classname.Trim() +
                                      "&year=" + year.Trim() + "&hk=" + 2 + "&pupil_id=" +
                                      pupilid.Trim() + "&subject_id=" + subject;
                ResultContent.Text += "<td align=center><a href =\"" + redirect_site.Trim() + "\">" +
                    diem2.Trim() + " </td>";
                double diem_nam = (Double.Parse(diem2)*2 + Double.Parse(diem1))/3;
                diem_nam = Math.Round(diem_nam, 1);
                ResultContent.Text += "<td  align = \"center\" style=\"color:black\" readonly>"+diem_nam.ToString() + "</td></tr>";
            }
            else
            {
                ResultContent.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td></tr>";
            }
            ResultContent.Text += "</tr>";
        }

        protected void GetScoreFinal(string classname, string year, string pupilid, int hk)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["class_id"].ToString().Trim() == classname.Trim()
                    && dr["year"].ToString().Trim() == year.Trim()
                    && dr["HK"].ToString().Trim() == hk.ToString().Trim())
                {
                    TBHK[hk] = dr["TBHK"].ToString().Trim();
                    dd[hk] = dr["personality"].ToString().Trim();
                    rate[hk] = dr["rate"].ToString().Trim();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        static protected string GetDD(string dd)
        {
            string temp_return = "A";
            switch (Int32.Parse(dd.Trim()))
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

        static protected string GetRate(string rate)
        {
            string temp_rate_output = "Gioi";
            switch (Int32.Parse(rate))
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
            return temp_rate_output;
        }

        static protected int GetFinalRate(double diem, string dd)
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

        protected void CreateFinalTable(string classname, string year, string pupilid)
        {
            ResultFinal.Text = "<table border=\"1\" style=\"width:100%\" id=\"TableFinal\" runat=\"server\">" +
                                 "<tr><td align = \"center\" nowrap=\"nowrap\" style=\"color:black\" readonly>HK\\XH</td> " +
                                 "<td  align = \"center\" style=\"color:black\" readonly>TBHK</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Đạo đức</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Xếp loại</td>" +
                                 "</tr>";
            for (int i = 1; i <= 2;i++ )
            {
                TBHK[i] = "";
                rate[i] = "";
                dd[i] = "";
            }
            GetScoreFinal(classname, year, pupilid, 1);
            GetScoreFinal(classname, year, pupilid, 2);
            bool check = true;
            for (int i = 1; i <= 2;i++)
            {
                ResultFinal.Text += "<tr><td  align = \"center\" style=\"color:black\" readonly>HK " + i + " </td>";
                if (TBHK[i] == "")
                {
                    ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td>";
                }
                else
                {
                    ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>" + TBHK[i] + "</td>";
                }
                
                if (dd[i] == "" && dd[i] == "-1")
                {
                    check = false;
                    ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td>";
                    ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td>";
                }
                else
                {
                    string temp_dd = GetDD(dd[i]);
                    string redirect_site = "../Teacher/DetailPupiLDD.aspx?class_id=" + classname.Trim() +
                                      "&year=" + year.Trim() + "&hk=" + i + "&pupil_id=" +
                                      pupilid.Trim();
                    ResultFinal.Text += "<td align = \"center\" style=\"color:black\" readonly>" +
                        "<a href=\"" + redirect_site + "\">" + temp_dd + "</td>";
                    
                    string temp_rate = GetRate(rate[i]);
                    ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>" + temp_rate + "</td>";

                }
                ResultFinal.Text += "</tr>";
            }

            ResultFinal.Text += "<tr><td  align = \"center\" style=\"color:black\" readonly>Cả năm</td>";
            double final_diem = (Double.Parse(TBHK[2]) * 2 + Double.Parse(TBHK[1])) / 3;
            if (TBHK[1] == "" || TBHK[2] == "")
            {
                ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td>";
            }
            else
            {
                final_diem = Math.Round(final_diem, 1);
                ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>" + final_diem.ToString() + "</td>";
            }
            if (check)
            {
                int temp_dd = (int)(Int32.Parse(dd[2]) * 2 + Int32.Parse(dd[1])) / 3;
                string real_dd = GetDD(temp_dd.ToString());
                ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>" + real_dd + "</td>";
                int temp_rate = GetFinalRate(final_diem, real_dd);
                string real_rate = GetRate(temp_rate.ToString());
                ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>" + real_rate + "</td>";
            }
            else
            {
                ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td>";
                ResultFinal.Text += "<td  align = \"center\" style=\"color:black\" readonly>X</td>";
            }
            ResultFinal.Text += "</tr>";
            ResultFinal.Text += "</table>";
        }

        protected void ConfirmYear_Click(object sender, EventArgs e)
        {
            ResultContent.Text = "";
            string classname = GetClass(Session["login_id"].ToString(), ClassYear.Text);
            if (classname == "")
            {
                ResultContent.Text = "Không có năm học này!";
                ClassYear.Text = "";
            }
            else
            {
                ClassYear.Enabled = false;
                ConfirmYear.Enabled = false;
                int subjectbumber = GetSubject(classname, ClassYear.Text);
                if (subjectbumber == 0)
                {
                    ResultContent.Text = "Chưa có điểm!!!";
                    ClassYear.Enabled = true;
                    ConfirmYear.Enabled = true;
                    ClassYear.Text = "";
                }
                else
                {
                    initTable();
                    for (int i = 1; i <= subjectbumber; i++ )
                    {
                        CreateNewRow(subjectlist[i], classname, ClassYear.Text, Session["login_id"].ToString().Trim());
                    }
                    ResultContent.Text += "</Table>";
                    CreateFinalTable(classname, ClassYear.Text, Session["login_id"].ToString());
                }
            }
        }
    }
}
