using System.Collections.Generic;

namespace HSMS.Bo
{
    /// <summary>
    /// This class represents a user account within the system.
    /// </summary>
    public class HSMSUser
    {
        private object id;
        private string loginName;
        private string password;
        private string email;
        private ICollection<HSMSGroup> roles;

        /// <summary>
        /// Constructs a new HSMSUser object.
        /// </summary>
        public HSMSUser()
        {
        }


        public object Id
        {
            get { return id; }
            set { id = value; }
        }

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public ICollection<HSMSGroup> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
