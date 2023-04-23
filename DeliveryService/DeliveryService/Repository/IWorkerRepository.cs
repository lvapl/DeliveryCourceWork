using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IWorkerRepository
    {
        void Add(Worker worker);
        void Edit(Worker worker);
        void Remove(int id);
        Worker GetById(int id);
        Worker? GetWorkerByLoginAndPassword(string login, byte[] password);
        IEnumerable<Worker> GetAll();
    }
}
