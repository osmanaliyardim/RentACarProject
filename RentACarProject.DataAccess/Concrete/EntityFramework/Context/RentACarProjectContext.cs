using Microsoft.EntityFrameworkCore;
using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Entity.Concrete;

namespace RentACarProject.DataAccess.Concrete.EntityFramework.Context
{
    public class RentACarProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=RentACarProjectDB;Trusted_Connection=True");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Findeks> Findeks { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
