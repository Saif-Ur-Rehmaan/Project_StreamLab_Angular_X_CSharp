using System.ComponentModel;
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

        [AllowNull,DefaultValue(0)]
        public int DiscountPercent { get; set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime Duration {  get; set; }
        [Required,DataType(DataType.Text)]
        public required string Features {  get; set; }
    }
}
