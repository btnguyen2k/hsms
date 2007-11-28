using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HSMS.Teacher
{
    public partial class title_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            else
            {
                Session.Timeout = 60;
                Welcome.Text = "Chào giáo viên, " + Session["login_id"].ToString().Trim() + "!";
                // +Session["login_pass"] + Session["login_state"];
            }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["login_state"] = "not_login";
            Session.Timeout = 5;
            Response.Redirect("http://localhost/HSMS/main.aspx");
        }
    }
}
