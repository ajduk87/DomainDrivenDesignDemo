using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductOrange : Entity
    {
        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }

        public ProductOrange(NameOfProduct nameOfProduct, UnitCost unitCost)
        {
            this.NameOfProduct = nameOfProduct;
            this.Cost = unitCost;
        }
    }
}
