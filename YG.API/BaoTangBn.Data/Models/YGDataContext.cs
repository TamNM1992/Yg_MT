using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Models;

namespace YG.Data.Models
{
    public class YGDataContext : DbContext
    {
        public YGDataContext(DbContextOptions options)
             : base(options)
        {
                
        }
        
        public DbSet<Monter> Monter { get; set; }
        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<Type> Type { get; set; }

    }
}
