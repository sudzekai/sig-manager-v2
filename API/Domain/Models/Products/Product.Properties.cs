using Domain.ValueObjects.Products;

namespace Domain.Models.Products
{
    public partial class Product
    {
        public ProductId Id
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = ProductId.Default;

        public Name Name
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = Name.Default;

        public void ChangeName(string value)
               => Name = Name.FromValue(value);

        public void ChangeName(Name value)
            => Name = value;

        public Price Price
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = Price.Default;

        public DateTime CreatedAt
        {
            get;
            private set
            {
                if (field == value)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = default;
    }
}
