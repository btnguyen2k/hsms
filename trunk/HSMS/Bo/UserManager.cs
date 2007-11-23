using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using HSMS.Db;
using NHibernate;

namespace HSMS.Bo
{
    public class UserManager
    {
        public const string TABLE_USER = "HSMSUser";

        public static HSMSGroup getGroup(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                HSMSGroup group = (HSMSGroup) session.Get(typeof (HSMSGroup), id);
                return null;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

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

            IDbConnection conn = DbUtils.GetDbConnection();
            try
            {
                string sql = "INSERT INTO " + TABLE_USER +
                             " (uloginname, upassword, uemail) VALUES (@loginName, @password, @email)";
                IDbCommand command = DbUtils.CreateDbCommand(conn, sql);
                IDbDataParameter param = DbUtils.CreateDbParameter("@loginName", loginName.Trim().ToLower());
                command.Parameters.Add(param);
                param = DbUtils.CreateDbParameter("@password", Utils.Md5(rawPassword.Trim()));
                command.Parameters.Add(param);
                param = DbUtils.CreateDbParameter("@email", email.Trim());
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
            IDbConnection conn = DbUtils.GetDbConnection();
            IDataReader dr = null;
            try
            {
                string sql = "SELECT * FROM " + TABLE_USER + " WHERE uid = @userId";
                IDbCommand command = DbUtils.CreateDbCommand(conn, sql);
                IDbDataParameter param = DbUtils.CreateDbParameter("@userId", userId);
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
            IDbConnection conn = DbUtils.GetDbConnection();
            IDataReader dr = null;
            try
            {
                string sql = "SELECT * FROM " + TABLE_USER + " WHERE uloginname = @loginName";
                IDbCommand command = DbUtils.CreateDbCommand(conn, sql);
                IDbDataParameter param = DbUtils.CreateDbParameter("@loginName", loginName.Trim().ToLower());
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