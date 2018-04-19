using AutoMoqCore;
using CleanArchitecture.Core.Application.Employees.Queries.GetEmployeesList;
using NUnit.Framework;
using Presentation.Admin.Employees;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Presentation.Admin.Employees
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private EmployeesController _controller;
        private AutoMoqer _mocker;
        private EmployeeModel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new EmployeeModel();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IGetEmployeesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<EmployeeModel> { _model });

            _controller = _mocker.Create<EmployeesController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfCustomers()
        {
            var viewResult = _controller.Index();

            var result = (List<EmployeeModel>)viewResult.Model;

            Assert.That(result.Single(), Is.EqualTo(_model));
        }
    }
}