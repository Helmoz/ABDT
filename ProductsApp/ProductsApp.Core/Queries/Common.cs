using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductsApp.Core.Entities;
using Reinforced.Tecture.Aspects.Orm.Queries;

namespace ProductsApp.Core.Queries
{
    public static class CommonQueries
    {
        public static async Task<TOut> ById<TIn, TOut>(this IQueryFor<TIn> query, long id, Expression<Func<TIn, TOut>> projection) where TIn : BaseEntity
        {
            return await query.All.Where(x => x.Id == id).Select(projection).FirstOrDefaultAsync();
        }
        
        public static async Task<TIn> ById<TIn>(this IQueryFor<TIn> query, long id) where TIn : BaseEntity
        {
            return await query.All.FirstOrDefaultAsync((x => x.Id == id));
        }
    }
}