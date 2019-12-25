using Entities.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Texts.Models;

namespace Repository.Models
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ToWriteDbContext toWriteDbContext) : base(toWriteDbContext)
        {            
        }
        public IQueryable<User> Include<T>(Expression<Func<User, object>> criteria)
        {
            return ToWriteDbContext.Set<User>().Include(criteria);
        }
    }
}
