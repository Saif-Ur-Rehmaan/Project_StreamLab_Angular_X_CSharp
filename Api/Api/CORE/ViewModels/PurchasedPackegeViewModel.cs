using Api.CORE.Constants;
using Api.CORE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Api.CORE.ViewModels
{
    public class PurchasedPackegeViewModel
    {
        [Required,EmailAddress]
        public required string  UserEmail { get; set; }
        [Required]
        public required string PricingTitle { get; set; }

        [AllowNull, DefaultValue(PurchasedPackegeStatusType.Allowed)]
        public PurchasedPackegeStatusType Status { get; set; }
    }
}
