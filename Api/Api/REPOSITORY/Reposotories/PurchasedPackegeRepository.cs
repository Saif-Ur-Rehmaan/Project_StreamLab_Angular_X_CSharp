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

        public IEnumerable<PurchasedPackege> GetPurchasedPackeges()
        {
            return [.. _entities.PurchasedPackeges.Include(x => x.Pricing).Include(x => x.User)];
        }

        public PurchasedPackege UpdatePurchasedPackege(int id, PurchasedPackege PurchasedPackege)
        {
            PurchasedPackege? pp = FindPurchasedPackege(id);
            if (pp != null)
            {
                pp.Pricing = PurchasedPackege.Pricing;
                pp.User = PurchasedPackege.User;
                pp.Status = PurchasedPackege.Status; 
                _entities.SaveChanges();
                
            }
            return PurchasedPackege;
        }
    }
}
