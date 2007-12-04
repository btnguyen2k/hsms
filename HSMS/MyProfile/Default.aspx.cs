using System;
using System.Web.UI;
using HSMS.Bo.Config;
using HSMS.Bo.User;
using HSMS.UI;

namespace HSMS.MyProfile
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyProfileCommon.MyProfilePage_PageLoad(Page, (MasterMain) Master);            
        }
    }
}