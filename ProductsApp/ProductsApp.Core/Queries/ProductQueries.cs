using System.Linq;
using BlazorPagination;
using ProductsApp.Core.Entities;
using Reinforced.Tecture.Aspects.Orm.Queries;

namespace ProductsApp.Core.Queries
{
    public static class ProductQueries
    {
        public static PagedResult<ProductDto> ProductDtosPaged(this IQueryFor<Product> query, int page, int pageSize)
        {
            return query.All.Select(Projections.ProductProjection).ToPagedResult(page, pageSize);
        }
    }
}