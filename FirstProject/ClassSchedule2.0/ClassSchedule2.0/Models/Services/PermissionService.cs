using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassSchedule2._0.Models.ScheduleDb;

namespace ClassSchedule2._0.Models.Services
{
    public class PermissionService
    {
        private SchedularDbEntities db = new SchedularDbEntities();

        public void CreatePermission(Permission permission)
        {
            db.Permissions.Add(permission);
            db.SaveChanges();
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            List<Permission> permissions = db.Permissions.OrderBy(p => p.Name).ToList();
            return permissions;
        }

        public Permission GetPermission(int permissionId)
        {
            Permission permission = db.Permissions.FirstOrDefault(p => p.Id == permissionId);
            return permission;
        }

        public void UpdatePermission(Permission permission)
        {
            Permission permissionToUpdate = db.Permissions.FirstOrDefault(p => p.Id == permission.Id);
            db.Entry(permissionToUpdate).OriginalValues.SetValues(permission);

            db.SaveChanges();
        }

        public void DeletePermission(Permission permission)
        {
            db.Permissions.Remove(permission);
            db.SaveChanges();
        }

        public void DeletePermission(int permissionId)
        {
            Permission permission = GetPermission(permissionId);
            DeletePermission(permission);
        }
    }
}