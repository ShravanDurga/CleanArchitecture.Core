using AutoMoqCore;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Core.Common.Dates;
using CleanArchitecture.Core.Common.Mocks;
using CleanArchitecture.Core.Domain.Customers;
using CleanArchitecture.Core.Domain.Employees;
using CleanArchitecture.Core.Domain.Products;
using CleanArchitecture.Core.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Application.Sales.Commands.CreateSale
{
    [TestFixture]
    public class CreateSaleCommandTests
    {
        private CreateSaleCommand _command;
        private AutoMoqer _mocker;
        private CreateSaleModel _model;
        private Sale _sale;

        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const int CustomerId = 1;
        private const int EmployeeId = 2;
        private const int ProductId = 3;
        private const decimal UnitPrice = 1.23m;
        private const int Quantity = 4;

        [SetUp]
        public void SetUp()
        {
            var customer = new Customer
            {
                Id = CustomerId
            };

            var employee = new Employee
            {
                Id = EmployeeId
            };

            var product = new Product
            {
                Id = ProductId,
                Price = UnitPrice
            };

            _model = new CreateSaleModel()
            {
                CustomerId = CustomerId,
                EmployeeId = EmployeeId,
                ProductId = ProductId,
                Quantity = Quantity
            };

            _sale = new Sale();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            SetUpDbSet(p => p.Customers, customer);
            SetUpDbSet(p => p.Employees, employee);
            SetUpDbSet(p => p.Products, product);
            SetUpDbSet(p => p.Sales);

            _mocker.GetMock<ISaleFactory>()
                .Setup(p => p.Create(
                    Date,
                    customer,
                    employee,
                    product,
                    Quantity))
                .Returns(_sale);

            _command = _mocker.Create<CreateSaleCommand>();
        }

        //[Test]
        //public void TestExecuteShouldAddSaleToTheDatabase()
        //{
        //    _command.Execute(_model);

        //    _mocker.GetMock<DbSet<Sale>>()
        //        .Verify(p => p.Add(_sale),
        //            Times.Once);
        //}

        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDatabaseService>()
                .Verify(p => p.Save(),
                    Times.Once);
        }

        //[Test]
        //public void TestExecuteShouldNotifyInventoryThatSaleOccurred()
        //{
        //    _command.Execute(_model);

        //    _mocker.GetMock<IInventoryService>()
        //        .Verify(p => p.NotifySaleOcurred(
        //                ProductId,
        //                Quantity),
        //            Times.Once);
        //}

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, DbSet<T>>> property, T entity)
            where T : class
        {
            
            var createSaleMock = CreateDbSetMock.SetUpDbSet(new List<T> { entity }.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(property)
                .Returns(createSaleMock.Object);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, DbSet<T>>> property)
           where T : class
        {
            var createSaleMock = CreateDbSetMock.SetUpDbSet(new List<T> { }.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(property)
                .Returns(createSaleMock.Object);
        }
    }
}