using Entities.Db;
using Texts.Models;

namespace Repository.Models
{
    public class TextRepository : RepositoryBase<Text>, ITextRepository
    {
        public TextRepository(ToWriteDbContext toWriteDbContext) : base(toWriteDbContext)
        {

        }
    }
}
