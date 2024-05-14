using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Followers
    {
        public Guid Id { get; set; }
        public int FollowId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}