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
    public partial class Exercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            int count = 0;
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSExercise";
            OleDbDataReader dr = cm.ExecuteReader();
            while(dr.Read())
            {
                if (dr["Exid"].ToString() != "")
                {
                    count++;
                }
            }
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
            //if (count != 0)
            //{
                InitTable();
            //}
        }

        protected void InitTable()
        {
            ExerciseTable.Text = "<table border=\"1\" id=\"NewsTable\" runat=\"server\">" +
                                 "<tr><td align = \"center\" nowrap=\"nowrap\" style=\"color:black\" readonly>STT</td> " +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Nội dung</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Ngày tháng</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>MSGV</td>";
            ExerciseTable.Text += "</tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSExercise ORDER BY ExDateTime DESC";
            int index = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                index++;
                ExerciseTable.Text += "<tr>";
                ExerciseTable.Text += "<td align = \"center\">" + index + "</tr>";
                string redirect_site = "DetailExercise.aspx?Exid=" + dr["Exid"].ToString();
                ExerciseTable.Text += "<td align = \"center\" style=\"color:black\" readonly>" +
                        "<a href=\"" + redirect_site + "\">" + dr["ExTitle"].ToString() + "</td>";
                ExerciseTable.Text += "<td align = \"center\">" + dr["ExDateTime"].ToString() + "</tr>";
                ExerciseTable.Text += "<td align = \"center\">" + dr["ExTeaccherId"].ToString() + "</tr>";
                ExerciseTable.Text += "</tr>";
            }
            ExerciseTable.Text += "</table>";
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
