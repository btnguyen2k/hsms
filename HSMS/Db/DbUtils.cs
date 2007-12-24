using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using NHibernate.Driver;
using NHibernate.JetDriver;

namespace HSMS.Db
{
    public class DbUtils
    {
        private const string CONNECTION_STRING_SQL2005 =
            "Provider=SQLNCLI; Server=.\\SQLExpress; Database=dbname; Trusted_Connection=Yes;";

        //"Provider=SQLNCLI;Server=.\\SQLExpress;AttachDbFilename=F:\database\\hsms.mdf; Database=dbname;Trusted_Connection=Yes;";

        public static OleDbConnection GetSQLDbConnection()
        {
            return new OleDbConnection(CONNECTION_STRING_SQL2005);
        }

        /*
        private const string CONNECTION_STRING =
        //    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={APP_DIR}Resources\\hsms.mdb;User Id=admin;Password=;";
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Workspace\\dotNet\\HSMS\\HSMS\\Resources\\hsms.mdb;User Id=admin;Password=;";
        */

        public static readonly IDriver NHIBERNATE_DRIVER = new JetDriver();

        public static string GetConnectionString()
        {
            if (ConnectionString == null)
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                ConnectionString = ConnectionString.Replace("{APP_DIR}", AppDomain.CurrentDomain.BaseDirectory);
            }
            return ConnectionString;
        }

        public static IDbConnection GetNHibernateDbConnection()
        {
            IDbConnection conn = new JetDbConnection(GetConnectionString());
            conn.Open();
            return conn;
        }

        private static string ConnectionString = null;

        public static IDbConnection GetDbConnection()
        {
            IDbConnection conn = new OleDbConnection(GetConnectionString());
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