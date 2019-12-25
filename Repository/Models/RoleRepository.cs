using Entities.Db;
using Texts.Models;

namespace Repository.Models
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ToWriteDbContext toWriteDbContext) : base(toWriteDbContext)
        {

        }
    }
}
