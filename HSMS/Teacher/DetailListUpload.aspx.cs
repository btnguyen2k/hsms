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
    public partial class DetailListUpload : System.Web.UI.Page
    {
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            id = Request.QueryString.Get("Exid");
            if (!IsPostBack)
            {
                InitTable();
            }
        }
        
        protected void InitTable()
        {
            ResultTable.Text = "<table border=\"1\" id=\"NewsTable\" runat=\"server\">" +
                                 "<tr><td align = \"center\" nowrap=\"nowrap\" style=\"color:black\" readonly>STT</td> " +
                                 "<td  align = \"center\" style=\"color:black\" readonly>MSHS</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Bài giải</td>" +
                                 "<td  align = \"center\" style=\"color:black\" readonly>Ngày tháng</td>";
            ResultTable.Text += "</tr>";
            id = Request.QueryString.Get("Exid");
            OleDbConnection conn = DbUtils.GetSQLDbConnection();
            conn.Open();
            OleDbCommand cm = new OleDbCommand();
            cm.Connection = conn;
            cm.CommandText = "Select * from HSMSUploadSolution ORDER BY ULDate DESC";
            int index = 0;
            OleDbDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Exid"].ToString().Trim() == id.Trim())
                {
                    index++;
                    ResultTable.Text += "<tr>";
                    ResultTable.Text += "<td align = \"center\">" + index + "</tr>";
                    ResultTable.Text += "<td align = \"center\">" + dr["Pupil_id"].ToString() + "</tr>";

                    string site = AppDomain.CurrentDomain.BaseDirectory + "UploadSolution\\" +
                                      dr["filename"].ToString();
                    //string site = "Http://localhost/hsms/UploadSolution/" + dr["filename"].ToString();
                    ResultTable.Text += "<td align = \"center\" style=\"color:black\" readonly>" +
                            "<a href=\"" + site + "\">" + dr["filename"].ToString() + "</td>";
                    ResultTable.Text += "<td align = \"center\">" + dr["ULDate"].ToString() + "</tr>";
                    ResultTable.Text += "</tr>";
                }
            }
            ResultTable.Text += "</table>";
            dr.Dispose();
            dr.Close();
            cm.Dispose();
            conn.Close();
            conn.Dispose();
        }

    }
}
