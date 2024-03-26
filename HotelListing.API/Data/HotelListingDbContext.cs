using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data

{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    ShortName = "IND"

                },
                new Country
                {
                    Id = 2,
                    Name = "Germany",
                    ShortName = "GRM"
                 },
                 new Country
                 {
                     Id = 3,
                     Name = "Japan",
                     ShortName = "JAP"
                  }
                 );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sugge Resort",
                    Address = "Bangalore",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hilton",
                    Address = "Tokyo",
                    CountryId = 3,
                    Rating = 4.2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "ITC Hotel",
                    Address = "Berlin",
                    CountryId = 2,
                    Rating = 4.6
                }
                );
        }
    }
}
