using Entities.Db;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Texts.Models
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IQueryable<User> Include<T>(Expression<Func<User, object>> criteria);
    }
}
