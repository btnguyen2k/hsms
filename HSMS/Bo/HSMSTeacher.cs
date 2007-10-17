namespace HSMS.Bo
{
    /// <summary>
    /// This class represent a teacher in school.
    /// </summary>
    public class HSMSTeacher
    {
        private HSMSUser hsmsUser;

        /// <summary>
        /// Constructs a new HSMSTeacher object.
        /// </summary>
        public HSMSTeacher()
        {
        }

        /// <summary>
        /// Constructs a new HSMSTeacher object.
        /// </summary>
        /// <param name="hsmsUser"></param>
        public HSMSTeacher(HSMSUser hsmsUser)
        {
            this.hsmsUser = hsmsUser;
        }

        public HSMSUser HsmsUser
        {
            get { return hsmsUser; }
            set { hsmsUser = value; }
        }
    }
}
