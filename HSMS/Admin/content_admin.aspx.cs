using System;
using System.Web.UI;

namespace HSMS.Admin
{
    public partial class content_admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login simple
            if (Session.Timeout != 60)
            {
                Response.Redirect("http://localhost/HSMS/main.aspx");
            }
        }
    }
}