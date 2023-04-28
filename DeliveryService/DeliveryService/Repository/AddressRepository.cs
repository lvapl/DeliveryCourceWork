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
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(Address address)
        {
            EntityEntry<Address> entry = _context.Entry(address);
            try
            {
                _context.Addresses.Update(address);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
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
            Address address = GetById(id);
            EntityEntry<Address> entry = _context.Entry(address);
            try
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось удалить запись. Возможно присутствуют связи с другими записями.");
            }
        }
        #endregion
    }
}
