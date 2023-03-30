using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IEncryptionService
    {
        public byte[] EncryptPassword(string password);
    }
}
