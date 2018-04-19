using CleanArchitecture.Core.Domain.Customers;
using CleanArchitecture.Core.Domain.Employees;
using CleanArchitecture.Core.Domain.Products;
using CleanArchitecture.Core.Domain.Sales;
using System;

namespace CleanArchitecture.Core.Application.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
        Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity);
    }
}