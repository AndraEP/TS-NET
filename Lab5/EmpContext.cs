using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class EmpContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmpContext() : base("name=ModelSelfReferences")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
            .Map<FullTimeEmp>(m => m.Requires("EmployeeType")
            .HasValue(1))
            .Map<HourlyEmp>(m => m.Requires("EmployeeType")
            .HasValue(2));
        }

    }
}
