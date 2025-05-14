using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using MyBlog.Service.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Db.EF
{
    public class EFRepository<T> : RepositoryBase<T>, IRepository<T>, IReadRepository<T>
        where T : class, IAggregateRoot
    {
        public EFRepository(MyBlogContext dbContext) : base(dbContext)
        {

        }

        #region Obsoleted

        [Obsolete]
        public override Task<T?> GetBySpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            throw new Exception("Obsoleted");
        }

        [Obsolete]
        public override Task<TResult?> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            throw new Exception("Obsoleted");
        }

        #endregion

    }
}
