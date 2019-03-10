using Autofac;
using ServerApplication.FactoryFolder;
using ServerApplication.Modules;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.RepositoryFactoryFolder
{
    public static class RepositoryFactory
    {
        private static ContainerBuilder objContainer;
        private static Autofac.IContainer container;

        public static void Register()
        {
            objContainer = new ContainerBuilder();

            //Registering Modules
            objContainer.RegisterModule<StoragesRepositoryModule>();
            objContainer.RegisterModule<ProductsRepositoryModule>();
            objContainer.RegisterModule<StorageItemsRepositoryModule>();

            container = objContainer.Build();
        }

        public static IRepository Create(EntityTypes entityType)
        {
            switch (entityType)
            {
                case EntityTypes.ProductApple: { return container.Resolve<IProductAppleRepository>(); }
                case EntityTypes.ProductBanana: { return container.Resolve<IProductBananaRepository>(); }
                case EntityTypes.ProductBlueberry: { return container.Resolve<IProductBlueberryRepository>(); }
                case EntityTypes.ProductCabbage: { return container.Resolve<IProductCabbageRepository>(); }
                case EntityTypes.ProductCherry: { return container.Resolve<IProductCherryRepository>(); }
                case EntityTypes.ProductGrape: { return container.Resolve<IProductGrapeRepository>(); }
                case EntityTypes.ProductMandarin: { return container.Resolve<IProductMandarinRepository>(); }
                case EntityTypes.ProductMango: { return container.Resolve<IProductMangoRepository>(); }
                case EntityTypes.ProductOrange: { return container.Resolve<IProductOrangeRepository>(); }
                case EntityTypes.ProductPear: { return container.Resolve<IProductPearRepository>(); }
                case EntityTypes.ProductPlum: { return container.Resolve<IProductPlumRepository>(); }
                case EntityTypes.ProductRaspberry: { return container.Resolve<IProductRaspberryRepository>(); }
                case EntityTypes.ProductStrawberry: { return container.Resolve<IProductStrawberryRepository>(); }
                case EntityTypes.ProductTomato: { return container.Resolve<IProductTomatoRepository>(); }
                case EntityTypes.ProductWaterMelon: { return container.Resolve<IProductWaterMelonRepository>(); }

                case EntityTypes.Storage: { return container.Resolve<IStorageRepository>(); }
                case EntityTypes.StorageItem: { return container.Resolve<IStorageItemRepository>(); }

                default: { return container.Resolve<IProductAppleRepository>(); }
            }
        }
    }
}
