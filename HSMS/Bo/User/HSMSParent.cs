namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represent a parent in school.
    /// </summary>
    public class HSMSParent : DelegatedUser
    {
        /// <summary>
        /// Constructs a new HSMSParent object.
        /// </summary>
        public HSMSParent()
        {
        }

        /// <summary>
        /// Constructs a new HSMSParent object.
        /// </summary>
        /// <param name="hsmsUser"></param>
        public HSMSParent(HSMSUser hsmsUser)
            : base(hsmsUser)
        {
        }
    }
}