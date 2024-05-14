namespace API.DTO
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public int MessageId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public int UserId { get; set; }
    }
}