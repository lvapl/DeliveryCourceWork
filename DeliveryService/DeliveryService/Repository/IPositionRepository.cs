using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public interface IPositionRepository
    {
        void Add(Position position);
        void Edit(Position position);
        void Remove(int id);
        Position GetById(int id);
        IEnumerable<Position> GetAll();
    }
}
