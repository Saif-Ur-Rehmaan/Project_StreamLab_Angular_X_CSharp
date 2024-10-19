using Api.CORE;
using Api.CORE.Models;
using Api.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.REPOSITORY.Reposotories
{
    public class UserRepository(StreamLabContext entities) : IUserRepository
    {
        protected StreamLabContext _entities=entities;
        public User CreateUser(User User)
        {
            _entities.Users.Add(User);
            return User;
        }

        public User DeleteUser(User User)
        {
            _entities.Users.Remove(User);
            return User;
        }

        public User FindUser(int id)=>_entities.Users.Find(id);

        public IEnumerable<User> GetUsers()=>_entities.Users.ToList();

        public User UpdateUser(int id, User User)
        {
            User user = FindUser(id);
             
                user.UserName = User.UserName;
                user.FirstName= User.FirstName;
                user.LastName= User.LastName;
                user.Email= User.Email;
                user.Password= User.Password;

           

            _entities.Users.Update(user);
            _entities.SaveChanges();
            return user;
           
        }
    }
}
