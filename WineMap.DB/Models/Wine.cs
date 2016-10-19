using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
