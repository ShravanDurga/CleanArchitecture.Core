using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Core.Domain.Employees
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}