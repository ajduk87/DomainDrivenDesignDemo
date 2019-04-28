using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Requests.MoneyValue
{
    public class RequestProductsCostMin8 : IRequestMoneyValue
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestProductsCostMin8(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForProductsCostMin8(rq);

        private void RequestForProductsCostMin8(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IMoneyItemValueService moneyItemValueService = container.Resolve<IMoneyItemValueService>();
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                MoneyItemValue moneyItem = moneyItemValueService.Min(nameOfStorage);



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
