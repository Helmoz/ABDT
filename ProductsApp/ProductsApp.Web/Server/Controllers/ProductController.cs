using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Core.Channels;
using ProductsApp.Core.Entities;
using ProductsApp.Core.Queries;
using ProductsApp.Core.Services;
using Reinforced.Tecture;
using Reinforced.Tecture.Aspects.Orm.Queries;

namespace ProductsApp.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ITecture Tecture { get; }

        public ProductController(ITecture tecture)
        {
            Tecture = tecture;
        }

        [HttpGet]
        public IActionResult Get(int page, int pageSize)
        {
            var products = Tecture.From<Db>().Get<Product>().ProductDtosPaged(page, pageSize);
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await Tecture.From<Db>().Get<Product>().ById(id, Projections.ProductProjection);
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Product productModel)
        {
            Tecture.Do<Products>().Add(productModel);
            await Tecture.SaveAsync();
            return Ok(productModel.Id); 
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(ProductDto productDto)
        {
            var product = await Tecture.From<Db>().Get<Product>().ById(productDto.Id);
                
            UpdateProduct(product);
            Tecture.Do<Products>().Update(product);
            await Tecture.SaveAsync();
            return NoContent();
            
            void UpdateProduct(Product productEntity)
            {
                productEntity.Name = productDto.Name;
                productEntity.Price = productDto.Price;
                productEntity.Quantity = productDto.Quantity;
                productEntity.Category = productDto.Category;
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await Tecture.From<Db>().Get<Product>().ById(id);
            Tecture.Do<Products>().Delete(product);
            await Tecture.SaveAsync();
            return NoContent();
        }
    }
}
