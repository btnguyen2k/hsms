namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represents a system's permission.
    /// </summary>
    public class HSMSPermission
    {
        private string name;
        private string description;

        /// <summary>
        /// Constructs a new HSMSPermission class.
        /// </summary>
        public HSMSPermission()
        {
        }

        /// <summary>
        /// Constructs a new HSMSPermission class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public HSMSPermission(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public override bool Equals(object o)
        {
            HSMSPermission p = o as HSMSPermission;
            return p != null ? name == p.name : false;
        }

        public override int GetHashCode()
        {
            int result = 0;
            if (name != null) result ^= name.GetHashCode();
            if (description != null) result ^= description.GetHashCode();
            return result;
        }
    }
}
