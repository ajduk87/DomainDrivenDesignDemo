using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductStrawberry : Entity
    {
        public ProductStrawberry(NameOfProduct NameOfProduct, UnitCost Cost)
        {
            this.NameOfProduct = NameOfProduct;
            this.Cost = Cost;
        }

        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }
    }
}
