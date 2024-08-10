using System.Collections.Generic;

namespace EntityFrameworkUppgift.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
