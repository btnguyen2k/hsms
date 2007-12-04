using System;
using System.Web.UI;
using HSMS.Bo.Config;

namespace HSMS
{
    public partial class PageDefault : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = ConfigManager.GetSchoolName() + " - Trang Chủ";
            ((MasterMain) Master).SetPageHeader(ConfigManager.GetSchoolName());
        }
    }
}