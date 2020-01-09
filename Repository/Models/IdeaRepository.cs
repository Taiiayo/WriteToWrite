using Entities.Db;
using System.Linq;
using Texts.Models;

namespace Repository.Models
{
    public class IdeaRepository : RepositoryBase<Idea>, IIdeaRepository
    {
        public IdeaRepository(ToWriteDbContext toWriteDbContext) : base(toWriteDbContext)
        {

        }

        public int Count<T>()
        {
            return ToWriteDbContext.Ideas.Count();
        }
    }
}
