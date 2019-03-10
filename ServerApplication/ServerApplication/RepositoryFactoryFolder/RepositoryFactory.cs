using Autofac;
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

        public static IRepository Create(RepositoryTypes repositoryType)
        {
            switch (repositoryType)
            {
                case RepositoryTypes.ProductApple: { return container.Resolve<IProductAppleRepository>(); }
                case RepositoryTypes.ProductBanana: { return container.Resolve<IProductBananaRepository>(); }
                case RepositoryTypes.ProductBlueberry: { return container.Resolve<IProductBlueberryRepository>(); }
                case RepositoryTypes.ProductCabbage: { return container.Resolve<IProductCabbageRepository>(); }
                case RepositoryTypes.ProductCherry: { return container.Resolve<IProductCherryRepository>(); }
                case RepositoryTypes.ProductGrape: { return container.Resolve<IProductGrapeRepository>(); }
                case RepositoryTypes.ProductMandarin: { return container.Resolve<IProductMandarinRepository>(); }
                case RepositoryTypes.ProductMango: { return container.Resolve<IProductMangoRepository>(); }
                case RepositoryTypes.ProductOrange: { return container.Resolve<IProductOrangeRepository>(); }
                case RepositoryTypes.ProductPear: { return container.Resolve<IProductPearRepository>(); }
                case RepositoryTypes.ProductPlum: { return container.Resolve<IProductPlumRepository>(); }
                case RepositoryTypes.ProductRaspberry: { return container.Resolve<IProductRaspberryRepository>(); }
                case RepositoryTypes.ProductStrawberry: { return container.Resolve<IProductStrawberryRepository>(); }
                case RepositoryTypes.ProductTomato: { return container.Resolve<IProductTomatoRepository>(); }
                case RepositoryTypes.ProductWaterMelon: { return container.Resolve<IProductWaterMelonRepository>(); }

                case RepositoryTypes.Storage: { return container.Resolve<IStorageRepository>(); }
                case RepositoryTypes.StorageItem: { return container.Resolve<IStorageItemRepository>(); }

                default: { return container.Resolve<IProductAppleRepository>(); }
            }
        }
    }
}
