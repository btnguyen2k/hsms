using System;
using System.Web.UI;

namespace HSMS.Admin
{
    public partial class function_admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("~/main.aspx");
            }
            Response.Write("Test");
        }
    }
}