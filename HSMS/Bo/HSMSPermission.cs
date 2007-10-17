namespace HSMS.Bo
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
    }
}
