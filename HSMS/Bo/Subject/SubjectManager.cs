using System;
using System.Collections;
using System.Collections.Generic;
using HSMS.Db;
using HSMS.Libs.SimpleObjectCaching;
using NHibernate;

namespace HSMS.Bo.Subject
{
    public class SubjectManager
    {
        private static readonly Type ENTITY_SUBJECT_CAT = typeof (HSMSSubjectCat);

        private static readonly string HQL_SELECT_ALL_SUBJECT_CATS = "FROM " + ENTITY_SUBJECT_CAT + " sc ORDER BY sc.Id";

        private static readonly string CACHE_KEY_ALL_SUBJECT_CATS_AS_LIST = "SUBJECT_CATS_ALL_AS_LIST";

        private static readonly string CACHE_KEY_ALL_SUBJECT_CATS_AS_MAP = "SUBJECT_CATS_ALL_AS_MAP";

        private static void InvalidateCacheSubjectCats()
        {
            lock (typeof (SubjectManager))
            {
                Cache cache = CacheManager.GetDefaultCache();
                cache.Remove(CACHE_KEY_ALL_SUBJECT_CATS_AS_LIST);
                cache.Remove(CACHE_KEY_ALL_SUBJECT_CATS_AS_MAP);
            }
        }

        public static HSMSSubjectCat CreateSubjectCat(string id, string name, string desc)
        {
            return CreateSubjectCat(id, name, desc, 0);
        }

        public static HSMSSubjectCat CreateSubjectCat(string id, string name, string desc, int headUserId)
        {
            HSMSSubjectCat subjectCat = new HSMSSubjectCat(id, name, desc, headUserId);
            return CreateSubjectCat(subjectCat);
        }

        public static HSMSSubjectCat CreateSubjectCat(HSMSSubjectCat subjectCat)
        {
            if (subjectCat == null) return null;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                session.Save(subjectCat);
                return subjectCat;
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
            finally
            {
                InvalidateCacheSubjectCats();
            }
        }

        public static IList<HSMSSubjectCat> GetAllSubjectCats()
        {
            Cache cache = CacheManager.GetDefaultCache();
            IList<HSMSSubjectCat> result = (IList<HSMSSubjectCat>) cache[CACHE_KEY_ALL_SUBJECT_CATS_AS_LIST];
            if (result != null) return result;

            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                result = new List<HSMSSubjectCat>();
                IList queryResult = session.CreateQuery(HQL_SELECT_ALL_SUBJECT_CATS).SetCacheable(true).List();
                if (queryResult != null)
                {
                    foreach (object o in queryResult)
                    {
                        result.Add((HSMSSubjectCat) o);
                    }
                }
                cache[CACHE_KEY_ALL_SUBJECT_CATS_AS_LIST] = result;
                return result;
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }

        public static IDictionary<string, HSMSSubjectCat> GetAllSubjectCatsAsMap()
        {
            Cache cache = CacheManager.GetDefaultCache();
            IDictionary<string, HSMSSubjectCat> result =
                (IDictionary<string, HSMSSubjectCat>) cache[CACHE_KEY_ALL_SUBJECT_CATS_AS_MAP];

            if (result != null) return result;

            result = new Dictionary<string, HSMSSubjectCat>();
            IList<HSMSSubjectCat> subjectCats = GetAllSubjectCats();
            foreach (HSMSSubjectCat subjectCat in subjectCats)
            {
                result[subjectCat.Id] = subjectCat;
            }
            cache[CACHE_KEY_ALL_SUBJECT_CATS_AS_MAP] = result;
            return result;
        }

        public static HSMSSubjectCat GetSubjectCat(string id)
        {
            IDictionary<string, HSMSSubjectCat> subjectCats = GetAllSubjectCatsAsMap();
            return subjectCats[id];
        }
    }
}