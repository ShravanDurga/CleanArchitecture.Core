using System.Collections.Generic;

namespace CleanArchitecture.Core.Application.Employees.Queries.GetEmployeesList
{
    public interface IGetEmployeesListQuery
    {
        List<EmployeeModel> Execute();
    }
}