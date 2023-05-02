using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="WorkersInPickUpPoint"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class WorkerPickUpPointRepository : IWorkerPickUpPointRepository
    {
        private DsContext _context;

        public WorkerPickUpPointRepository(DsContext context)
        {
            _context = context;
        }

        public void Add(WorkersInPickUpPoint workersInPickUpPoint)
        {
            EntityEntry<WorkersInPickUpPoint> entry = _context.Entry(workersInPickUpPoint);
            try
            {
                _context.WorkersInPickUpPoints.Add(workersInPickUpPoint);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(WorkersInPickUpPoint workersInPickUpPoint)
        {
            EntityEntry<WorkersInPickUpPoint> entry = _context.Entry(workersInPickUpPoint);
            try
            {
                _context.WorkersInPickUpPoints.Update(workersInPickUpPoint);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
        }

        public IEnumerable<WorkersInPickUpPoint> GetAll()
        {
            return _context.WorkersInPickUpPoints.ToList();
        }

        public WorkersInPickUpPoint GetById(int id)
        {
            return _context.WorkersInPickUpPoints.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            WorkersInPickUpPoint workerPoint = GetById(id);
            EntityEntry<WorkersInPickUpPoint> entry = _context.Entry(workerPoint);
            try
            {
                _context.WorkersInPickUpPoints.Remove(workerPoint);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось удалить запись. Возможно присутствуют связи с другими записями.");
            }
        }
    }
}
