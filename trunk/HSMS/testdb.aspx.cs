using System;
using System.Collections;
using System.Web.UI;
using HSMS.Bo;
using HSMS.Db;
using NHibernate;

namespace HSMS
{
    public partial class testdb : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DbConnection conn = DbUtils.GetDbConnection();
            //labelTestDb.Text = conn.ToString();
            //conn.Close();

            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                HSMSGroup group = (HSMSGroup)session.Load(typeof (HSMSGroup), 1);
                labelTestDb.Text = group != null ? group.ToString() : "NULL";
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }

            //labelTestDb.Text = NHibernateHelper.GetCurrentSession().ToString();
            //HSMSGroup group = UserManager.getGroup(1);
            //labelTestDb.Text = group != null ? group.ToString() : null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int userId = 0;
            if (Int32.TryParse(inputUserId.Text, out userId))
            {
                HSMSUser user = UserManager.getUser(userId);
                labelTestGetUserId.Text = user != null ? user.ToString() : "NULL";
            }
            else
            {
                labelTestGetUserId.Text = "Invalid number: " + inputUserId.Text;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HSMSUser user = UserManager.getUser(inputLoginName.Text);
            labelTestGetUserLoginName.Text = user != null ? user.ToString() : "NULL";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string loginName = inputCreateLoginName.Text.Trim().ToLower();
            string password = inputCreatePassword.Text.Trim();
            string email = inputCreateEmail.Text.Trim();
            if (loginName.Length == 0)
            {
                labelTestCreateUser.Text = "Error: Login Name is empty!";
                return;
            }
            if (password.Length == 0)
            {
                labelTestCreateUser.Text = "Error: Password is empty!";
                return;
            }
            if (email.Length == 0)
            {
                labelTestCreateUser.Text = "Error: email is empty!";
                return;
            }

            HSMSUser user = UserManager.createUser(loginName, password, email);
            labelTestCreateUser.Text = user != null ? ("Created user with id: " + user.Id) : "NULL";
        }
    }
}