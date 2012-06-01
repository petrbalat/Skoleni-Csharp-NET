using System;
using System.Linq;
using System.Linq.Expressions;
using TestLanguage.Hibernate.Entity;

namespace TestLanguage.Hibernate
{
    [Obsolete]
    public static class NHibernateHelper<T> where T : IStorno
    {
        private readonly static Expression<Func<T, bool>> sql = arg => arg.DatumStornovani == null;

        public static IQueryable<T> BezStornovanych<T>(this IQueryable<T> queryable)
        {
            return queryable.Where(queryable, sql);
        }
    }
}