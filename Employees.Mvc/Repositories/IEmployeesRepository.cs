using Employees.Mvc.Models;
using Employees.Mvc.View_Models;
using System;
using System.Collections.Generic;

namespace Employees.Mvc.Repositories
{
    public interface IEmployeesRepository
    {
        Guid CreateEmployee(Employee newEmployee);
        void DeleteEmployee(Guid id);
        bool EmployeeExists(Guid id);
        List<EmployeeSummarizedVM> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        int UpdateEmployee(Employee updatedEmployee);
    }
}