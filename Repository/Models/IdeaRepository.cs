using Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using Texts.Models;

namespace Repository.Models
{
    public class IdeaRepository : RepositoryBase<Idea>, IIdeaRepository
    {
        Random random = new Random();
        public IdeaRepository(ToWriteDbContext toWriteDbContext) : base(toWriteDbContext)
        {

        }

        public Idea TakeRandom()
        {
            return ToWriteDbContext.Ideas.ElementAt(random.Next(ToWriteDbContext.Ideas.Count()));
        }
    }
}
