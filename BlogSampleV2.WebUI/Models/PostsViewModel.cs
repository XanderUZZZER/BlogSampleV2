using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSampleV2.WebUI.Models
{
    public abstract class PostsViewModel
    {
        public PagingInfo PagingInfo { get; set; }
    }
}