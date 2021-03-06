﻿using System.Collections.Generic;

namespace BlogSampleV2.Domain.Enteties
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
