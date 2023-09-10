using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xlogia.Domain.Abstract;
using Xlogia.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Xlogia.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        public EFEmployeeRepository(EFDbContext context)
        {
            _context = context;
        }
        private EFDbContext _context = new EFDbContext();

        public IQueryable<Employee> Employees
        {
            get
            {
                return _context.Employees;
            }
        }

        public void Save(Employee employee)
        {
            _context.Employees.AddOrUpdate(employee);
            _context.SaveChanges();
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.ID == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return employee;
        }
    }
}
