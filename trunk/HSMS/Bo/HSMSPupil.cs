namespace HSMS.Bo
{
    /// <summary>
    /// This class represent a pupil in school.
    /// </summary>
    public class HSMSPupil
    {
        private HSMSUser hsmsUser;

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
