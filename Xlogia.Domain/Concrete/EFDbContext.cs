using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xlogia.Domain.Entities;

namespace Xlogia.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() :  base("EFDbContext")
        {
            Database.SetInitializer<EFDbContext>(new XlogiaDatabaseInitialize());
            Database.Initialize(true);
        }
        public DbSet<Employee> Employees { get; set; }
    }

    public class XlogiaDatabaseInitialize  : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            Initialize(context);
            base.Seed(context);
        }

        private void Initialize(EFDbContext context)
        {
            Employee employee = new Employee();
            employee.Name = "Test Employee";
            employee.Age = 23;
            employee.Email = "test@gmail.com";
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
}
