using ProductsApp.Core.Channels;
using ProductsApp.Core.Entities;
using Reinforced.Tecture.Aspects.Orm.Commands.Add;
using Reinforced.Tecture.Aspects.Orm.Commands.Delete;
using Reinforced.Tecture.Aspects.Orm.Commands.Update;
using Reinforced.Tecture.Aspects.Orm.Toolings;
using Reinforced.Tecture.Services;

namespace ProductsApp.Core.Services
{
    public class Products : TectureService<Adds<Product>, Updates<Product>, Deletes<Product>>
    {
        private Products() { }

        public void Add(Product product)
        {
            To<Db>().Add(product);
        }

        public void Update(Product product)
        {
            To<Db>().Update(product);
        }

        public void Delete(Product product)
        {
            To<Db>().Delete(product);
        }
    }
}