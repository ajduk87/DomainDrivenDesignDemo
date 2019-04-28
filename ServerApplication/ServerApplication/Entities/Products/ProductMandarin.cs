using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductMandarin : Entity
    {
        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }

        public ProductMandarin(NameOfProduct nameOfProduct, UnitCost unitCost)
        {
            this.NameOfProduct = nameOfProduct;
            this.Cost = unitCost;
        }
    }
}
