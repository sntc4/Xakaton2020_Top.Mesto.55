using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XakatonIT.Models
{
    public class XakatonITContext : DbContext
    {
        public XakatonITContext (DbContextOptions<XakatonITContext> options)
            : base(options)
        {
        }

        public DbSet<XakatonIT.Models.Parks> Parks { get; set; }
    }
}
