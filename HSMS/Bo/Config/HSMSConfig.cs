using System;

namespace HSMS.Bo.Config
{
    public class HSMSConfig
    {
        private string name;
        private string value;

        /// <summary>
        /// Constructs a new HSMSConfig object.
        /// </summary>
        public HSMSConfig()
        {
        }

        /// <summary>
        /// Constructs a new HSMSConfig
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public HSMSConfig(string name, string value)
        {
            this.name = name;
            this.value = value;
        }


        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public virtual bool ValueAsBool
        {
            get
            {
                bool result;
                return Boolean.TryParse(value, out result) ? result : false;
            }
        }

        public virtual int ValueAsInt
        {
            get
            {
                int result;
                return Int32.TryParse(value, out result) ? result : 0;
            }
        }

        public virtual double ValueAsDouble
        {
            get
            {
                double result;
                return Double.TryParse(value, out result) ? result : 0.0;
            }
        }
    }
}