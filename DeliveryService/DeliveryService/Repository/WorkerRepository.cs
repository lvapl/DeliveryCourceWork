using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

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
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }

        public void Edit(Worker worker)
        {
            _context.Workers.Update(worker);
            _context.SaveChanges();
        }

        public IEnumerable<Worker> GetAll()
        {
            return _context.Workers.ToList();
        }

        public void Remove(int id)
        {
            _context.Workers.Remove(GetById(id));
            _context.SaveChanges();
        }

        public Worker GetById(int id)
        {
            return _context.Workers.Find(id) ?? throw new Exception();
        }

        public Worker? GetWorkerByLoginAndPassword(string login, byte[] password)
        {
            return _context.Workers.FirstOrDefault(x => x.Login == login && x.Password == password);
        }
        #endregion
    }
}
