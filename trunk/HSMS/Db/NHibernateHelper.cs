using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace HSMS.Db
{
    public sealed class NHibernateHelper : IHttpModule
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory SessionFactory;
        private static bool HasError = false;

        static NHibernateHelper()
        {
            //string configFile = AppDomain.CurrentDomain.BaseDirectory + "Resources\\nhibernate\\hibernate.cfg.xml";
            //SessionFactory = new Configuration().Configure(configFile).BuildSessionFactory();
            SessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        /// <summary>
        /// Indicates that there was an error occured
        /// </summary>
        public static void MarkError()
        {
            HasError = true;
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
                currentSession = SessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
                currentSession.BeginTransaction();
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
                    if (HasError) currentSession.Transaction.Rollback();
                    else currentSession.Transaction.Commit();
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
            if (SessionFactory != null)
            {
                SessionFactory.Close();
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