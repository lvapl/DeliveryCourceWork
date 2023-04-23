﻿using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

namespace DeliveryService.Repository
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
            _context.SaveChanges();
        }

        public Worker GetById(int id)
        {
            return _context.Workers.Find(id) ?? throw new Exception();
        }

        public Worker? GetWorkerByLoginAndPassword(string login, byte[] password)
        {
            return _context.Workers.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
        }
    }
}
