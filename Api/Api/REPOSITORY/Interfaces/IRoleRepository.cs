using Api.CORE.Models;

namespace Api.REPOSITORY.Interfaces
{
    public interface IRoleRepository
    {
   
        public IEnumerable<Role> GetRoles();

        public Role FindRole(int id);

        public Role CreateRole(Role Role);

        public Role UpdateRole(int id,Role Role);

        public Role DeleteRole(Role Role);


    }
}
