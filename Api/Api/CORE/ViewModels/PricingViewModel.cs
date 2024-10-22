using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Api.CORE.ViewModels
{
    public class PricingViewModel
    {
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Price { get; set; }

        [AllowNull, DefaultValue(0)]
        public int DiscountPercent { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Duration { get; set; }
        [Required, DataType(DataType.Text)]
        public required string Features { get; set; }
    }
}
