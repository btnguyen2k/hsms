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
    public partial class EditNews : System.Web.UI.Page
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
            cm.CommandText = "Select * from HSMSNews";
            OleDbDataReader dr = cm.ExecuteReader();
            while(dr.Read())
            {
                if (dr["newid"].ToString() != "")
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
            NewsTable.Text = "<table border=\"1\" id=\"NewsTable\" runat=\"server\">" +
                                 "<tr><td align = \"center\" nowrap=\"nowrap\" style=\"color:black\" readonly>STT</td> " +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Nội dung</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Ngày tháng</td>";
            NewsTable.Text += "</tr>";
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSNews ORDER BY Time DESC";
            int index = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                index++;
                NewsTable.Text += "<tr>";
                NewsTable.Text += "<td align = \"center\">" + index + "</tr>";
                string redirect_site = "DetailNews.aspx?newid=" + dr["newid"].ToString();
                NewsTable.Text += "<td align = \"center\" style=\"color:black\" readonly>" +
                        "<a href=\"" + redirect_site + "\">" + dr["title"].ToString() + "</td>";
                NewsTable.Text += "<td align = \"center\">" + dr["Time"].ToString() + "</tr>";
                NewsTable.Text += "</tr>";
            }
            NewsTable.Text += "</table>";
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();

        }
    }
}
