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
namespace ServerApplication.Modules
{
    public class TruckRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<TruckRepository>().As<ITruckRepository>();
            base.Load(objContainer);
        }
    }
}
