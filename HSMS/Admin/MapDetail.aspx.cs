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
    public partial class MapDetail : System.Web.UI.Page
    {
        string[] class_name = new string[40];
        private int class_count = 0;
        //private bool NewData = CheckNewData();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }

            if (!IsPostBack)
            {
                GetCurrentClass();
                InitGroup();
                if ( !CheckNewData() )
                {
                    GetRoom();
                }
                /*                
                if (!NewData)
                {
                    GetRoom();
                }
                */
            }
        }

        static protected void GetRoomValues(string roomname, DropDownList s, DropDownList c)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClassRoom";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["room_name"].ToString().Trim() == roomname.Trim())
                {
                    s.Text = dr["class_id_s"].ToString();
                    c.Text = dr["class_id_c"].ToString();
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void GetRoom()
        {
            GetRoomValues("A11", Class1_S, Class1_C);
            GetRoomValues("A12", Class2_S, Class2_C);
            GetRoomValues("A13", Class3_S, Class3_C);
            GetRoomValues("A14", Class4_S, Class4_C);
            GetRoomValues("A15", Class5_S, Class5_C);
            GetRoomValues("A21", Class6_S, Class6_C);
            GetRoomValues("A22", Class7_S, Class7_C);
            GetRoomValues("A23", Class8_S, Class8_C);
            GetRoomValues("A24", Class9_S, Class9_C);
            GetRoomValues("A24", Class10_S, Class10_C);
            GetRoomValues("A26", Class11_S, Class11_C);
            GetRoomValues("A27", Class12_S, Class12_C);
            GetRoomValues("B11", Class13_S, Class13_C);
            GetRoomValues("B12", Class14_S, Class14_C);
            GetRoomValues("B13", Class15_S, Class15_C);
            GetRoomValues("B14", Class16_S, Class16_C);
            GetRoomValues("B21", Class17_S, Class17_C);
            GetRoomValues("B22", Class18_S, Class18_C);
            GetRoomValues("B23", Class19_S, Class19_C);
            GetRoomValues("B24", Class20_S, Class20_C);
        }

        static protected bool CheckNewData()
        {
            bool temp = true;
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClassRoom";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                count++;
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            if (count != 0)
            {
                temp = false;
            }
            return temp;
        }

        protected void GetValues(DropDownList droplist)
        {
            for (int i=1; i <= class_count; i++)
            {
                droplist.Items.Add(class_name[i]);
            }
        }

        protected void InitGroup()
        {
            GetValues(Class1_S);
            GetValues(Class1_C);
            GetValues(Class2_S);
            GetValues(Class2_C);
            GetValues(Class3_S);
            GetValues(Class3_C);
            GetValues(Class4_S);
            GetValues(Class4_C);
            GetValues(Class5_S);
            GetValues(Class5_C);
            GetValues(Class6_S);
            GetValues(Class6_C);
            GetValues(Class7_S);
            GetValues(Class7_C);
            GetValues(Class8_S);
            GetValues(Class8_C);
            GetValues(Class9_S);
            GetValues(Class9_C);
            GetValues(Class10_S);
            GetValues(Class10_C);
            GetValues(Class11_S);
            GetValues(Class11_C);
            GetValues(Class12_S);
            GetValues(Class12_C);
            GetValues(Class13_S);
            GetValues(Class13_C);
            GetValues(Class14_S);
            GetValues(Class14_C);
            GetValues(Class15_S);
            GetValues(Class15_C);
            GetValues(Class16_S);
            GetValues(Class16_C);
            GetValues(Class17_S);
            GetValues(Class17_C);
            GetValues(Class18_S);
            GetValues(Class18_C);
            GetValues(Class19_S);
            GetValues(Class19_C);
            GetValues(Class20_S);
            GetValues(Class20_C);
        }

        protected void GetCurrentClass()
        {
            int index = 1;
            class_name[index] = "";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSClass";
            OleDbDataReader dr = cm.ExecuteReader(); 
            while (dr.Read())
            {
                string temp_year = dr["year"].ToString();
                int currentyear = DateTime.Now.Year;
                if (DateTime.Now.Month < 7)
                {
                    currentyear -= 1;
                }
                if (temp_year.Trim() == currentyear.ToString().Trim())
                {
                    index++;
                    class_name[index] = dr["class_id"].ToString();
                }
            }
            class_count = index;
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        static protected void DeleteDB()
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Delete from hsmsclassroom";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

        protected void SaveRoomValues(string roomname, string s, string c)
        {
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "INSERT INTO HSMSClassRoom (room_name, class_id_s, class_id_c) VALUES ('" +
                                 roomname + "','" + s.Trim() + "','" + c.Trim() + "')";
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
        
        protected bool VerifyData()
        {
            bool temp = true;
            string[] class_name_s = new string[21];
            string[] class_name_c = new string[21];
            class_name_s[1] = Class1_S.SelectedItem.Value;
            class_name_c[1] = Class1_C.SelectedItem.Value;

            class_name_s[2] = Class2_S.SelectedItem.Value;
            class_name_c[2] = Class2_C.SelectedItem.Value;

            class_name_s[3] = Class3_S.SelectedItem.Value;
            class_name_c[3] = Class3_C.SelectedItem.Value;

            class_name_s[4] = Class4_S.SelectedItem.Value;
            class_name_c[4] = Class4_C.SelectedItem.Value;

            class_name_s[5] = Class5_S.SelectedItem.Value;
            class_name_c[5] = Class5_C.SelectedItem.Value;

            class_name_s[6] = Class6_S.SelectedItem.Value;
            class_name_c[6] = Class6_C.SelectedItem.Value;

            class_name_s[7] = Class7_S.SelectedItem.Value;
            class_name_c[7] = Class7_C.SelectedItem.Value;

            class_name_s[8] = Class8_S.SelectedItem.Value;
            class_name_c[8] = Class8_C.SelectedItem.Value;

            class_name_s[9] = Class9_S.SelectedItem.Value;
            class_name_c[9] = Class9_C.SelectedItem.Value;

            class_name_s[10] = Class10_S.SelectedItem.Value;
            class_name_c[10] = Class10_C.SelectedItem.Value;

            class_name_s[11] = Class11_S.SelectedItem.Value;
            class_name_c[11] = Class11_C.SelectedItem.Value;

            class_name_s[12] = Class12_S.SelectedItem.Value;
            class_name_c[12] = Class12_C.SelectedItem.Value;

            class_name_s[13] = Class13_S.SelectedItem.Value;
            class_name_c[13] = Class13_C.SelectedItem.Value;

            class_name_s[14] = Class14_S.SelectedItem.Value;
            class_name_c[14] = Class14_C.SelectedItem.Value;

            class_name_s[15] = Class15_S.SelectedItem.Value;
            class_name_c[15] = Class15_C.SelectedItem.Value;

            class_name_s[16] = Class16_S.SelectedItem.Value;
            class_name_c[16] = Class16_C.SelectedItem.Value;

            class_name_s[17] = Class17_S.SelectedItem.Value;
            class_name_c[17] = Class17_C.SelectedItem.Value;

            class_name_s[18] = Class18_S.SelectedItem.Value;
            class_name_c[18] = Class18_C.SelectedItem.Value;
            
            class_name_s[19] = Class19_S.SelectedItem.Value;
            class_name_c[19] = Class19_C.SelectedItem.Value;
            
            class_name_s[20] = Class20_S.SelectedItem.Value;
            class_name_c[20] = Class20_C.SelectedItem.Value;
            Result.Text = "";
            for (int i = 1; i < 20; i++ )
            {
                for (int j = i+1; j <= 20; j++)
                {
                    if (class_name_s[i] != "" && class_name_s[j] != "")
                    {
                        if (class_name_s[i] == class_name_s[j])
                        {
                            Result.Text += "Buổi sáng: Dòng " + i + " và dòng " + j + " trùng nhau!<br>";
                            temp = false;
                        }
                    }
                    if (class_name_c[i] != "" && class_name_c[j] != "")
                    {
                        if (class_name_c[i] == class_name_c[j])
                        {
                            Result.Text += "Buổi chiều: Dòng " + i + " và dòng " + j + " trùng nhau!<br>";
                            temp = false;
                        }
                    }
                }
            }
            return temp;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            bool check_data = VerifyData();
            if (check_data)
            {
                DeleteDB();
                SaveRoomValues("A11", Class1_S.SelectedItem.Value, Class1_C.SelectedItem.Value);
                SaveRoomValues("A12", Class2_S.SelectedItem.Value, Class2_C.SelectedItem.Value);
                SaveRoomValues("A13", Class3_S.SelectedItem.Value, Class3_C.SelectedItem.Value);
                SaveRoomValues("A14", Class4_S.SelectedItem.Value, Class4_C.SelectedItem.Value);
                SaveRoomValues("A15", Class5_S.SelectedItem.Value, Class5_C.SelectedItem.Value);
                SaveRoomValues("A21", Class6_S.SelectedItem.Value, Class6_C.SelectedItem.Value);
                SaveRoomValues("A22", Class7_S.SelectedItem.Value, Class7_C.SelectedItem.Value);
                SaveRoomValues("A23", Class8_S.SelectedItem.Value, Class8_C.SelectedItem.Value);
                SaveRoomValues("A24", Class9_S.SelectedItem.Value, Class9_C.SelectedItem.Value);
                SaveRoomValues("A24", Class10_S.SelectedItem.Value, Class10_C.SelectedItem.Value);
                SaveRoomValues("A26", Class11_S.SelectedItem.Value, Class11_C.SelectedItem.Value);
                SaveRoomValues("A27", Class12_S.SelectedItem.Value, Class12_C.SelectedItem.Value);
                SaveRoomValues("B11", Class13_S.SelectedItem.Value, Class13_C.SelectedItem.Value);
                SaveRoomValues("B12", Class14_S.SelectedItem.Value, Class14_C.SelectedItem.Value);
                SaveRoomValues("B13", Class15_S.SelectedItem.Value, Class15_C.SelectedItem.Value);
                SaveRoomValues("B14", Class16_S.SelectedItem.Value, Class16_C.SelectedItem.Value);
                SaveRoomValues("B21", Class17_S.SelectedItem.Value, Class17_C.SelectedItem.Value);
                SaveRoomValues("B22", Class18_S.SelectedItem.Value, Class18_C.SelectedItem.Value);
                SaveRoomValues("B23", Class19_S.SelectedItem.Value, Class19_C.SelectedItem.Value);
                SaveRoomValues("B24", Class20_S.SelectedItem.Value, Class20_C.SelectedItem.Value);
                Result.Text = "Cập nhật dữ liệu thành công!";
            }
            else
            {
                Result.Text += "Dữ liệu còn sai sót! Chưa thể cập nhật được";
                //GetRoom();
            }
        }
    }
}
