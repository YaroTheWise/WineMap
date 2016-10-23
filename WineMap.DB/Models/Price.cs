using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineMap.DB.Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        public int WineId { get; set; }
        public int Volume { get; set; }
        public decimal Value { get; set; }
        public decimal? Discount { get; set; }

        [ForeignKey("WineId")]
        public virtual Wine Wine { get; set; }
    }
}