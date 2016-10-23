using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineMap.DB.Models;

namespace WineMap.DB
{
    public class WineMapDB : DbContext
    {
        public WineMapDB()
            : base("name=WineMapDB")
        {
        }

        public virtual DbSet<Wine> Wines { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Grape> Grapes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<WinePhoto> WinePhotos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            modelBuilder.Entity<Wine>()
              .HasMany<Tag>(s => s.Tags)
              .WithMany(c => c.Wines)
              .Map(cs =>
              {
                  cs.MapLeftKey("WineId");
                  cs.MapRightKey("TagId");
                  cs.ToTable("WineTag");
              });

            modelBuilder.Entity<Wine>()
              .HasMany<Grape>(s => s.Grapes)
              .WithMany(c => c.Wines)
              .Map(cs =>
              {
                  cs.MapLeftKey("WineId");
                  cs.MapRightKey("GrapeId");
                  cs.ToTable("WineGrape");
              });
        }
    }
}
