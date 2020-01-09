using Entities.Db;

namespace Texts.Models
{
    public interface IIdeaRepository : IRepositoryBase<Idea>
    {
        int Count<T>();
    }
}
