using System;
using System.IO;
using System.Web.UI;

namespace HSMS
{
    public partial class content : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "App_Browsers\\TranQuang.doc");
        }
    }
}