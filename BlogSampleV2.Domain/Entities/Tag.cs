using System.Collections.Generic;

namespace BlogSampleV2.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
