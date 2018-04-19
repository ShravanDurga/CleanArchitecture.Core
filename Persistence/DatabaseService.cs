using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Domain.Customers;
using CleanArchitecture.Core.Domain.Employees;
using CleanArchitecture.Core.Domain.Products;
using CleanArchitecture.Core.Domain.Sales;
using CleanArchitecture.Core.Persistence.Customers;
using CleanArchitecture.Core.Persistence.Employees;
using CleanArchitecture.Core.Persistence.Products;
using CleanArchitecture.Core.Persistence.Sales;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Core.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {

        }

        public void Save()
        {
            this.SaveChanges();
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new SaleConfiguration());
        }
    }
}
