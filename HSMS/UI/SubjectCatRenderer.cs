using HSMS.Bo.Subject;

namespace HSMS.UI
{
    public class SubjectCatRenderer
    {
        private HSMSSubjectCat subjectCat;

        public SubjectCatRenderer(HSMSSubjectCat subjectCat)
        {
            this.subjectCat = subjectCat;
        }

        public string Id
        {
            get { return subjectCat.Id; }
        }

        public string Name
        {
            get { return subjectCat.Name; }
        }

        public string Description
        {
            get { return subjectCat.Description; }
        }

        public string HeadTeacherLink
        {
            get
            {
                if ( subjectCat.HeadUserId == 0 )
                {
                    return "";
                }
                return "<a href=\"ViewTeacher.aspx?id=" + subjectCat.HeadUserId + "\">Trưởng Bộ Môn</a>";
            }
        }

        public string UrlDelete
        {
            get { return ""; }
        }

        public string UrlEdit
        {
            get { return ""; }
        }
    }
}