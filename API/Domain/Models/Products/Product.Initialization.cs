using Domain.Models.Base;
using Domain.ValueObjects.Products;

namespace Domain.Models.Products
{
    public partial class Product : DomainModelBase
    {
        private Product(Name name, Price pricePerHour)
        {
            Name = name;
            Price = pricePerHour;

            _initialized = true;
        }

        private Product(ProductId id, Name name, Price pricePerHour)
        {
            Id = id;
            Name = name;
            Price = pricePerHour;

            _initialized = true;
        }

        internal static Product Restore(ProductId id, Name name, Price price)
            => new(id, name, price);

        public static Product Create(Name name, Price price)
            => new(name, price);
    }
}
