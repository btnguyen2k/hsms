using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using HSMS.Db;

namespace HSMS.Teacher
{
    public partial class main_class_manager : Page
    {
        private string[] temp_diem = new string[3];
        private string[] temp_dd = new string[3];
        private string[] temp_rate = new string[3];

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            StaticTable.Visible = false;
            Label4.Visible = false;
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

        protected static string GetDD(int dd)
        {
            string temp = "A";
            switch (dd)
            {
                case 1:
                    {
                        temp = "A";
                        break;
                    }
                case 2:
                    {
                        temp = "B";
                        break;
                    }
                case 3:
                    {
                        temp = "C";
                        break;
                    }
                case 4:
                    {
                        temp = "D";
                        break;
                    }
            }
            return temp;
        }

        protected static string GetRate(int rate)
        {
            string temp = "Gioi";
            switch (rate)
            {
                case 1:
                    {
                        temp = "Gioi";
                        break;
                    }
                case 2:
                    {
                        temp = "Kha";
                        break;
                    }
                case 3:
                    {
                        temp = "TB";
                        break;
                    }
                case 4:
                    {
                        temp = "Yeu";
                        break;
                    }
                case 5:
                    {
                        temp = "Kem";
                        break;
                    }
            }
            return temp;
        }

        protected void CreateHK(string pupilid, int hk, int row, int col, int stt)
        {
            int count = 0;
            string diem = "", rate = "", dd = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year"].ToString().Trim() == ClassYear.Text
                    && dr["pupil_id"].ToString().Trim() == pupilid.Trim()
                    && dr["hk"].ToString().Trim() == hk.ToString().Trim())
                {
                    count++;
                    diem = dr["TBHK"].ToString().Trim();
                    rate = dr["rate"].ToString().Trim();
                    dd = dr["personality"].ToString().Trim();
                }
            }
            if (count == 0)
            {
                temp_diem[stt] = "X";
                temp_dd[stt] = "X";
                temp_rate[stt] = "X";
            }
            else
            {
                if (diem.Trim() == "-1")
                {
                    temp_dd[stt] = "X";
                    temp_rate[stt] = "X";
                }
                else
                {
                    temp_diem[stt] = diem;
                    temp_rate[stt] = rate;
                }
                temp_dd[stt] = dd;
            }
            ClassListTable.Rows[row].Cells[col].Text = temp_diem[stt];
            if (temp_dd[stt] != "X")
            {
                string real_dd = GetDD(Int32.Parse(temp_dd[stt]));
                ClassListTable.Rows[row].Cells[col + 1].Text = real_dd;
            }
            else
            {
                ClassListTable.Rows[row].Cells[col + 1].Text = "X";
            }
            if (temp_rate[stt] != "X")
            {
                string real_rate = GetRate(Int32.Parse(temp_rate[stt]));
                ClassListTable.Rows[row].Cells[col + 2].Text = real_rate;
            }
            else
            {
                ClassListTable.Rows[row].Cells[col + 2].Text = "X";
            }

            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected static int CalculateRate(double diem, string dd)
        {
            int temp_return = 1;
            if (diem >= 8)
            {
                if (dd.Trim() == "B")
                {
                    temp_return = 2;
                }
                if (dd.Trim() == "C" || dd.Trim() == "D")
                {
                    temp_return = 3;
                }
            }

            if (diem < 8 && diem >= 6.5)
            {
                temp_return = 2;
                if (dd.Trim() == "C" || dd.Trim() == "D")
                {
                    temp_return = 3;
                }
            }
            if (diem < 6.5 && diem >= 5)
            {
                temp_return = 3;
                if (dd.Trim() == "D")
                {
                    temp_return = 4;
                }
            }
            if (diem < 5)
            {
                temp_return = 5;
            }
            return temp_return;
        }

        protected void CreateNewRow(int index, string pupilid)
        {
            ClassListTable.Rows.Add(new TableRow());
            for (int i = 0; i <= 11; i++)
            {
                ClassListTable.Rows[index].Cells.Add(new TableCell());
                ClassListTable.Rows[index].Cells[i].HorizontalAlign = HorizontalAlign.Center;
                ClassListTable.Rows[index].Cells[i].Wrap = false;
            }
            ClassListTable.Rows[index].Cells[0].Text = index.ToString();

            string name = GetFullName(pupilid);
            ClassListTable.Rows[index].Cells[1].Text = name;
            ClassListTable.Rows[index].Cells[2].Text = pupilid;
            CreateHK(pupilid, 1, index, 3, 1);
            CreateHK(pupilid, 2, index, 6, 2);

            bool condition = true;
            double TBHK = 0;
            int personality = 0, rate = 0;

            if (temp_diem[1] != "X" && temp_diem[2] != "X")
            {
                double real_diem = (Double.Parse(temp_diem[2])*2 + Double.Parse(temp_diem[1]))/3;
                real_diem = Math.Round(real_diem, 1);
                TBHK = real_diem;
                ClassListTable.Rows[index].Cells[9].Text = real_diem.ToString();
            }
            else
            {
                ClassListTable.Rows[index].Cells[9].Text = "X";
                condition = false;
            }
            if (temp_dd[1] != "X" && temp_dd[2] != "X")
            {
                double real_dd = (Int32.Parse(temp_dd[2])*2 + Int32.Parse(temp_dd[1]))/3;
                real_dd = Math.Round(real_dd, 0);
                string temp = GetDD((int) (real_dd));
                personality = (int) (real_dd);
                ClassListTable.Rows[index].Cells[10].Text = temp;
            }
            else
            {
                ClassListTable.Rows[index].Cells[10].Text = "X";
                condition = false;
            }

            string temp_TK_diem = ClassListTable.Rows[index].Cells[9].Text;
            string temp_TK_dd = ClassListTable.Rows[index].Cells[10].Text;
            if (temp_TK_diem != "X" && temp_TK_dd != "X")
            {
                int real_rate_int = CalculateRate(Double.Parse(temp_TK_diem), temp_TK_dd);
                string real_rate = GetRate(real_rate_int);
                rate = real_rate_int;
                ClassListTable.Rows[index].Cells[11].Text = real_rate;
            }
            else
            {
                ClassListTable.Rows[index].Cells[11].Text = "X";
                condition = false;
            }

            // Luu lai het qua cuoi cung la HK3
            if (condition)
            {
                ShowStatitis();
                bool check = true;
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "select * from hsmsclassfinal";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                        && dr["year"].ToString().Trim() == ClassYear.Text.Trim()
                        && dr["hk"].ToString().Trim() == "3"
                        && dr["pupil_id"].ToString().Trim() == pupilid.Trim())
                    {
                        check = false;
                    }
                }
                dr.Dispose();
                dr.Close();
                cm.Dispose();
                conn.Dispose();
                conn.Close();

