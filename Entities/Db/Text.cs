using System.ComponentModel.DataAnnotations;

namespace Entities.Db
{
    public class Text
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string TextBlock { get; set; }
    }
}
