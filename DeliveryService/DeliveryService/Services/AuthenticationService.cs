using System;
using System.Net;
using DeliveryService.Enums;
using DeliveryService.Model;
using DeliveryService.Repository;

namespace DeliveryService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IWorkerRepository _workerRepository;
        private IEncryptionService _encryptionService;

        private Worker? _worker;

        public AuthenticationService(IWorkerRepository workerRepository, IEncryptionService encryptionService)
        {
            _workerRepository = workerRepository;
            _encryptionService = encryptionService; 
        }

        public Worker? AuthenticateWorker(NetworkCredential credential)
        {
            byte[] encryptedPassword = _encryptionService.EncryptPassword(credential.Password);
            _worker = _workerRepository.GetWorkerByLoginAndPassword(credential.UserName, encryptedPassword);
            return _worker;
        }

        public bool HasAccessToSection(AppPages section)
        {
            if (_worker != null)
            {
                if (_worker.Position.Title == "Администратор" || _worker.Position.Title == "Бизнес-аналитик")
                {
                    return true;
                }
                else if (_worker.Position.Title == "Оператор пункта выдачи")
                {
                    return section == AppPages.PickUpPoint
                        || section == AppPages.Delivery;
                }
                else if (_worker.Position.Title == "Работник склада")
                {
                    return section == AppPages.Storage;
                }
                else if (_worker.Position.Title == "Доставщик")
                {
                    return section == AppPages.Delivery;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
        }

        public bool HasAccessToSubSection<T>(T subSection) where T: Enum
        {
            if (_worker != null)
            {
                if (_worker.Position.Title == "Администратор")
                {
                    return true;
                }
                else if (_worker.Position.Title == "Бизнес-аналитик")
                {
                    return !(typeof(T) == typeof(WorkerPages) && subSection.Equals(WorkerPages.WorkerPassword));
                }
                else if (_worker.Position.Title == "Оператор пункта выдачи")
                {
                    return typeof(T) == typeof(PickUpPointPages)
                        || (typeof(T) == typeof(DeliveryPages) && subSection.Equals(DeliveryPages.DeliveryGeneralInfo));
                }
                else if (_worker.Position.Title == "Работник склада")
                {
                    return typeof(T) == typeof(StoragePages) && subSection.Equals(StoragePages.StorageGeneralInfo);
                }
                else if (_worker.Position.Title == "Доставщик")
                {
                    return typeof(T) == typeof(DeliveryPages);
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool HasPermissionToModifySubsection<T>(T dtoSubSection) where T : Enum
        {
            if (_worker != null)
            {
                if (_worker.Position.Title == "Администратор")
                {
                    return true;
                }
                else if (_worker.Position.Title == "Оператор пункта выдачи")
                {
                    return typeof(T) == typeof(PickUpPointPages)
                        || (typeof(T) == typeof(DeliveryPages) && dtoSubSection.Equals(DeliveryPages.DeliveryGeneralInfo));
                }
                else if (_worker.Position.Title == "Работник склада")
                {
                    return typeof(T) == typeof(StoragePages) && dtoSubSection.Equals(StoragePages.StorageGeneralInfo);
                }
                else if (_worker.Position.Title == "Доставщик")
                {
                    return typeof(T) == typeof(DeliveryPages);
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
