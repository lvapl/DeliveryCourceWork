using System.Collections.Generic;
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
