using Api.CORE;
using Api.CORE.Models;
using Api.REPOSITORY.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.REPOSITORY.Reposotories
{
    public class PurchasedPackegeRepository(StreamLabContext entities) : IPurchasedPackegeRepository
    {
        protected StreamLabContext _entities = entities;
        public PurchasedPackege CreatePurchasedPackege(PurchasedPackege PurchasedPackege)
        {
           var entity= _entities.PurchasedPackeges.Add(PurchasedPackege);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public PurchasedPackege DeletePurchasedPackege(PurchasedPackege PurchasedPackege)
        {
            _entities.PurchasedPackeges.Remove(PurchasedPackege);
            _entities.SaveChanges();
            return PurchasedPackege;
        }

        public PurchasedPackege? FindPurchasedPackege(int id)
        {
            return _entities.PurchasedPackeges.Include(x => x.Pricing).Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public PurchasedPackege? FindPurchasedPackege(string useremail, string PricingTitle)
        {
            return _entities.PurchasedPackeges
                .Include(x => x.Pricing).Include(x => x.User)
                .FirstOrDefault(x => x.User.Email == useremail && x.Pricing.Title==PricingTitle);
            
        }

        public IEnumerable<PurchasedPackege> GetPurchasedPackeges()
        {
            return [.. _entities.PurchasedPackeges.Include(x => x.Pricing).Include(x => x.User)];
        }

        public PurchasedPackege UpdatePurchasedPackege(PurchasedPackege PurchasedPackege)
        {
            var pp = _entities.PurchasedPackeges.Update(PurchasedPackege);
            _entities.SaveChanges();
             
            return pp.Entity;
        }
    }
}
