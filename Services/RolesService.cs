using daily_stream_cms.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_stream_cms.Services
{
    public class RolesService
    {
        private readonly AppDbContext _context;
        public RolesService(AppDbContext context)
        {
            _context = context;
        }

        //function to get all roles
        public List<Role> getAllRoles() {

        return _context.Roles.ToList();
        }

        //function to add new role
        public Role CreateRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        //function to get role by id
        public Role getRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        // Update existing role
        public Role UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }

        // Delete role by ID
        public bool DeleteRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role == null)
            {
                return false;
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }


    }
}
