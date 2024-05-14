using System.Text.Json.Serialization;
using Domain;

namespace API.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        [JsonIgnore] public string Password { get; set; }

        public ICollection<Posts> Posts { get; set; }
        public ICollection<Followers> Followers { get; set; }
    }
}