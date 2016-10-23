using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineMap.DB.Models
{
    public class WinePhoto
    {
        [Key]
        public int PhotoId { get; set; }
        public int WineId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(256)]
        public string OriginalName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public int Order { get; set; }
        
        [ForeignKey("WineId")]
        public virtual Wine Wine { get; set; }
    }
}