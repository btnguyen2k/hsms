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
    public partial class Searching : System.Web.UI.Page
    {
        string[] SplitString = new string[100];
        private int count;
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SplitStringFunction (string input)
        {
            char[] spliter = {' '};
            SplitString = input.Split(spliter);
        }

        static protected int GetUserStatus(string id)
        {
            int temp = 1;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "select teacher_id from hsmsteacher";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["teacher_id"].ToString().Trim() == id.Trim())
                {
                    temp = 2;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            return temp;
        }

        static protected bool CheckUser(string id)
        {
            bool temp = true;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "select * from hsmsadmin";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Admin_id"].ToString().Trim() == id.Trim())
                {
                    temp = false;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            return temp;
        }

        protected void StartSearch_Click(object sender, EventArgs e)
        {
            Label4.Visible = true;
            SplitStringFunction(InputText.Text.Trim());
            int search_counter = 0;
            Result.Text = "<table width=100% border=\"1\"> <tr> <td align=center>STT</td>" +
                "<td align=center>Tên</td>" +
                "<td align=center>Mã số</td>" +
                "<td align=center>Ghi chú</td>" +
                "</tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * From HSMSUSer Where ufull_name like '%" + SplitString[0] + "%" +
                             SplitString[SplitString.Length - 1] + "%'";
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string temp_id = dr["ulogin_name"].ToString().Trim();
                bool check = CheckUser(temp_id);
                if (check)
                {
                    string temp_name = dr["ufull_name"].ToString().Trim();
                    int status = GetUserStatus(temp_id);
                    search_counter++;
                    Result.Text += "<tr>";
                    Result.Text += "<td align=center>" + search_counter + "</td>";
                    string rediresct_site = "DetailSearching.aspx?status=" + status.ToString() +
                                            "&id=" + temp_id;
                    Result.Text += "<td align = center><a href =" + rediresct_site + ">" +
                        temp_name + "</a></td>";
                    Result.Text += "<td align=center>" + temp_id + "</td>";
                    if (status == 1)
                    {
                        Result.Text += "<td align=center>Học sinh</td>";
                    }
                    else
                    {
                        Result.Text += "<td align=center>Giáo viên</td>";
                    }

                    Result.Text += "</tr>";
                }
            }
            Result.Text += "</table>";
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Dispose();
            if (search_counter == 0)
            {
                Result.Text = "Không tìm thấy dữ liệu!";
            }
        }
    }
}
