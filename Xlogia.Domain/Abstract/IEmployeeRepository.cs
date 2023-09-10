using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xlogia.Domain.Entities;

namespace Xlogia.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }
        void Save(Employee employee);        Employee Delete(int id);    }
}
