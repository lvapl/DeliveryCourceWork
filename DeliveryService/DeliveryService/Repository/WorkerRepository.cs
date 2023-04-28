using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="Worker"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class WorkerRepository : IWorkerRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion

        public WorkerRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
        public void Add(Worker worker)
        {
            EntityEntry<Worker> entry = _context.Entry(worker);
            try
            {
                _context.Workers.Add(worker);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(Worker worker)
        {
            EntityEntry<Worker> entry = _context.Entry(worker);
            try
            {
                _context.Workers.Update(worker);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
        }

        public IEnumerable<Worker> GetAll()
        {
            return _context.Workers.ToList();
        }
        
        public Worker GetById(int id)
        {
            return _context.Workers.Find(id) ?? throw new Exception();
        }

        public Worker? GetWorkerByLoginAndPassword(string login, byte[] password)
        {
            return _context.Workers.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public void Remove(int id)
        {
            Worker worker = GetById(id);
            EntityEntry<Worker> entry = _context.Entry(worker);
            try
            {
                _context.Workers.Remove(worker);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось удалить запись. Возможно присутствуют связанные записи.");
            }
        }
        #endregion
    }
}
