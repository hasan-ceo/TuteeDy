using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.Domain.Entities;

namespace Wps.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<NewsPaper> NewsPapers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SyllableSounds> SyllableSounds { get; set; }
        public DbSet<WordUser> WordUsers { get; set; }
    }
}
