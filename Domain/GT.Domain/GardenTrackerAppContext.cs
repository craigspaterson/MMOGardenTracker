using GT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GT.Domain
{
    public class GardenTrackerAppContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public GardenTrackerAppContext(DbContextOptions<GardenTrackerAppContext> options) : base(options)
        {
        }

        public DbSet<Crop> Crops { get; set; }

        public DbSet<CropActivity> CropActivities { get; set; }

        public DbSet<Garden> Gardens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set the default schema
            modelBuilder.HasDefaultSchema("dbo");

            // Garden properties
            modelBuilder.Entity<Garden>().ToTable("Garden").HasKey(x => x.GardenId);
            modelBuilder.Entity<Garden>().Property(x => x.GardenId).HasColumnName("GardenId").ValueGeneratedOnAdd();
            modelBuilder.Entity<Garden>().Property(x => x.GardenName).HasColumnName("GardenName");

            // Crop properties
            modelBuilder.Entity<Crop>().ToTable("Crop").HasKey(x => x.CropId);
            modelBuilder.Entity<Crop>().Property(x => x.CropId).HasColumnName("CropId").ValueGeneratedOnAdd();
            modelBuilder.Entity<Crop>().Property(x => x.CropName).HasColumnName("CropName");
            modelBuilder.Entity<Crop>().Property(x => x.PlantName).HasColumnName("PlantName");
            modelBuilder.Entity<Crop>().Property(x => x.BeginDate).HasColumnName("BeginDate");
            modelBuilder.Entity<Crop>().Property(x => x.EndDate).HasColumnName("EndDate");
            modelBuilder.Entity<Crop>().Property(x => x.Notes).HasColumnName("Notes");
            modelBuilder.Entity<Crop>().Property(x => x.GardenId).HasColumnName("GardenId");
            modelBuilder.Entity<Crop>()
                .HasOne(c => c.Garden)
                .WithMany(g => g.Crops)
                .HasForeignKey(c => c.CropId)
                .OnDelete(DeleteBehavior.ClientCascade);

            // CropActivity properties
            modelBuilder.Entity<CropActivity>().ToTable("CropActivity").HasKey(x => x.CropActivityId);
            modelBuilder.Entity<CropActivity>().Property(x => x.CropActivityId).HasColumnName("CropActivityId").ValueGeneratedOnAdd();
            modelBuilder.Entity<CropActivity>().Property(x => x.ActivityId).HasColumnName("ActivityId");
            modelBuilder.Entity<CropActivity>().Property(x => x.ActivityDate).HasColumnName("ActivityDate");
            modelBuilder.Entity<CropActivity>().Property(x => x.Notes).HasColumnName("Notes");
            modelBuilder.Entity<CropActivity>().Property(x => x.CropId).HasColumnName("CropId");
            modelBuilder.Entity<CropActivity>()
                .HasOne(ca => ca.Crop)
                .WithMany(c => c.CropActivities)
                .HasForeignKey(ca => ca.CropId);
        }
    }
}