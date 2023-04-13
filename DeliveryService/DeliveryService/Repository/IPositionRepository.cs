using DeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
