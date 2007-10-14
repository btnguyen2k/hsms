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

        /// <summary>
        /// Constructs a new HSMSUser object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public HSMSUser(object id, string loginName, string password, string email)
        {
            this.id = id;
            this.loginName = loginName;
            this.password = password;
            this.email = email;
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
