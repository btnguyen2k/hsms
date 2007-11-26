namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represent a pupil in school.
    /// </summary>
    public class HSMSPupil : DelegatedUser
    {
        /// <summary>
        /// Constructs a new HSMSPupil object.
        /// </summary>
        public HSMSPupil()
        {
        }

        /// <summary>
        /// Constructs a new HSMSPupil object.
        /// </summary>
        /// <param name="hsmsUser"></param>
        public HSMSPupil(HSMSUser hsmsUser)
            : base(hsmsUser)
        {
        }
    }
}