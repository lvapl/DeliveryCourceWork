using DeliveryService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeliveryService.Repository
{
    public class UserRepository : IUserRepository
    {
        private DsContext _context;

        public UserRepository(DsContext context)
        {
            _context = context;
        }

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
    }
}
