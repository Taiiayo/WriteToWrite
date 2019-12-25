using Texts.Models;

namespace Texts
{
    public interface IRepositoryWrapper
    {
        IRoleRepository Role { get; }
        ITextRepository Text { get; }
        IUserRepository User { get; }
        IIdeaRepository Idea { get; }
        void Save();
    }
}
