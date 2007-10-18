using System.Collections.Generic;

namespace HSMS.Bo
{
    /// <summary>
    /// This class represents a user account within the system.
    /// </summary>
    public class HSMSUser : IHSMSUser
    {
        private object id;
        private string loginName;
        private string password;
        private string email;
        private ICollection<HSMSGroup> roles;
        private string lastName;
        private string midName;
        private string firstName;
        private int dobDay, dobMonth, dobYear;

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

        public void AddRole(HSMSGroup group)
        {
            lock (this)
            {
                if (roles == null)
                {
                    roles = new List<HSMSGroup>();
                }

                if (!roles.Contains(group))
                {
                    roles.Add(group);
                }
            }
        }

        public bool HasRole(HSMSGroup group)
        {
            return roles != null && roles.Contains(group);
        }

        public void RemoveRole(HSMSGroup group)
        {
            lock ( this )
            {
                if ( roles != null && group != null )
                {
                    roles.Remove(group);
                }
            }
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

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MidName
        {
            get { return midName; }
            set { midName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int DobDay
        {
            get { return dobDay; }
            set { dobDay = value; }
        }

        public int DobMonth
        {
            get { return dobMonth; }
            set { dobMonth = value; }
        }

        public int DobYear
        {
            get { return dobYear; }
            set { dobYear = value; }
        }
    }
}