using System;
using System.Linq.Expressions;
using Reinforced.Tecture.Aspects.Orm.PrimaryKey;

namespace ProductsApp.Core.Entities
{
    public class Product : BaseEntity, IPrimaryKey<long>
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        
        public Expression<Func<long>> PrimaryKey
        {
            get { return () => Id; }
        }
    }
}