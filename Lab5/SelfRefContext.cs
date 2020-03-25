using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class SelfRefContext : DbContext
    {
        public DbSet<SelfReference> SelfReferences { get; set; }
        public SelfRefContext() : base("name=ModelSelfReferences")
        { }
    }
}
