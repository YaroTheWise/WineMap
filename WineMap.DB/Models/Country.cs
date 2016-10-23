using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineMap.DB.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
