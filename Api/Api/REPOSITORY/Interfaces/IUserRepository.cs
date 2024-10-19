using Api.CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.REPOSITORY.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();

        public User FindUser( int id);

        public User DeleteUser( User User);

        public User CreateUser(User User);

        public User UpdateUser(int id,User User);



    }
}
