using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public interface IPickUpPointDTOService
    {
        public void Add(PickUpPointDTO pickUpPointDto);

        public void Edit(PickUpPointDTO pickUpPointDto);

        public void Remove(int id);

        public PickUpPointDTO GetById(int id);

        public IEnumerable<PickUpPointDTO> GetAll();
    }
}
