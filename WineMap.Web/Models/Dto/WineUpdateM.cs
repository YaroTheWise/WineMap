using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineMap.Specification;

namespace WineMap.Web.Models.Dto
{
    public class WineUpdateM
    {
        public int WineId { get; set; }
        public string Name { get; set; }
        public WineType Type { get; set; }
        public WineColor Color { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public WineSugar Sugar { get; set; }
        public decimal Alcohol { get; set; }
        public int[] GrapeIds { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
        public string[] Tegs { get; set; }
        public int[] Links { get; set; }
        public string PhotoUrl { get; set; }

    }
}