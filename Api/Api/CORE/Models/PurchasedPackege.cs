﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

        [AllowNull]
        public PurchasedPackegeStatusType Status = PurchasedPackegeStatusType.Allowed;

    }
    public enum PurchasedPackegeStatusType 
    { 
        Allowed=1,
        NotAllowed=2,
        
    };
}