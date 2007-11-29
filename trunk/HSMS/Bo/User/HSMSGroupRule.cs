namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represents a Group-Permission mapping.
    /// </summary>
    public class HSMSGroupRule
    {
        private HSMSGroup group;
        private HSMSPermission permission;
        private bool isGlobal;

        /// <summary>
        /// Constructs a new HSMSGroupRule object.
        /// </summary>
        public HSMSGroupRule()
        {
        }

        /// <summary>
        /// Constructs a new HSMSGroupRule object.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="permission"></param>
        /// <param name="isGlobal"></param>
        public HSMSGroupRule(HSMSGroup group, HSMSPermission permission, bool isGlobal)
        {
            this.group = group;
            this.permission = permission;
            this.isGlobal = isGlobal;
        }

        public virtual HSMSGroup Group
        {
            get { return group; }
            set { group = value; }
        }

        public virtual HSMSPermission Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public virtual bool IsGlobal
        {
            get { return isGlobal; }
            set { isGlobal = value; }
        }

        public virtual int Global
        {
            get { return isGlobal ? 1 : 0; }
            set { isGlobal = value != 0; }
        }

        public override bool Equals(object o)
        {
            HSMSGroupRule gr = o as HSMSGroupRule;
            if (gr == null) return false;
            return group.Equals(gr.group) && permission.Equals(gr.permission);
        }

        public override int GetHashCode()
        {
            return group.GetHashCode() ^ permission.GetHashCode();
        }
    }
}