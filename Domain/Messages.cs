using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Messages
    {
        public Guid Id { get; set; }
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}