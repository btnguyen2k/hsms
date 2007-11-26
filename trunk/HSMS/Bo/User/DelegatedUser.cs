namespace HSMS.Bo.User
{
    public abstract class DelegatedUser : HSMSUser
    {
        private HSMSUser hsmsUser;

        /// <summary>
        /// Constructs a new DelegatedUser object.
        /// </summary>
        public DelegatedUser()
        {
        }

        /// <summary>
        /// Constructs a new DelegatedUser object.
        /// </summary>
        /// <param name="hsmsUser"></param>
        public DelegatedUser(HSMSUser hsmsUser)
        {
            this.hsmsUser = hsmsUser;
        }

        protected HSMSUser HsmsUser
        {
            get { return hsmsUser; }
            set { hsmsUser = value; }
        }
    }
}