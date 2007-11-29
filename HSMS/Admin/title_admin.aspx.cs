using System;
using System.Web.UI;

namespace HSMS.Admin
{
    public partial class title_admin : Page
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
                Welcome.Text = "Hi, " + Session["login_id"].ToString().Trim() + "!";
                // +Session["login_pass"] + Session["login_state"];
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["login_state"] = "not_login";
            Session.Timeout = 5;
            Response.Redirect("http://localhost/HSMS/main.aspx");
        }
    }
}