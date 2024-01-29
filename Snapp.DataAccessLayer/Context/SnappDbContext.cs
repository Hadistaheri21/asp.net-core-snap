using Microsoft.EntityFrameworkCore;
using Snapp.DataAccessLayer.Entites;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.DataAccessLayer.Context
{
    public class SnappDbContext : DbContext
    {
        public SnappDbContext(DbContextOptions<SnappDbContext> options) : base(options)
        {
           
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Humidity> Humidities { get; set; }

        public DbSet<MonthType> MonthTypes { get; set; }

        public DbSet<PriceType> PriceTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<RateType> RateTypes { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Factor> Factors { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<UserAddresse> UserAddresses { get; set; }

        public DbSet<Transact> Transacts { get; set; }

        public DbSet<TransactRate> TransactRates { get; set; }

    }

}
