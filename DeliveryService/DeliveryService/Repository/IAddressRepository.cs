using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IAddressRepository
    {
        void Add(Address address);
        void Edit(Address address);
        void Remove(int id);
        Address GetById(int id);
        IEnumerable<Address> GetAll();
    }
}
