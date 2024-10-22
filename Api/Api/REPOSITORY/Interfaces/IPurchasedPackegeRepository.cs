using Api.CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.REPOSITORY.Interfaces
{
    public interface IPurchasedPackegeRepository
    { 

        public IEnumerable<PurchasedPackege> GetPurchasedPackeges();

        public PurchasedPackege? FindPurchasedPackege( int id);
        public PurchasedPackege? FindPurchasedPackege(string useremail, string PricingTitle);

        public PurchasedPackege CreatePurchasedPackege( PurchasedPackege PurchasedPackege);

        public PurchasedPackege UpdatePurchasedPackege(  PurchasedPackege PurchasedPackege);

        public PurchasedPackege DeletePurchasedPackege( PurchasedPackege PurchasedPackege);
    }
}
