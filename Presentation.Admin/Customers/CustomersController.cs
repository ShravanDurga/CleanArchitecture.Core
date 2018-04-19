using CleanArchitecture.Core.Application.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Core.Presentation.Admin.Customers
{
    public class CustomersController : Controller
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var customers = _query.Execute();

            return View(customers);
        }
    }
}