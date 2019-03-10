﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Services.Implementations;
using ServerApplication.Repositories.Implementations;
using ServerApplication.Services.Interfaces;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Interfaces.Products;

namespace ServerApplication.Modules
{
    public class ProductsModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ProductRepository>().As<IProductAppleRepository>();
            objContainer.RegisterType<ProductService>().As<IProductService>();
            base.Load(objContainer);
        }
    }
}
