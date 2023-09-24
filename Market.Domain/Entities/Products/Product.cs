using Market.Domain.Commons;

namespace Market.Domain.Entities.Products
{
    public class Product: Auditable<long>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
