using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands
{
    public class CommmandStorage : ICommand
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommmandStorage(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(long numberOfRequest, Request rq)
        {
            switch (numberOfRequest)
            {
                case 1: requestForCreateNewStorage1(rq); break;
                case 2: requestForCreateNewStorage2(rq); break;
                case 3: requestForCreateNewStorage3(rq); break;
                case 4: requestForCreateNewStorage4(rq); break;
                case 5: requestForCreateNewStorage5(rq); break;
                case 6: requestForCreateNewStorage6(rq); break;
                case 7: requestForCreateNewStorage7(rq); break;
                case 8: requestForCreateNewStorage8(rq); break;
                case 9: requestForCreateNewStorage9(rq); break;
                case 10: requestForCreateNewStorage10(rq); break;
                case 21: requestForGetAllStoragesInfo(); break;
                case 23: requestForEnterInSpecificStorage(rq); break;
                case 24: requestForGetStorageState(rq); break;
            }
        }

        private void requestForGetAllStoragesInfo()
        {
            try
            {
                IStorageService storageService = container.Resolve<IStorageService>();
                List<Storage> storages = storageService.GetAll().ToList();


                string response = string.Empty;
                storages.ForEach(storage =>
                {
                    response += storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content + System.Environment.NewLine;
                });
                helperClass.writeResponse(response);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForEnterInSpecificStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IStorageService storageService = container.Resolve<IStorageService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                Storage storage = storageService.Enter(nameOfStorage);


                string response = storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content;
                helperClass.writeResponse(response);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForGetStorageState(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string kindOfStorage = rq.Args[1];

                IStorageItemService storageItemsService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                List<StorageItem> storageItems = storageItemsService.GetStateOfStorage(nameOfStorage).ToList();



                string response = string.Empty;
                storageItems.ForEach(storageItem =>
                {
                    response += storageItem.NameOfProduct.Content + " " + storageItem.CountOfProduct + System.Environment.NewLine;
                });
                helperClass.writeResponse(response);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }

        }

        private void requestForCreateNewStorage1(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage2(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage3(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage4(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage5(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage6(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage7(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage8(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage9(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewStorage10(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
      
    }
}
