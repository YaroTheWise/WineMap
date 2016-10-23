using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WineMap.DB.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Wine> Wines { get; set; }
    }
}