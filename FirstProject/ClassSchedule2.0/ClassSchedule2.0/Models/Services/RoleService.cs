using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassSchedule2._0.Models.ScheduleDb;

namespace ClassSchedule2._0.Models.Services
{
    public class RoleService
    {
        private SchedularDbEntities db = new SchedularDbEntities();

        public void CreateRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            List<Role> roles = db.Roles.OrderBy(r => r.Name).ToList();
            return roles;
        }

        public Role GetRole(int roleId)
        {
            Role role = db.Roles.FirstOrDefault(r => r.Id == roleId);
            return role;
        }

        public void UpdateRole(Role role)
        {
            Role roleToUpdate = db.Roles.FirstOrDefault(r => r.Id == role.Id);
            db.Entry(roleToUpdate).OriginalValues.SetValues(role);

            db.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            db.Roles.Remove(role);
            db.SaveChanges();
        }

        public void DeleteRole(int roleId)
        {
            Role role = GetRole(roleId);
            DeleteRole(role);
        }
    }
}