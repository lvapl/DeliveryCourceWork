using DeliveryService.DTO;
using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IPickUpPointDTOService
    {
        public void Add(PickUpPointDTO pickUpPointDTO);

        public void Edit(PickUpPointDTO pickUpPointDTO);

        public void Remove(int id);

        public PickUpPointDTO GetById(int id);

        public IEnumerable<PickUpPointDTO> GetAll();
    }
}
