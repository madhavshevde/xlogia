using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xlogia.Domain.Abstract;
using Xlogia.Domain.Entities;
using System.Linq;
using Xlogia.Controllers;

namespace Xlogia.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTests
    {
        [TestMethod]
        public void ListHaveAllEmployees()
        {
            // Arrange 
            Mock<IEmployeeRepository> mock = GetEmployeeRepository();

            // Act
            EmployeeController employeeController = new EmployeeController(mock.Object);
            Employee[] result = ((IQueryable<Employee>)employeeController.List().ViewData.Model).ToArray();

            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual("Employee1", result[0].Name);
            Assert.AreEqual("Employee2", result[1].Name);
        }

        [TestMethod]
        public void CanEditEmployee()
        {
            // Arrange
            Mock<IEmployeeRepository> mock = GetEmployeeRepository();

            // Act
            EmployeeController employeeController = new EmployeeController(mock.Object);
            Employee employee1 = ((Employee)employeeController.Edit(1).ViewData.Model);
            Employee employee2 = ((Employee)employeeController.Edit(2).ViewData.Model);

            // Assert
            // Assert
            Assert.AreEqual(1, employee1.ID);
            Assert.AreEqual(2, employee2.ID);
        }

        [TestMethod]
        public void CanDeleteEmployee()
        {
            // Arrange
            Mock<IEmployeeRepository> mock = GetEmployeeRepository();

            // Act
            EmployeeController employeeController = new EmployeeController(mock.Object);
            employeeController.Delete(1);

            // Assert
            mock.Verify(m => m.Delete(1));

        }

        private Mock<IEmployeeRepository> GetEmployeeRepository()
        {
            Mock<IEmployeeRepository> repo = new Mock<IEmployeeRepository>();
            List<Employee> list = new List<Employee> {
                new Employee { ID = 1, Name = "Employee1", Email = "employee1@gmail.com", Age=25},
                new Employee { ID = 2, Name = "Employee2", Email = "employee2@gmail.com", Age=24 },
                };
            repo.Setup(r => r.Employees).Returns(list.AsQueryable());

            return repo;
        }
    }
}
