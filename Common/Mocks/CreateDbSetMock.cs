using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Common.Mocks
{
    public static class CreateDbSetMock
    {
        public static Mock<DbSet<T>> SetUpDbSet<T>(IQueryable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();

            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);

            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);

            return dbSetMock;
        }

        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
            this IReturns<TContext, DbSet<TEntity>> setup,
            TEntity[] entities)
        where TEntity : class
        where TContext : DbContext
        {
            var mockSet = SetUpDbSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }

        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IQueryable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            var mockSet = SetUpDbSet(entities);
            return setup.Returns(mockSet.Object);
        }

        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IEnumerable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            var mockSet = SetUpDbSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }
    }
}
