using DeliveryService.MVVM.Model.DTO;
using DeliveryService.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IAddressDTOService
    {
        public void Add(AddressDTO addressDTO);

        public void Edit(AddressDTO addressDTO);

        public void Remove(int id);

        public AddressDTO GetById(int id);

        public IEnumerable<AddressDTO> GetAll();
    }
}
