using System;
using System.Web.UI;
using HSMS.UI;

namespace HSMS.Admin
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCommon.AdminPage_PageLoad(Page, (MasterMain) Master);
        }
    }
}