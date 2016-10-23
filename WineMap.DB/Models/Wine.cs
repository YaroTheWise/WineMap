using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineMap.DB.Models
{
    public class Wine
    {
        [Key]
        public int WineId { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int Type { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int Color { get; set; }
        public int Sugar { get; set; }
        public decimal Alcohol { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [StringLength(2000)]
        public string History { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Grape> Grapes { get; set; }
        public virtual ICollection<WinePhoto> Photos { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
