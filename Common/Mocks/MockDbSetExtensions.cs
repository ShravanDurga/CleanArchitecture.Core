using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Common.Mocks
{
    public static class MockDbSetExtensions
    {
        public static void SetUpDbSet<T>(this Mock<DbSet<T>> mock, IList<T> list)
            where T : class
        {
            var queryable = list.AsQueryable();

            mock.As<IQueryable<T>>().Setup(p => p.GetEnumerator()).Returns(queryable.GetEnumerator());

            mock.As<IQueryable<T>>().Setup(p => p.Provider).Returns(queryable.Provider);

            mock.As<IQueryable<T>>().Setup(p => p.Expression).Returns(queryable.Expression);

            mock.As<IQueryable<T>>().Setup(p => p.ElementType).Returns(queryable.ElementType);

               
        }
    }
}
