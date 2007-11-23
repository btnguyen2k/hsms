using System.Collections;
using System.Data;
using NHibernate.Connection;
using NHibernate.Driver;

namespace HSMS.Db
{
    public class NHibernateConnectionProvider : IConnectionProvider
    {
        public void Configure(IDictionary settings)
        {
            //empty
        }

        public void CloseConnection(IDbConnection conn)
        {
            conn.Close();
        }

        public IDbConnection GetConnection()
        {
            return DbUtils.GetNHibernateDbConnection();
        }

        public IDriver Driver
        {
            get { return DbUtils.NHIBERNATE_DRIVER; }
        }

        public void Dispose()
        {
            //empty
        }
    }
}