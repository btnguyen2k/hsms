using System;
using System.Collections.Generic;
using System.Web.UI;
using HSMS.Bo.Subject;
using HSMS.UI;

namespace HSMS.Admin
{
    public partial class SubjectCatList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCommon.AdminPage_PageLoad(Page, (MasterMain) Master);
            IList<HSMSSubjectCat> subjectCats = SubjectManager.GetAllSubjectCats();
            IList<SubjectCatRenderer> rendererList = new List<SubjectCatRenderer>();
            foreach (HSMSSubjectCat subjectCat in subjectCats)
            {
                rendererList.Add(new SubjectCatRenderer(subjectCat));
            }
            RepSubjectCats.DataSource = rendererList;
            RepSubjectCats.DataBind();
        }
    }
}