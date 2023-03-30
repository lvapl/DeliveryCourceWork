using DeliveryService.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IWorkerRepository _workerRepository;
        private IEncryptionService _encryptionService;

        public AuthenticationService(IWorkerRepository workerRepository, IEncryptionService encryptionService)
        {
            _workerRepository = workerRepository;
            _encryptionService = encryptionService; 
        }

        public bool AuthenticateWorker(NetworkCredential credential)
        {
            byte[] encryptedPassword = _encryptionService.EncryptPassword(credential.Password);
            Worker? authWorker = _workerRepository.GetWorkerByLoginAndPassword(credential.UserName, encryptedPassword);
            return authWorker == null ? false : true;
        }
    }
}
