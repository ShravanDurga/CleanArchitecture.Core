using CleanArchitecture.Core.Domain.Customers;
using CleanArchitecture.Core.Domain.Employees;
using CleanArchitecture.Core.Domain.Products;
using CleanArchitecture.Core.Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Core.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Sale> Sales { get; set; }

        void Save();
    }
}
