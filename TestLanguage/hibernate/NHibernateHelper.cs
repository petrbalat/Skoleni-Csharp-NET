using System.Linq;
using TestLanguage.Hibernate.Entity;

namespace TestLanguage.Hibernate
{
    public static class NHibernateHelper
    {
        public static IQueryable<T> BezStornovanych<T>(this IQueryable<T> queryable) where T : IStorno
        {
            return queryable.Where(arg => arg.DatumStornovani == null);
        }
    }
}