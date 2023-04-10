using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.MVVM.Model.Repositories
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
