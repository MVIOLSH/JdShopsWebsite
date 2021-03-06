using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdShopsWebsite.Shared
{
    public class DashboardAnnouncment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }

    }
}
