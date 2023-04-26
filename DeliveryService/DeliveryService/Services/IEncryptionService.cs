namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс, представляющий сервис шифрования.
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Метод шифрование пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns>Пароль в виде массива байтов</returns>
        public byte[] EncryptPassword(string password);
    }
}
