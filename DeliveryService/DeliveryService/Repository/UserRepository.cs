using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Model;

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
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Edit(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Remove(int id)
        {
            _context.Users.Remove(GetById(id));
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id) ?? throw new Exception();
        }
        #endregion
    }
}
