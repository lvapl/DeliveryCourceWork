using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
