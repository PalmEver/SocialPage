namespace API.DTO
{
    public class FollowDto
    {
        public Guid Id { get; set; }
        public int FollowId { get; set; }

        public int UserId { get; set; }
    }
}