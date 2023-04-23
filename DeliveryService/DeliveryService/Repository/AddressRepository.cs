using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

namespace DeliveryService.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private DsContext _context;

        public AddressRepository(DsContext context)
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
            return _context.Addresses.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            _context.Addresses.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
