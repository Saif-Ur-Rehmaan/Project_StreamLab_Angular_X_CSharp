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
            var entity=_entities.Roles.Add(Role);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public Role DeleteRole(Role role)
        {
            _entities.Roles.Remove(role);
            _entities.SaveChanges();
            return role;
        }

        public Role? FindRole(int id) => _entities.Roles.Find(id);
        public Role? FindRole(string name) => _entities.Roles.FirstOrDefault(x=>x.Name==name);
        public Role? FindRoleExcept(string name, int exceptRoleid ) {
            
                return _entities.Roles.FirstOrDefault(x => x.Name == name && x.Id!=exceptRoleid);
          

        }

        public IEnumerable<Role> GetRoles() => [.. _entities.Roles];

        public Role UpdateRole(Role Role)
        {
            var role=_entities.Roles.Update(Role);
            _entities.SaveChanges();
            return role.Entity;
        }
   
        
    }
}
