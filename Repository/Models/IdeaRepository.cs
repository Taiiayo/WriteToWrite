using Entities.Db;
using Texts;
using Texts.Models;

namespace Repository.Models
{
    public class IdeaRepository : RepositoryBase<Idea>, IIdeaRepository
    {
        public IdeaRepository(ToWriteDbContext toWriteDbContext) : base(toWriteDbContext)
        {

        }
    }
}
