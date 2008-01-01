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

namespace HSMS.TEST
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {

                FileUpLoad1.SaveAs(@"F:\HSMS\HSMS\temp\" + FileUpLoad1.FileName);
                Result.Text = "File Uploaded: " + FileUpLoad1.FileName;
            }
            else
            {
                Result.Text = "No File Uploaded.";
            }


        }
    }
}
