using System.Collections.Generic;

namespace BlogSampleV2.Domain.Enteties
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public virtual ICollection<BlogUser> Users { get; set; }
    }
}
