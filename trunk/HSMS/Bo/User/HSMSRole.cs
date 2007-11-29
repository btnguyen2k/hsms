namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represents a User-Group mapping.
    /// </summary>
    public class HSMSRole
    {
        private readonly HSMSUser user;
        private readonly HSMSGroup group;

        /// <summary>
        /// Constructs a new HSMSRole object.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="group"></param>
        public HSMSRole(HSMSUser user, HSMSGroup group)
        {
            this.user = user;
            this.group = group;
        }

        public HSMSUser User
        {
            get { return user; }
        }

        public HSMSGroup Group
        {
            get { return group; }
        }
    }
}