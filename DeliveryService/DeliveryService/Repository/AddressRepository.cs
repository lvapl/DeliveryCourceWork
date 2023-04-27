using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="Address"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion
        
        public AddressRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
        public void Add(Address address)
        {
            EntityEntry<Address> entry = _context.Entry(address);
            try
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось удалить запись. Возможно есть связи с другими записями.");
            }
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
        #endregion
    }
}
