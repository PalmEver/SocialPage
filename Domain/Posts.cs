using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Posts
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}