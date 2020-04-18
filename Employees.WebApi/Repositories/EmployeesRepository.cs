using Employees.WebApi.Models;
using Employees.WebApi.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.WebApi.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeesDbContext _db;

        public EmployeesRepository(EmployeesDbContext db)
        {
            _db = db;
        }

        public List<EmployeeSummarizedVM> GetAllEmployees()
        {
            return _db.Employees
                .Select(s => new EmployeeSummarizedVM(s.Id, s.FirstName, s.LastName, s.Specialty))
                .ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _db.Employees.Where(w => w.Id == id).FirstOrDefault();
        }

        public Guid CreateEmployee(Employee newEmployee)
        {
            _db.Employees.Add(newEmployee);
            _db.SaveChanges();
            return newEmployee.Id;
        }

        public int UpdateEmployee(Employee updatedEmployee)
        {
            _db.Employees.Update(updatedEmployee);
            return _db.SaveChanges();
        }

        public void DeleteEmployee(Guid id)
        {   
            var employeeToDelete = new Employee(id);
            _db.Employees.Remove(employeeToDelete);
            _db.SaveChanges();
        }

        public bool EmployeeExists(Guid id)
        {
            return _db.Employees.Where(w => w.Id == id).Any();
        }
    }
}