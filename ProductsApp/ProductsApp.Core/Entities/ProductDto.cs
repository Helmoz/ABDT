namespace ProductsApp.Core.Entities
{
    public class ProductDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}