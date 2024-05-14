namespace API.DTO
{
    public class PostDTO
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public int UserId { get; set; }

    }
}