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
    }
}
