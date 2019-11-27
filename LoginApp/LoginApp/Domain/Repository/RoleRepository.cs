using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LoginApp.Domain.Models;

namespace LoginApp.Domain.Repository
{
    public class RoleRepository:IRolesRepository
    {
        private readonly ironmountainEntities _context;
        private bool _disposed;

        public RoleRepository(ironmountainEntities context)
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

        public ObjectResult<GetRoles_Result> GetUsersByProcedure()
        {
            return _context.GetRoles();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void InsertRole(Role role)
        {
            _context.InsertRole(role.Name);
        }

        public void DeleteRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            _context.Roles.Remove(role ?? throw new InvalidOperationException());
        }

        public void UpdateRole(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
