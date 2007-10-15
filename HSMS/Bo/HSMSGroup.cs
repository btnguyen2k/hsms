namespace HSMS.Bo
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

        public object Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsGod
        {
            get { return isGod;  }
            set { isGod = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }
    }
}
