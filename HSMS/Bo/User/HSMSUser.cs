using Iesi.Collections.Generic;

namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represents a user account within the system.
    /// </summary>
    public class HSMSUser //: IHSMSUser
    {
        private object id;
        private string loginName;
        private string password;
        private string email;
        //private ICollection<HSMSGroup> roles;
        private ISet<HSMSGroup> roles;
        private string lastName;
        private string midName;
        private string firstName;
        private int dobDay, dobMonth, dobYear;
        private int creationTimestamp;

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

        /// <summary>
        /// Authenticates a password.
        /// </summary>
        /// <param name="rawPassword"></param>
        /// <returns></returns>
        public virtual bool Authenticate(string rawPassword)
        {
            if (rawPassword == null || rawPassword.Trim().Length == 0)
            {
                return false;
            }
            return Utils.Md5(rawPassword.Trim()) == password;
        }

        public virtual void AddRole(HSMSGroup group)
        {
            lock (this)
            {
                if (roles == null)
                {
                    //roles = new List<HSMSGroup>();
                    roles = new HashedSet<HSMSGroup>();
                }

                if (group != null && !roles.Contains(group))
                {
                    roles.Add(group);
                }
            }
        }

        public virtual void SetRole(HSMSGroup group)
        {
            lock (this)
            {
                roles = new HashedSet<HSMSGroup>();
                if (group != null)
                {
                    roles.Add(group);
                }
            }
        }

        public virtual bool HasRole(HSMSGroup group)
        {
            return roles != null && roles.Contains(group);
        }

        public virtual void RemoveRole(HSMSGroup group)
        {
            lock (this)
            {
                if (roles != null && group != null)
                {
                    roles.Remove(group);
                }
            }
        }

        public virtual int Id
        {
            get { return id != null ? (int) id : 0; }
            set { id = value; }
        }

        public virtual string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public virtual string Password
        {
            get { return password; }
            set { password = value; }
        }

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        //public ICollection<HSMSGroup> Roles
        //{
        //    get { return roles; }
        //    set { roles = value; }
        //}

        public virtual ISet<HSMSGroup> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public virtual string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public virtual string MidName
        {
            get { return midName; }
            set { midName = value; }
        }

        public virtual string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public virtual string FullName
        {
            get
            {
                string fullname = "";
                if (lastName != null && lastName.Length > 0) fullname += lastName.Trim();
                if (midName != null && midName.Length > 0) fullname += " " + midName.Trim();
                if (firstName != null && firstName.Length > 0) fullname += " " + firstName.Trim();
                return fullname.Trim();
            }
            set
            {
                if (value == null || value.Trim().Length == 0)
                {
                    firstName = null;
                    midName = null;
                    lastName = null;
                    return;
                }
                else
                {
                    string[] tokens = value.Trim().Split(' ');
                    if (tokens.Length == 1)
                    {
                        firstName = tokens[0].Trim();
                    }
                    else if (tokens.Length == 2)
                    {
                        lastName = tokens[0].Trim();
                        firstName = tokens[1].Trim();
                    }
                    else
                    {
                        //tokens.length >= 3
                        lastName = tokens[0].Trim();
                        midName = tokens[1].Trim();
                        for (int i = 2; i < tokens.Length - 1; i++)
                        {
                            midName += " " + tokens[i].Trim();
                        }
                        lastName = tokens[tokens.Length - 1];
                    }
                }
            }
        }

        public virtual int DobDay
        {
            get { return dobDay; }
            set { dobDay = value; }
        }

        public virtual int DobMonth
        {
            get { return dobMonth; }
            set { dobMonth = value; }
        }

        public virtual int DobYear
        {
            get { return dobYear; }
            set { dobYear = value; }
        }

        public virtual int CreationTimestamp
        {
            get { return creationTimestamp; }
            set { creationTimestamp = value; }
        }
    }
}