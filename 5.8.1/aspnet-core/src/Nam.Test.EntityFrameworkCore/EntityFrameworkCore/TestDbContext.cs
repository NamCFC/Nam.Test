using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Nam.Test.Authorization.Roles;
using Nam.Test.Authorization.Users;
using Nam.Test.MultiTenancy;
using Nam.Test.Entities;

namespace Nam.Test.EntityFrameworkCore
{
    public class TestDbContext : AbpZeroDbContext<Tenant, Role, User, TestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }
    }
}
