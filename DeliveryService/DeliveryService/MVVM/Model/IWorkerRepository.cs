﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.MVVM.Model
{
    public interface IWorkerRepository
    {
        void Add(Worker worker);
        void Edit(Worker worker);
        void Remove(int id);
        Worker GetById(int id);
        Worker? GetWorkerByLoginAndPassword(string login, byte[] password);
        IEnumerable<Worker> GetAll();
    }
}
