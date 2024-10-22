using Api.CORE.Models;

namespace Api.REPOSITORY.Interfaces
{
    public interface IPricingRepository
    {
        public IEnumerable<Pricing> GetPricings();

        public Pricing? FindPricing(int id);
        public Pricing? FindPricing(string Title);

        public Pricing CreatePricing(Pricing pricing);

        public Pricing UpdatePricing(Pricing pricing);

        public Pricing DeletePricing(Pricing pricing);
    }
}
