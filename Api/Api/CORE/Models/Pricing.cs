using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

namespace Api.CORE.Models
{
    public class Pricing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title {  get; set; }
        [Required]
        public required string Price {  get; set; }

        [AllowNull]
        public int DiscountPercent = 0;
        [Required,DataType(DataType.DateTime)]
        public DateTime Duration {  get; set; }
        [Required]
        public required JsonObject Features {  get; set; }
    }
}
