using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }        

        public void Edit(Worker worker)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Worker> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Worker GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Worker? GetWorkerByLoginAndPassword(string login, byte[] password)
        {
            return _context.Workers.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }
    }
}
