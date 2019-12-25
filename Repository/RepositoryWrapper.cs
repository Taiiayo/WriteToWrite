using Entities.Db;
using Repository.Models;
using Texts;
using Texts.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ToWriteDbContext _toWriteDbContext;
        private IUserRepository _user;
        private IIdeaRepository _idea;
        private IRoleRepository _role;
        private ITextRepository _text;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_toWriteDbContext);
                }

                return _user;
            }
        }

        public IIdeaRepository Idea
        {
            get
            {
                if (_idea == null)
                {
                    _idea = new IdeaRepository(_toWriteDbContext);
                }

                return _idea;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_toWriteDbContext);
                }

                return _role;
            }
        }

        public ITextRepository Text
        {
            get
            {
                if (_text == null)
                {
                    _text = new TextRepository(_toWriteDbContext);
                }

                return _text;
            }
        }

        public RepositoryWrapper(ToWriteDbContext toWriteDbContext)
        {
            _toWriteDbContext = toWriteDbContext;
        }

        public void Save()
        {
            _toWriteDbContext.SaveChanges();
        }
    }
}
