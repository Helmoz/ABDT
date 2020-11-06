using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MoreLinq.Extensions;
using ProductsApp.Core.Entities;
using ProductsApp.Core.Entities.Enums;

namespace ProductsApp.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IEnumerable<int> GroupByDate(this IQueryable<UserSession> query, StatisticType group)
        {
            return group switch
            {
                StatisticType.Day => query.ToList().GroupBy(x => x.VisitDateTime.Date, Projection),
                StatisticType.Month => query.ToList().GroupBy(x => new { x.VisitDateTime.Month, x.VisitDateTime.Year }, Projection),
                StatisticType.Year => query.ToList().GroupBy(x => x.VisitDateTime.Year, Projection),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static Func<dynamic, IEnumerable<UserSession>, int> Projection { get; } = (_, sessions) =>
            sessions.GroupBy(x=>x.UserId).Select(x => x.First()).Count();
    }
}