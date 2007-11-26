using Iesi.Collections.Generic;

namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represent a pupil in school.
    /// </summary>
    public class HSMSPupil : HSMSUser
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

        protected HSMSUser HsmsUser
        {
            get { return hsmsUser; }
            set { hsmsUser = value; }
        }


        public new void AddRole(HSMSGroup group)
        {
            hsmsUser.AddRole(group);
        }

        public new bool HasRole(HSMSGroup group)
        {
            return hsmsUser.HasRole(group);
        }

        public new int Id
        {
            get { return hsmsUser.Id; }
            set { hsmsUser.Id = value; }
        }

        public new string LoginName
        {
            get { return hsmsUser.LoginName; }
            set { hsmsUser.LoginName = value; }
        }

        public new string Password
        {
            get { return hsmsUser.Password; }
            set { hsmsUser.Password = value; }
        }

        public new string Email
        {
            get { return hsmsUser.Email; }
            set { hsmsUser.Email = value; }
        }

        //public new ICollection<HSMSGroup> Roles
        //{
        //    get { return hsmsUser.Roles; }
        //    set { hsmsUser.Roles = value; }
        //}

        public new ISet<HSMSGroup> Roles
        {
            get { return hsmsUser.Roles; }
            set { hsmsUser.Roles = value; }
        }

        public new string LastName
        {
            get { return hsmsUser.LastName; }
            set { hsmsUser.LastName = value; }
        }

        public new string MidName
        {
            get { return hsmsUser.MidName; }
            set { hsmsUser.MidName = value; }
        }

        public new string FirstName
        {
            get { return hsmsUser.FirstName; }
            set { hsmsUser.FirstName = value; }
        }

        public new int DobDay
        {
            get { return hsmsUser.DobDay; }
            set { hsmsUser.DobDay = value; }
        }

        public new int DobMonth
        {
            get { return hsmsUser.DobMonth; }
            set { hsmsUser.DobMonth = value; }
        }

        public new int DobYear
        {
            get { return hsmsUser.DobYear; }
            set { hsmsUser.DobYear = value; }
        }
    }
}