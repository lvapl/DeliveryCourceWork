using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeliveryService.MVVM.Model.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private DsContext _context;

        public WorkerRepository(DsContext context)
        {
            _context = context;
        }

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
        }

        public Worker GetById(int id)
        {
            return _context.Workers.Find(id) ?? throw new ArgumentNullException();
        }

        public Worker? GetWorkerByLoginAndPassword(string login, byte[] password)
        {
            return _context.Workers.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }
    }
}
