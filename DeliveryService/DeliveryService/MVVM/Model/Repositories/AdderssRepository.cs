using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.MVVM.Model.Repositories
{
    public class AdderssRepository : IAddressRepository
    {
        private DsContext _context;

        public AdderssRepository(DsContext context)
        {
            _context = context;
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Edit(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Find(id) ?? throw new ArgumentNullException();
        }

        public void Remove(int id)
        {
            _context.Addresses.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
