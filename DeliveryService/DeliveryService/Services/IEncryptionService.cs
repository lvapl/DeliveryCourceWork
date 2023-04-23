namespace DeliveryService.Services
{
    public interface IEncryptionService
    {
        public byte[] EncryptPassword(string password);
    }
}
