using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Api.CORE.Constants;

namespace Api.CORE.Models
{

    public class PurchasedPackege
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required User User { get; set; }
        [Required]
        public required Pricing Pricing { get; set; }

        [AllowNull,DefaultValue(PurchasedPackegeStatusType.Allowed)]
        public PurchasedPackegeStatusType Status { get; set; }

    }
   
}
