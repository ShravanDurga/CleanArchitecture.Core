using AutoMoqCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Common.Mocks;
using CleanArchitecture.Core.Domain.Employees;

namespace CleanArchitecture.Core.Application.Employees.Queries.GetEmployeesList
{
    [TestFixture]
    public class GetEmployeesListQueryTests
    {
        private GetEmployeesListQuery _query;
        private AutoMoqer _mocker;
        private Employee _employee;

        private const int Id = 1;
        private const string Name = "Employee 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _employee = new Employee()
            {
                Id = Id,
                Name = Name
            };

            var employeeMock = CreateDbSetMock.SetUpDbSet(new List<Employee> { _employee }.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .Returns(employeeMock.Object);

            _query = _mocker.Create<GetEmployeesListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfEmployees()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}