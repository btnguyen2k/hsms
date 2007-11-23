using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace HSMS.Db
{
    public sealed class NHibernateHelper : IHttpModule
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;

        static NHibernateHelper()
        {
            //string configFile = AppDomain.CurrentDomain.BaseDirectory + "Resources\\nhibernate\\hibernate.cfg.xml";
            //sessionFactory = new Configuration().Configure(configFile).BuildSessionFactory();
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        /// <summary>
        /// Gets the current Hibernate Session
        /// </summary>
        /// <returns></returns>
        public static ISession GetCurrentSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        /// <summary>
        /// Closes the current Hibernate Session
        /// </summary>
        public static void CloseSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                // No current session
                return;
            }
            try
            {
                try
                {
                    currentSession.Flush();
                }
                finally
                {
                    currentSession.Close();
                }
            }
            finally
            {
                context.Items.Remove(CurrentSessionKey);
            }
        }

        /// <summary>
        /// Disposes Hibernate's session factory instance.
        /// </summary>
        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }

        /* IHttpModule's methods */

        public void Init(HttpApplication context)
        {
            context.EndRequest += Context_EndRequest;
        }

        public void Dispose()
        {
            //empty
        }

        /* IHttpModule's methods */

        private static void Context_EndRequest(object sender, EventArgs e)
        {
            CloseSession();
        }
    }
}