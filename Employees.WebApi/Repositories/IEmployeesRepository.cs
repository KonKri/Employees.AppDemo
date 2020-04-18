using Employees.WebApi.Models;
using Employees.WebApi.View_Models;
using System;
using System.Collections.Generic;

namespace Employees.WebApi.Repositories
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