using CleanArchitecture.Core.Domain.Customers;
using CleanArchitecture.Core.Domain.Employees;
using CleanArchitecture.Core.Domain.Products;
using CleanArchitecture.Core.Domain.Sales;
using System;

namespace CleanArchitecture.Core.Application.Sales.Commands.CreateSale.Factory
{
    public class SaleFactory : ISaleFactory
    {
        public Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
        {
            var sale = new Sale();

            sale.Date = date;

            sale.Customer = customer;

            sale.Employee = employee;

            sale.Product = product;

            sale.UnitPrice = sale.Product.Price;

            sale.Quantity = quantity;

            // Note: Total price is calculated in domain logic

            return sale;
        }
    }
}