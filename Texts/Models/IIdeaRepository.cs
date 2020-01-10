using Entities.Db;
using System.Collections.Generic;
using System.Linq;

namespace Texts.Models
{
    public interface IIdeaRepository : IRepositoryBase<Idea>
    {
        Idea TakeRandom();
    }
}
