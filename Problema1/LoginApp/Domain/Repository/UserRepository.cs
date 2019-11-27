using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Domain.Models;

namespace LoginApp.Domain.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ironmountainEntities _context;
        private bool _disposed;

        public UserRepository(ironmountainEntities context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ObjectResult<GetUsers_Result> GetUsersByProcedure()
        {
            return _context.GetUsers();
        }

        public GetUserById_Result GetUserByIdProcedure(int userId)
        {
            return _context.GetUserById(userId).GetEnumerator().Current;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void InsertUser(User user)
        {
             _context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            _context.Users.Remove(user ?? throw new InvalidOperationException());
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