                if (check)
                {
                    AddResultHSMSClassFinal(ClassName.SelectedItem.Value.Trim(), ClassYear.Text.Trim(),
                                            3, pupilid, TBHK, personality, rate);
                }
            }
        }

        protected static void AddResultHSMSClassFinal(string classname, string year, int hk, string pupilid, double TBHK,
                                                      int personality, int rate)
        {
            bool check = true;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;

            cm.CommandText = "INSERT INTO HSMSClassFinal VALUES ('" + classname.Trim() + "','" + year.Trim() +
                             "'," + hk + ",'" + pupilid.Trim() + "'," + TBHK + "," + personality + "," + rate + ")";
            cm.ExecuteNonQuery();


            cm.Dispose();
            conn.Dispose();
            conn.Close();
        }

        protected void ConfirmClassList_Click(object sender, EventArgs e)
        {
            bool check_class = CheckClass(ClassName.SelectedItem.Value.Trim(), ClassYear.Text);
            if (check_class)
            {
                ClassName.Enabled = false;
                ClassYear.Enabled = false;
                ConfirmClassList.Enabled = false;

                ClassListTable.Visible = true;
                int index_row = 0;
                OleDbConnection conn = DbUtils.GetSQLDbConnection();
                conn.Open();
                // View all pupil in this class
                OleDbCommand cm = new OleDbCommand();
                cm.Connection = conn;
                cm.CommandText = "SELECT * FROM link_pupil_class ORDER BY pupill_id";
                OleDbDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                        && dr["year_start"].ToString().Trim() == ClassYear.Text.Trim())
                    {
                        index_row++;
                        CreateNewRow(index_row, dr["pupill_id"].ToString().Trim());
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
                ResultContent.Text = "Lớp không hợp lệ!!!";
            }
        }

        
        protected int GetClassNumberCondition(int condition)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year"].ToString().Trim() == ClassYear.Text.Trim()
                    && dr["hk"].ToString().Trim() == "3"
                    && Int32.Parse(dr["rate"].ToString().Trim()) < condition )
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

        protected int GetRateCondition(int condition)
        {
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClassFinal";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["class_id"].ToString().Trim() == ClassName.SelectedItem.Value.Trim()
                    && dr["year"].ToString().Trim() == ClassYear.Text.Trim()
                    && dr["hk"].ToString().Trim() == "3"
                    && Int32.Parse(dr["rate"].ToString().Trim()) == condition)
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

        protected void ShowStatitis()
        {
            Label4.Visible = true;
            StaticTable.Visible = true;
            int ClassNumber = GetClassNumberCondition(10);
            StaticTable.Text = "Tổng số học sinh của lớp là: " + ClassNumber + "<br>";
            int ClassUp = GetClassNumberCondition(4);
            double tile = 100.0*(double)ClassUp/(double)ClassNumber;
            StaticTable.Text += "Số học sinh được lên lớp là: " + ClassUp + " (tỉ lệ " +
                                Math.Round(tile, 2) + "%)<br><br>";
            StaticTable.Text += "<table width=100% border=1>";
            StaticTable.Text += "<tr><td align=center>Học lực</td>" +
                                "<td align=center>Số lượng</td>" +
                                "<td align=center>Tỉ lệ</td></tr>";

            int temp = GetRateCondition(1);
            tile = 100.0 * (double)temp / (double)ClassNumber;
            StaticTable.Text += "<tr><td align=center>Giỏi</td>" +
                                "<td align=center>" + temp + "</td>" +
                                "<td align=center>" + Math.Round(tile, 2) + "%</td></tr>";
            temp = GetRateCondition(2);
            tile = 100.0 * (double)temp / (double)ClassNumber; 
            StaticTable.Text += "<tr><td align=center>Khá</td>" +
                                "<td align=center>" + temp + "</td>" +
                                "<td align=center>" + Math.Round(tile, 2) + "%</td></tr>";
            temp = GetRateCondition(3);
            tile = 100.0 * (double)temp / (double)ClassNumber; 
            StaticTable.Text += "<tr><td align=center>Trung bình</td>" +
                                "<td align=center>" + temp + "</td>" +
                                "<td align=center>" + Math.Round(tile, 2) + "%</td></tr>";
            StaticTable.Text += "</table>";

        }
    }
}