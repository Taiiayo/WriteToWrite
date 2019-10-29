using System.ComponentModel.DataAnnotations;

namespace ToWriteList.Context
{
    public class Text
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string TextBlock { get; set; }
    }
}
