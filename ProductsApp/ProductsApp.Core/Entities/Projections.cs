using System;
using System.Linq.Expressions;

namespace ProductsApp.Core.Entities
{
    public static class Projections
    {
        public static Expression<Func<Product, ProductDto>> ProductProjection = product => new ProductDto
        {
            Id = product.Id,
            Category = product.Category,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }
}