using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HSMS.Bo.Subject
{
    public class HSMSSubjectCat
    {
        private string id;
        private string name;
        private string description;
        private int headUserId;

        /// <summary>
        /// Constructs a new HSMSSubjectCat object.
        /// </summary>
        public HSMSSubjectCat()
        {            
        }

        /// <summary>
        /// Constructs a new HSMSSubjectCat object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public HSMSSubjectCat(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Constructs a new HSMSSubjectCat object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="headUserId"></param>
        public HSMSSubjectCat(string id, string name, string description, int headUserId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.headUserId = headUserId;
        }


        public virtual string Id
        {
            get { return id; }
            set { id = value; }
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

        public virtual int HeadUserId
        {
            get { return headUserId; }
            set { headUserId = value; }
        }
    }
}
