using Api.CORE;
using Api.CORE.Models;
using Api.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.REPOSITORY.Reposotories
{
    public class UserRepository(StreamLabContext entities) : IUserRepository
    {
        protected StreamLabContext _entities=entities;
        public User CreateUser(User user)
        {
            var entry = _entities.Users.Add(user);  
            _entities.SaveChanges();  
            return entry.Entity;  
        }
        public User DeleteUser(User User)
        {
            _entities.Users.Remove(User);
            _entities.SaveChanges();
            return User;
        }
        public User? FindUser(int id)=>_entities.Users.Include(x => x.Role).FirstOrDefault(x=>x.Id==id)  ;
        public User? FindUser(string email)=>_entities.Users.Include(x => x.Role).FirstOrDefault(x=>x.Email==email)  ;

        public IEnumerable<User> GetUsers()=> [.. _entities.Users.Include(x=>x.Role)];

        public User? UpdateUser(int id, User User)
        {
            User? user = FindUser(id);
            if (user!=null)
            {
                user.UserName = User.UserName;
                user.Role = User.Role;
                    
                user.FirstName= User.FirstName;
                user.LastName= User.LastName;
                user.Email= User.Email;
                user.Password= User.Password;
                _entities.SaveChanges();

            }
            return user;
           
        }
    }
}
