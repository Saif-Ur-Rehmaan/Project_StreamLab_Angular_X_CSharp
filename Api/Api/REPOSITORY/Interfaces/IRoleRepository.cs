using Api.CORE.Models;

namespace Api.REPOSITORY.Interfaces
{
    public interface IRoleRepository
    {
   
        public IEnumerable<Role> GetRoles();

        public Role? FindRole(int id);
        public Role? FindRole(string name);
        public Role? FindRoleExcept(string name,int exceptRoleid);

        public Role CreateRole(Role Role);

        public Role UpdateRole(Role Role);

        public Role DeleteRole(Role Role);


    }
}
