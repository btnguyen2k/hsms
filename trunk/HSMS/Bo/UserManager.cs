using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using HSMS.Db;

namespace HSMS.Bo
{
    public class UserManager
    {
        public const string TABLE_USER = "HSMSUser";

        private static void closeDbConnection(IDbConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (SqlException)
                {
                    //       
                }
            }
        }

        private static void closeDataReader(IDataReader dr)
        {
            if (dr != null)
            {
                try
                {
                    dr.Close();
                }
                catch (SqlException)
                {
                    //       
                }
            }
        }

        private static HSMSUser createUserInstance(IDataRecord dr)
        {
            HSMSUser result =
                new HSMSUser(dr["uid"], dr["uloginname"].ToString(), dr["upassword"].ToString(),
                             dr["uemail"].ToString());
            return result;
        }

        public static HSMSUser createUser(string loginName, string rawPassword, string email)
        {
            if (loginName == null || loginName.Trim().Length == 0) return null;
            if (rawPassword == null || rawPassword.Trim().Length == 0) return null;
            if (email == null || email.Trim().Length == 0) return null;

            DbConnection conn = DbUtils.getDbConnection();
            try
            {
                string sql = "INSERT INTO " + TABLE_USER +
                             " (uloginname, upassword, uemail) VALUES (@loginName, @password, @email)";
                DbCommand command = DbUtils.createDbCommand(conn, sql);
                DbParameter param = DbUtils.createDbParameter("@loginName", loginName.Trim().ToLower());
                command.Parameters.Add(param);
                param = DbUtils.createDbParameter("@password", Utils.Md5(rawPassword.Trim()));
                command.Parameters.Add(param);
                param = DbUtils.createDbParameter("@email", email.Trim());
                command.Parameters.Add(param);

                command.ExecuteNonQuery();
                return getUser(loginName);
            }
            finally
            {
                closeDbConnection(conn);
            }
        }

        /// <summary>
        /// Gets a user by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static HSMSUser getUser(int userId)
        {
            DbConnection conn = DbUtils.getDbConnection();
            DbDataReader dr = null;
            try
            {
                string sql = "SELECT * FROM " + TABLE_USER + " WHERE uid = @userId";
                DbCommand command = DbUtils.createDbCommand(conn, sql);
                DbParameter param = DbUtils.createDbParameter("@userId", userId);
                command.Parameters.Add(param);

                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    return createUserInstance(dr);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                closeDataReader(dr);
                closeDbConnection(conn);
            } //end try
        } //end getUser

        /// <summary>
        /// Gets a user by login name.
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static HSMSUser getUser(string loginName)
        {
            if (loginName == null || loginName.Trim().Length == 0) return null;
            DbConnection conn = DbUtils.getDbConnection();
            DbDataReader dr = null;
            try
            {
                string sql = "SELECT * FROM " + TABLE_USER + " WHERE uloginname = @loginName";
                DbCommand command = DbUtils.createDbCommand(conn, sql);
                DbParameter param = DbUtils.createDbParameter("@loginName", loginName.Trim().ToLower());
                command.Parameters.Add(param);

                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    return createUserInstance(dr);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                closeDataReader(dr);
                closeDbConnection(conn);
            } //end try
        } //end getUser
    }
}