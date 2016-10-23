using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WineMap.DB.Models
{
    public class Grape
    {
        [Key]
        public int GrapeId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Wine> Wines { get; set; }
    }
}