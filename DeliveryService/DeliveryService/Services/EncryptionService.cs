using System.Security.Cryptography;
using System.Text;

namespace DeliveryService.Services
{
    public class EncryptionService : IEncryptionService
    {
        public byte[] EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
