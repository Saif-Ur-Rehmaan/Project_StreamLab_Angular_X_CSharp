using Api.CORE.Models;
using Api.CORE;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class RoleRepository(StreamLabContext entities) : IRoleRepository
    {
        protected StreamLabContext _entities = entities;

        public Role CreateRole(Role Role)
        {
            _entities.Roles.Add(Role);
            _entities.SaveChanges();
            return Role;
        }

        public Role DeleteRole(Role role)
        {
            _entities.Roles.Remove(role);
            _entities.SaveChanges();
            return role;
        }

        public Role FindRole(int id) => _entities.Roles.Find(id);

        public IEnumerable<Role> GetRoles() => _entities.Roles.ToList();

        public Role UpdateRole(int id,Role Role)
        {
            Role ExistingRole=_entities.Roles.Find(id);
            ExistingRole.Name = Role.Name;

            _entities.Roles.Update(ExistingRole);
            _entities.SaveChanges();
            return Role;
        }
    }
}
