using System.Collections.Generic;
using System.Linq;
using ProductsApp.Core.Entities;
using ProductsApp.Core.Entities.Enums;
using Reinforced.Tecture.Aspects.Orm.Queries;
using ProductsApp.Core.Extensions;

namespace ProductsApp.Core.Queries
{
    public static class StatisticQueries
    {
        public static IEnumerable<int> GetIntervalStatistic(this IQueryFor<UserSession> query, StatisticType statisticType)
        {
            return query.All.GroupByDate(statisticType).ToList();
        }
    }
}