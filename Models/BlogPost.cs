using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JayAns.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public System.DateTimeOffset Created { get; set; }
        public Nullable<System.DateTimeOffset> Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Blog { get; set; }
        public string MediaUrl { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class BlogPostDBContext : DbContext
    {
        public DbSet<BlogPost> BlogPost { get; set; }
    }
}