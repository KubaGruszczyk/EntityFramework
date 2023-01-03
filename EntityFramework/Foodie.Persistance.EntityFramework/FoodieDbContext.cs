using Foodie.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Persistance.EntityFramework
{
    public class FoodieDbContext : DbContext
    {
        public DbSet<Recipie> Recipies { get; set; }
        public DbSet<RecipieRating> RecipieRatings { get; set; }
        public DbSet<Ingridient> Ingredients { get; set; }

        public DbSet<MetaTag> MetaTags { get; set; }
        public DbSet<RecipieMetaTag> ReciepiesMetaTags { get; set; }



        public FoodieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            {
                builder.Entity<Recipie>()
                .HasOne(x => x.RecipieRating)
                .WithOne(x => x.Recipie)
                .HasForeignKey<RecipieRating>(x => x.RecipieId);

                builder.Entity<Recipie>()
                    .HasMany(x => x.Ingridients)
                    .WithOne(x => x.Recipie)
                    .HasForeignKey(x => x.RecipieId);
            }

            builder.Entity<RecipieMetaTag>()
                .HasKey(x => new { x.RecipieId, x.MetaTagId });

            builder.Entity<RecipieMetaTag>()
                .HasOne(x => x.Recipie)
                .WithMany(x => x.RecipieMetaTags)
                .HasForeignKey(x => x.RecipieId);
            builder.Entity<RecipieMetaTag>()
                .HasOne(x => x.MetaTag)
                .WithMany(x => x.RecipieMetaTags)
                .HasForeignKey(x => x.MetaTagId);
        }
    }
}