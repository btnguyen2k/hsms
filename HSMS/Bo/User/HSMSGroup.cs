namespace HSMS.Bo.User
{
    /// <summary>
    /// This class represents a user group.
    /// </summary>
    public class HSMSGroup
    {
        private object id;
        private string name, description;
        private string prefix, suffix;
        private bool isGod;

        /// <summary>
        /// Constructs a new HSMSGroup object.
        /// </summary>
        public HSMSGroup()
        {
        }

        /// <summary>
        /// Constructs a new HSMSGroup object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public HSMSGroup(object id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Constructs a new HSMSGroup object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        public HSMSGroup(object id, string name, string description, string prefix, string suffix)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.prefix = prefix;
            this.suffix = suffix;
        }

        public virtual int Id
        {
            get { return id != null ? (int) id : 0; }
            set { id = value; }
        }

        public virtual bool IsGod
        {
            get { return isGod; }
            set { isGod = value; }
        }

        public virtual int God
        {
            get { return isGod ? 1 : 0; }
            set { isGod = value != 0; }
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

        public virtual string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        public virtual string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        public override bool Equals(object o)
        {
            HSMSGroup gr = o as HSMSGroup;
            return gr != null ? id == gr.id : false;
        }

        public override int GetHashCode()
        {
            int result = 0;
            if (id != null) result ^= id.GetHashCode();
            if (name != null) result ^= name.GetHashCode();
            result ^= isGod.GetHashCode();
            if (description != null) result ^= description.GetHashCode();
            if (prefix != null) result ^= prefix.GetHashCode();
            if (suffix != null) result ^= suffix.GetHashCode();
            return result;
        }
    }
}