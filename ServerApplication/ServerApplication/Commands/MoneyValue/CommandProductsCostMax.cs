using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Commands.MoneyValue
{
    public class CommandProductsCostMax : ICommandMoneyValue
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandProductsCostMax(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForProductsCostMax(rq);

        private void RequestForProductsCostMax(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IMoneyItemValueService moneyItemValueService = container.Resolve<IMoneyItemValueService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                MoneyItemValue moneyItem = moneyItemValueService.Max(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                helperClass.writeResponse(response);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);

            }
        }
    }
}
