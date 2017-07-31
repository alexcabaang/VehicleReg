using Microsoft.EntityFrameworkCore;
using MovieApps.Models;

namespace MovieApps.Persistence
{
    public class MovieAppsDBContext : DbContext
    {  
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Make>Makes {get; set;}
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public MovieAppsDBContext(DbContextOptions<MovieAppsDBContext> options)
                : base (options)
        {           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => 
              new { vf.VehicleId, vf.FeatureId });
        }        
    }
}
