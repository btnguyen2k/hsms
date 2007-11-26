using System;
using System.Collections;
using System.Collections.Generic;
using HSMS.Db;
using NHibernate;

namespace HSMS.Bo.User
{
    public class UserManager
    {
        private static IDictionary<object, HSMSGroup> CACHE_GROUP_AS_MAP = null;

        private static IList<HSMSGroup> CACHE_GROUP_AS_LIST = null;

        private static void ClearGroupCache()
        {
            CACHE_GROUP_AS_MAP = null;
            CACHE_GROUP_AS_LIST = null;
        }

        private static IDictionary<object, HSMSGroup> GetAllUserGroupsAsMap()
        {
            if (CACHE_GROUP_AS_MAP == null)
            {
                CACHE_GROUP_AS_MAP = new Dictionary<object, HSMSGroup>();
                IList<HSMSGroup> groupsAsList = GetAllUserGroups();
                foreach (HSMSGroup group in groupsAsList)
                {
                    CACHE_GROUP_AS_MAP.Add(group.Id, group);
                }
            }
            return CACHE_GROUP_AS_MAP;
        }

        private static readonly Type ENTITY_HSMSGROUP = typeof (HSMSGroup);
        private static readonly string HQL_SELECT_ALL_GROUPS = "FROM " + ENTITY_HSMSGROUP + " ORDER BY Name";

        /// <summary>
        /// Gets all available user groups as a list.
        /// </summary>
        /// <returns></returns>
        public static IList<HSMSGroup> GetAllUserGroups()
        {
            if (CACHE_GROUP_AS_LIST == null)
            {
                CACHE_GROUP_AS_LIST = new List<HSMSGroup>();
                ISession session = NHibernateHelper.GetCurrentSession();
                try
                {
                    IList result = session.CreateQuery(HQL_SELECT_ALL_GROUPS).SetCacheable(true).List();
                    foreach (object o in result)
                    {
                        CACHE_GROUP_AS_LIST.Add((HSMSGroup) o);
                    }
                }
                catch (HibernateException)
                {
                    NHibernateHelper.MarkError();
                    throw;
                }
            }

            //make a copy so that our data will not be modified unintentionally!
            IList<HSMSGroup> copy = new List<HSMSGroup>();
            foreach (HSMSGroup group in CACHE_GROUP_AS_LIST)
            {
                copy.Add(group);
            }
            return copy;
        }

        /// <summary>
        /// Gets a user group by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static HSMSGroup GetUserGroup(int id)
        {
            IDictionary<object, HSMSGroup> groupsAsMap = GetAllUserGroupsAsMap();
            return groupsAsMap[id];
        }

        /// <summary>
        /// Deletes a user group by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUserGroup(int id)
        {
            HSMSGroup group = GetUserGroup(id);
            if (group == null) return false;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                session.Delete(group);
                ClearGroupCache();
                return true;
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }


        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HSMSGroup CreateUserGroup(string name)
        {
            return CreateUserGroup(name, false);
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static HSMSGroup CreateUserGroup(string name, string desc)
        {
            return CreateUserGroup(name, false, desc);
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isGod"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static HSMSGroup CreateUserGroup(string name, bool isGod, string desc)
        {
            return CreateUserGroup(name, isGod, desc, null, null);
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isGod"></param>
        /// <returns></returns>
        public static HSMSGroup CreateUserGroup(string name, bool isGod)
        {
            return CreateUserGroup(name, isGod, null, null, null);
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isGod"></param>
        /// <param name="desc"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static HSMSGroup CreateUserGroup(string name, bool isGod, string desc, string prefix, string suffix)
        {
            HSMSGroup group = new HSMSGroup();
            group.Name = name;
            group.IsGod = isGod;
            group.Description = desc;
            group.Prefix = prefix;
            group.Suffix = suffix;
            return CreateUserGroup(group);
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static HSMSGroup CreateUserGroup(HSMSGroup group)
        {
            if (group == null) return null;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                group = (HSMSGroup) session.Save(group);
                ClearGroupCache();
                return GetUserGroup(group.Id);
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }

        private static readonly Type ENTITY_HSMSUSER = typeof (HSMSUser);

        /// <summary>
        /// Gets a user account by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static HSMSUser GetUser(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                return (HSMSUser) session.Get(ENTITY_HSMSUSER, id);
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }

        /// <summary>
        /// Deletes a user account by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUser(int id)
        {
            HSMSUser user = GetUser(id);
            if (user == null) return false;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                session.Delete(user);
                return true;
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }



        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static HSMSUser CreateUser(HSMSUser user)
        {
            if (user == null) return null;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                user = (HSMSUser) session.Save(user);
                return GetUser(user.Id);
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }
    }
}