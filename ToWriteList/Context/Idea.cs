using System.ComponentModel.DataAnnotations;

namespace ToWriteList.Context
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string IdeaBlock { get; set; }
    }
}
