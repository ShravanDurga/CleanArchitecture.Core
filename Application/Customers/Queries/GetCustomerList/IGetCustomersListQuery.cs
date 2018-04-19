using System.Collections.Generic;

namespace CleanArchitecture.Core.Application.Customers.Queries.GetCustomerList
{
    public interface IGetCustomersListQuery
    {
        List<CustomerModel> Execute();
    }
}
