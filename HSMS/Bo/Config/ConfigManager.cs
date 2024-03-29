using System;
using HSMS.Db;
using NHibernate;

namespace HSMS.Bo.Config
{
    public class ConfigManager
    {
        public const string CONFIG_NAME_SCHOOL_NAME = "school_name";
        public const string CONFIG_NAME_SCHOOL_YEAR = "school_year";

        private static readonly Type ENTITY_HSMSCONFIG = typeof (HSMSConfig);

        public static HSMSConfig GetConfig(string name)
        {
            if (name == null || name.Trim().Length == 0) return null;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                return (HSMSConfig) session.Get(ENTITY_HSMSCONFIG, name.Trim());
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }

        public static string GetSchoolName()
        {
            HSMSConfig config = GetConfig(CONFIG_NAME_SCHOOL_NAME);
            return config != null ? config.Value.Trim() : "";
        }

        public static int GetSchoolYear()
        {
            HSMSConfig config = GetConfig(CONFIG_NAME_SCHOOL_YEAR);
            return config != null ? config.ValueAsInt : 0;
        }
    }
}