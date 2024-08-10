using System.Collections.Generic;

namespace EntityFrameworkUppgift.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PostId { get; set; } 
        public ICollection<Post> Posts { get; set; }
    }
}
