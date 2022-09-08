using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TestApp1.Domain.Entity;
using TestApp1.Service;

namespace TestApp1.Domain
{
    public class UserManagmentDbContext : IdentityDbContext<IdentityUser>
    {
        public UserManagmentDbContext() { }
        public UserManagmentDbContext(DbContextOptions<UserManagmentDbContext> options) : base(options) { }

        public virtual DbSet<UserStatistic> UserStatistic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserStatistic>().HasData(new UserStatistic
            {
                Id = 1,
                IdentityUser = new Guid("764964a8-ce84-46fb-80d4-449082f465e4"),
                PeriodFrom = new DateTime(2022, 04, 24, 9, 00, 00),
                PeriodTo = new DateTime(2022, 04, 24, 10, 00, 00)
            });

            modelBuilder.Entity<UserStatistic>().HasData(new UserStatistic
            {
                Id = 2,
                IdentityUser = new Guid("764964a8-ce84-46fb-80d4-449082f465e4"),
                PeriodFrom = new DateTime(2022, 05, 24, 11, 00, 00),
                PeriodTo = new DateTime(2022, 05, 24, 12, 00, 00)
            });

            modelBuilder.Entity<UserStatistic>().HasData(new UserStatistic
            {
                Id = 3,
                IdentityUser = new Guid("764964a8-ce84-46fb-80d4-449082f465e4"),
                PeriodFrom = new DateTime(2022, 04, 24, 14, 00, 00),
                PeriodTo = new DateTime(2022, 04, 24, 15, 00, 00)
            });

            modelBuilder.Entity<UserStatistic>().HasData(new UserStatistic
            {
                Id = 4,
                IdentityUser = new Guid("764964a8-ce84-46fb-80d4-449082f465e4"),
                PeriodFrom = new DateTime(2022, 04, 24, 16, 00, 00),
                PeriodTo = new DateTime(2022, 04, 24, 17, 00, 00)
            });
        }
    }
}
