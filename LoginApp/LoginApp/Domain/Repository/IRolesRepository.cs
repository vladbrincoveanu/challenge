using System;
using System.Collections.Generic;
using LoginApp.Domain.Models;

namespace LoginApp.Domain.Repository
{
    public interface IRolesRepository:IDisposable
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int roleId);
        void InsertRole(Role role);
        void DeleteRole(int roleId);
        void UpdateRole(Role role);
        void Save();
    }
}
