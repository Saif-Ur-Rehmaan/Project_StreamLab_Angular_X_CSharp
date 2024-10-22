using Api.CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.REPOSITORY.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();

        public User? FindUser( int id);
        public User? FindUser(string email, int? exceptUserId = null);

            public User DeleteUser( User User);

        public User CreateUser(User User);

        public User UpdateUser( User User);



    }
}
