using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineMap.Specification
{
    public class Wine
    {
        public int WineId { get; set; }
        public string Name { get; set; }
        public WineType Type { get; set; }
        public WineColor Color { get; set; }
        public Country CountryId { get; set; }
        public Region RegionId { get; set; }
        public WineSugar Sugar { get; set; }
        public decimal Alcohol { get; set; }
        public Grape[] GrapeIds { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
        public string[] Tegs { get; set; }
        public int[] Links { get; set; }
        public string PhotoUrl { get; set; }
    }
}
