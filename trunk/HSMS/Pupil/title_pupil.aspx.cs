using System;
using System.Web.UI;

namespace HSMS.Pupil
{
    public partial class title_pupil : Page
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
                Welcome.Text = "Chào học sinh, " + Session["login_id"].ToString().Trim() + "!";
                // +Session["login_pass"] + Session["login_state"];
            }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["login_state"] = "not_login";
            Session.Timeout = 5;
            Response.Redirect("~/main.aspx");
        }
    }
}