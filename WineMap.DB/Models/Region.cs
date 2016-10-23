using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineMap.DB.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}