using AutoMoqCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Common.Mocks;
using CleanArchitecture.Core.Domain.Customers;

namespace CleanArchitecture.Core.Application.Customers.Queries.GetCustomerList
{
    [TestFixture]
    public class GetCustomersListQueryTests
    {
        private GetCustomersListQuery _query;
        private AutoMoqer _mocker;
        private Customer _customer;

        private const int Id = 1;
        private const string Name = "Customer 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _customer = new Customer()
            {
                Id = Id,
                Name = Name
            };

            var customersMock = CreateDbSetMock.SetUpDbSet(new List<Customer> { _customer }.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .Returns(customersMock.Object);

            _query = _mocker.Create<GetCustomersListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfCustomers()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}