using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DeliveryService.Repository
{
    /// <summary>
    /// Репозиторий модели <see cref="User"/>, реализует соответствующий интерфейс репозитория.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Private Fields
        private DsContext _context;
        #endregion

        public UserRepository(DsContext context)
        {
            _context = context;
        }

        #region Methods
        public void Add(User user)
        {
            EntityEntry<User> entry = _context.Entry(user);
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось добавить запись.");
            }
        }

        public void Edit(User user)
        {
            EntityEntry<User> entry = _context.Entry(user);
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch
            {
                entry.Reload();
                throw new Exception("Не удалось изменить запись.");
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
        
        public User GetById(int id)
        {
            return _context.Users.Find(id) ?? throw new Exception();
        }

        public void Remove(int id)
        {
            User user = GetById(id);
            EntityEntry<User> entry = _context.Entry(user);
            try
            {
                _context.Users.Remove(user);
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
