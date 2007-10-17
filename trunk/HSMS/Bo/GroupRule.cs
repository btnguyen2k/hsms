namespace HSMS.Bo
{
    /// <summary>
    /// This class represents a Group-Permission mapping.
    /// </summary>
    public class GroupRule
    {
        private HSMSGroup group;
        private HSMSPermission permission;
        private bool isGlobal;

        /// <summary>
        /// Constructs a new HSMSGroupRule object.
        /// </summary>
        public GroupRule()
        {
        }

        /// <summary>
        /// Constructs a new HSMSGroupRule object.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="permission"></param>
        /// <param name="isGlobal"></param>
        public GroupRule(HSMSGroup group, HSMSPermission permission, bool isGlobal)
        {
            this.group = group;
            this.permission = permission;
            this.isGlobal = isGlobal;
        }

        public HSMSGroup Group
        {
            get { return group; }
            set { group = value; }
        }

        public HSMSPermission Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public bool IsGlobal
        {
            get { return isGlobal; }
            set { isGlobal = value; }
        }
    }
}
