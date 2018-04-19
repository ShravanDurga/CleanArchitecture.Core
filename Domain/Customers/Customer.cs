using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Core.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
