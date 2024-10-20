using Api.CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.REPOSITORY.Interfaces
{
    public interface IPurchasedPackegeRepository
    { 

        public IEnumerable<PurchasedPackege> GetPurchasedPackeges();

        public PurchasedPackege? FindPurchasedPackege( int id);

        public PurchasedPackege CreatePurchasedPackege( PurchasedPackege PurchasedPackege);

        public PurchasedPackege UpdatePurchasedPackege(int id,  PurchasedPackege PurchasedPackege);

        public PurchasedPackege DeletePurchasedPackege( PurchasedPackege PurchasedPackege);
    }
}
