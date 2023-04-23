using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Edit(User user);
        void Remove(int id);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}
