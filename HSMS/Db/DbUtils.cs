using System;
using System.Data.Common;
using System.Data.OleDb;

namespace HSMS.Db
{
    public class DbUtils
    {
        private const string CONNECTION_STRING =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={APP_DIR}Resources\\hsms.mdb;User Id=admin;Password=;";

        public static DbConnection getDbConnection()
        {
            string connString = CONNECTION_STRING.Replace("{APP_DIR}", AppDomain.CurrentDomain.BaseDirectory);
            DbConnection conn = new OleDbConnection(connString);
            conn.Open();
            return conn;
        }

        public static DbParameter createDbParameter(string name, object value)
        {
            return new OleDbParameter(name, value);
        }

        public static DbCommand createDbCommand()
        {
            return new OleDbCommand();
        }

        public static DbCommand createDbCommand(DbConnection conn)
        {
            DbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            return cmd;
        }

        public static DbCommand createDbCommand(DbConnection conn, string command)
        {
            DbCommand cmd = new OleDbCommand(command, conn as OleDbConnection);
            return cmd;
        }
    }
}