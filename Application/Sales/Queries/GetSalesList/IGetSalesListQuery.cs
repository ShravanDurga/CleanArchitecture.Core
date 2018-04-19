using System.Collections.Generic;

namespace CleanArchitecture.Core.Application.Sales.Queries.GetSalesList
{
    public interface IGetSalesListQuery
    {
        List<SalesListItemModel> Execute();
    }
}