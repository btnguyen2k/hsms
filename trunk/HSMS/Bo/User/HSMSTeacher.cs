namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represent a teacher in school.
    /// </summary>
    public class HSMSTeacher : DelegatedUser
    {
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
            : base(hsmsUser)
        {
        }
    }
}