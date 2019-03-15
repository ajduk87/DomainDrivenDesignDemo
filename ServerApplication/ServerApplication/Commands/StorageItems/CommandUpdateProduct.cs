﻿using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.FactoryFolder;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.StorageItems
{
    public class CommandUpdateProduct : ICommandStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandUpdateProduct(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => requestForUpdateProduct(rq);

        private void requestForUpdateProduct(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];
                string kindOfStorage = rq.Args[4];


                IProductService productService = container.Resolve<IProductService>();
                ProductApple product = (ProductApple)EntityFactory.Create(EntityTypes.ProductApple);
                product.NameOfProduct = new NameOfProduct { Content = nameOfProduct };
                product.Cost = new UnitCost
                {
                    Value = Convert.ToDouble(unitCostString),
                    Currency = new Currency { Content = "EUR" }
                };
                productService.Update(product);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage { Content = nameOfStorage },
                    NameOfProduct = new NameOfProduct { Content = nameOfProduct },
                    CountOfProduct = Convert.ToInt32(countString)
                };
                storageItemService.Update(storageItem);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}