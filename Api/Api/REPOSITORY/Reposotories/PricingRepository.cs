    using Api.CORE;
using Api.CORE.Models;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class PricingRepository(StreamLabContext entities) : IPricingRepository
    {
        protected StreamLabContext _entities = entities;
        public Pricing CreatePricing(Pricing pricing)
        {
            var entity=_entities.Pricings.Add(pricing);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public Pricing DeletePricing(Pricing pricing)
        {
            _entities.Pricings.Remove(pricing);
            _entities.SaveChanges();
            return pricing;
        }

        public Pricing? FindPricing(int id)
        {
            return _entities.Pricings.Find(id)  ;
        }

        public Pricing? FindPricing(string Title)
        {
            return _entities.Pricings.FirstOrDefault(x=>x.Title==Title);
        }

        public IEnumerable<Pricing> GetPricings()
        {
            return [.. _entities.Pricings];
        }

        public Pricing UpdatePricing(Pricing pricing)
        {
            var epricing = _entities.Pricings.Update(pricing);
            _entities.SaveChanges();
            return epricing.Entity;
        }
    }
}
