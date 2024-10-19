using Api.CORE;
using Api.CORE.Models;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class PurchasedPackegeRepository(StreamLabContext entities) : IPurchasedPackegeRepository
    {
        protected StreamLabContext _entities = entities;
        public PurchasedPackege CreatePurchasedPackege(PurchasedPackege PurchasedPackege)
        {
            _entities.PurchasedPackeges.Add(PurchasedPackege);
            _entities.SaveChanges();
            return PurchasedPackege;
        }

        public PurchasedPackege DeletePurchasedPackege(PurchasedPackege PurchasedPackege)
        {
            _entities.PurchasedPackeges.Remove(PurchasedPackege);
            _entities.SaveChanges();
            return PurchasedPackege;
        }

        public PurchasedPackege FindPurchasedPackege(int id)
        {
            return _entities.PurchasedPackeges.Find(id);
        }

        public IEnumerable<PurchasedPackege> GetPurchasedPackege()
        {
            return _entities.PurchasedPackeges.ToList();
        }

        public PurchasedPackege UpdatePurchasedPackege(int id, PurchasedPackege PurchasedPackege)
        {
            PurchasedPackege pp = _entities.PurchasedPackeges.Find(id);
            pp.Pricing = PurchasedPackege.Pricing;
            pp.User = PurchasedPackege.User;
            pp.Status = PurchasedPackege.Status;
            _entities.PurchasedPackeges.Update(pp);
            _entities.SaveChanges();
            return PurchasedPackege;
        }
    }
}
