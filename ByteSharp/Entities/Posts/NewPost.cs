using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSharp.Entities.Posts
{
    public class NewPost
    {
        public Package package { get; set; }

        public string caption { get; set; }

        public string name { get; set; }

        public string thumbnailUrl { get; set; }

        public bool return_inflated_post { get; set; }
    }
}
