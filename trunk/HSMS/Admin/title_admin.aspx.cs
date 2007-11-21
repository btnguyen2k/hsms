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

namespace HSMS.Admin
{
    public partial class title_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Welcome.Text = "Hi, " +Session["login_id"].ToString().Trim() + "!" + Session["login_pass"] + Session["login_state"];

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["login_state"] = false;
            Response.Redirect("http://localhost/HSMS/main.aspx");
        }
    }
}
