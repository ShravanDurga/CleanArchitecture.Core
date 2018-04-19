using AutoMoqCore;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Common.Mocks;
using CleanArchitecture.Core.Domain.Customers;
using CleanArchitecture.Core.Domain.Employees;
using CleanArchitecture.Core.Domain.Products;
using CleanArchitecture.Core.Domain.Sales;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Application.Sales.Queries.GetSalesList
{
    [TestFixture]
    public class GetSalesListQueryTests
    {
        private GetSalesListQuery _query;
        private AutoMoqer _mocker;
        private Sale _sale;

        private const int SaleId = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const string CustomerName = "Customer 1";
        private const string EmployeeName = "Employee 1";
        private const string ProductName = "Product 1";
        private const decimal UnitPrice = 1.23m;
        private const int Quantity = 2;
        private const decimal TotalPrice = 2.46m;

        [SetUp]
        public void SetUp()
        {
            var customer = new Customer
            {
                Name = CustomerName
            };

            var employee = new Employee
            {
                Name = EmployeeName
            };

            var product = new Product
            {
                Name = ProductName
            };

            _sale = new Sale()
            {
                Id = SaleId,
                Date = Date,
                Customer = customer,
                Employee = employee,
                Product = product,
                UnitPrice = UnitPrice,
                Quantity = Quantity
            };

            var saleMock = CreateDbSetMock.SetUpDbSet(new List<Sale> { _sale }.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Sales)
                .Returns(saleMock.Object);

            _query = _mocker.Create<GetSalesListQuery>();
        }

        //[Test]
        //public void TestExecuteShouldReturnListOfSales()
        //{
        //    var saleMock = CreateDbSetMock.SetUpDbSet(new List<Sale> { _sale }.AsQueryable());

        //    _mocker.GetMock<IDatabaseService>()
        //        .Setup(p => p.Sales)
        //        .Returns(saleMock.Object);

        //   // _query = _mocker.Create<GetSalesListQuery>();

        //    var results = _query.Execute();

        //    var result = results.Single();

        //    Assert.That(result.Id,
        //        Is.EqualTo(SaleId));

        //    Assert.That(result.Date,
        //        Is.EqualTo(Date));

        //    Assert.That(result.CustomerName,
        //        Is.EqualTo(CustomerName));

        //    Assert.That(result.EmployeeName,
        //        Is.EqualTo(EmployeeName));

        //    Assert.That(result.ProductName,
        //        Is.EqualTo(ProductName));

        //    Assert.That(result.UnitPrice,
        //        Is.EqualTo(UnitPrice));

        //    Assert.That(result.Quantity,
        //        Is.EqualTo(Quantity));

        //    Assert.That(result.TotalPrice,
        //        Is.EqualTo(TotalPrice));
        //}
    }
}