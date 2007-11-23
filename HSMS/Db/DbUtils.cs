using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using NHibernate.Driver;
using NHibernate.JetDriver;

namespace HSMS.Db
{
    public class DbUtils
    {
        private const string CONNECTION_STRING =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={APP_DIR}Resources\\hsms.mdb;User Id=admin;Password=;";

        public static readonly IDriver NHIBERNATE_DRIVER = new JetDriver();

        public static IDbConnection GetNHibernateDbConnection()
        {
            if (ConnectionString == null)
            {
                ConnectionString = CONNECTION_STRING.Replace("{APP_DIR}", AppDomain.CurrentDomain.BaseDirectory);
            }
            IDbConnection conn = new JetDbConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        private static string ConnectionString = null;
        public static IDbConnection GetDbConnection()
        {
            if ( ConnectionString == null )
            {
                ConnectionString = CONNECTION_STRING.Replace("{APP_DIR}", AppDomain.CurrentDomain.BaseDirectory);
            }
            IDbConnection conn = new OleDbConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static IDbDataParameter CreateDbParameter(string name, object value)
        {
            return new OleDbParameter(name, value);
        }

        public static IDbCommand CreateDbCommand()
        {
            return new OleDbCommand();
        }

        public static IDbCommand CreateDbCommand(IDbConnection conn)
        {
            IDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            return cmd;
        }

        public static IDbCommand CreateDbCommand(IDbConnection conn, string command)
        {
            IDbCommand cmd = new OleDbCommand(command, conn as OleDbConnection);
            return cmd;
        }
    }
}