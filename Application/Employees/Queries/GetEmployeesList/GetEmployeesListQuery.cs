using CleanArchitecture.Core.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IGetEmployeesListQuery
    {
        private readonly IDatabaseService _database;

        public GetEmployeesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<EmployeeModel> Execute()
        {
            var employees = _database.Employees
                .Select(p => new EmployeeModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return employees.ToList();
        }
    }
}