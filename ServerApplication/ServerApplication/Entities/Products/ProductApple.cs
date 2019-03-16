using ServerApplication.Entities.ValueObjects;
using ServerApplication.Entities;

namespace ServerApplication.Entities.Products
{
    public class ProductApple : Entity
    {
        public ProductApple(NameOfProduct NameOfProduct, UnitCost Cost)
        {
            this.NameOfProduct = NameOfProduct;
            this.Cost = Cost;
        }

        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }
    }
}
