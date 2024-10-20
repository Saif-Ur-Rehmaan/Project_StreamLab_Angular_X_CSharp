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
        public Role? FindRole(int id ,string name) => _entities.Roles.FirstOrDefault(x=>x.Name==name && x.Id==id);

        public IEnumerable<Role> GetRoles() => [.. _entities.Roles];

        public Role? UpdateRole(int id,Role Role)
        {
            Role? ExistingRole=FindRole(id);
            if (ExistingRole!=null)
            {
                ExistingRole.Name = Role.Name;
                _entities.SaveChanges();
            }
            return ExistingRole;
        }
   
        
    }
}
