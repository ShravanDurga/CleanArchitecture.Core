using CleanArchitecture.Core.Application.Employees.Queries.GetEmployeesList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Admin.Employees
{
    public class EmployeesController : Controller
    {
        private readonly IGetEmployeesListQuery _query;

        public EmployeesController(IGetEmployeesListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var employees = _query.Execute();

            return View(employees);
        }
    }
}