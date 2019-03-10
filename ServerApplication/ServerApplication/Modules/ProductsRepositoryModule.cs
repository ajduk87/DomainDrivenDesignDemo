using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Repositories.Implementations.Products;
using ServerApplication.Repositories.Interfaces.Products;

namespace ServerApplication.Modules
{
    public class ProductsRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ProductAppleRepository>().As<IProductAppleRepository>();
            objContainer.RegisterType<ProductBananaRepository>().As<IProductBananaRepository>();
            objContainer.RegisterType<ProductBlueberryRepository>().As<IProductBlueberryRepository>();
            objContainer.RegisterType<ProductCabbageRepository>().As<IProductCabbageRepository>();
            objContainer.RegisterType<ProductCherryRepository>().As<IProductCherryRepository>();
            objContainer.RegisterType<ProductGrapeRepository>().As<IProductGrapeRepository>();
            objContainer.RegisterType<ProductMandarinRepository>().As<IProductMandarinRepository>();
            objContainer.RegisterType<ProductMangoRepository>().As<IProductMangoRepository>();
            objContainer.RegisterType<ProductOrangeRepository>().As<IProductOrangeRepository>();
            objContainer.RegisterType<ProductPearRepository>().As<IProductPearRepository>();
            objContainer.RegisterType<ProductPlumRepository>().As<IProductPlumRepository>();
            objContainer.RegisterType<ProductRaspberryRepository>().As<IProductRaspberryRepository>();
            objContainer.RegisterType<ProductStrawberryRepository>().As<IProductStrawberryRepository>();
            objContainer.RegisterType<ProductTomatoRepository>().As<IProductTomatoRepository>();
            objContainer.RegisterType<ProductWaterMelonRepository>().As<IProductWaterMelonRepository>();
            base.Load(objContainer);
        }
    }
}
