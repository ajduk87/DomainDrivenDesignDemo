using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductBlueberry : Entity
    {
        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }

        public ProductBlueberry(NameOfProduct nameOfProduct, UnitCost unitCost)
        {
            this.NameOfProduct = nameOfProduct;
            this.Cost = unitCost;
        }
    }
}
