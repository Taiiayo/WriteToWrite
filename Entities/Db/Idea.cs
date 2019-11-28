using System.ComponentModel.DataAnnotations;

namespace Entities.Db
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string IdeaBlock { get; set; }
    }
}
