using System.Diagnostics.Eventing.Reader;
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
        protected StreamLabContext _entities = entities;
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
        public User? FindUser(int id) => _entities.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
        public User? FindUser(string email, int? exceptUserId = null) {
            if (exceptUserId==null)
            {
                return _entities.Users.Include(x => x.Role).FirstOrDefault(x=>x.Email==email);

            }
            else
            {
                return _entities.Users.Include(x => x.Role).FirstOrDefault(x=>x.Email==email && x.Id !=exceptUserId);
            }
                
        }

        public IEnumerable<User> GetUsers()=> [.. _entities.Users.Include(x=>x.Role)];

        public User UpdateUser( User User)
        {
            var  user= _entities.Users.Update(User);
            _entities.SaveChanges();

            return user.Entity;
           
        }
    }
}
