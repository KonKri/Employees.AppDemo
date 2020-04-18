using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employees.WebApi.Models;
using Employees.WebApi.Repositories;
using Employees.WebApi.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _repo;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all employees list summarized.
        /// </summary>
        /// <returns></returns>
        [Route("Employees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _repo.GetAllEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Get employee details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Employees/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById([FromRoute] Guid id)
        {
            // check if employee exists
            var employee = _repo.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="newEmployeeVM"></param>
        /// <returns></returns>
        [Route("Employees")]
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] NewOrUpdateEmployeeVM newEmployeeVM)
        {
            var newEmployee = _mapper.Map<Employee>(newEmployeeVM);
            var id = _repo.CreateEmployee(newEmployee);
            return Created($"api/Employees/{id}", id);
        }

        /// <summary>
        /// Update employee by id and body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedEmployeeVM"></param>
        /// <returns></returns>
        [Route("Employees/{id}")]
        [HttpPut]
        public IActionResult UpdateEmployee([FromRoute] Guid id, [FromBody] NewOrUpdateEmployeeVM updatedEmployeeVM)
        {
            // check if employee exists
            var employeeExists = _repo.EmployeeExists(id);

            if (!employeeExists)
                return NotFound();

            var updatedEmployee = _mapper.Map<Employee>(updatedEmployeeVM);
            updatedEmployee.Id = id;

            _repo.UpdateEmployee(updatedEmployee);
            return Accepted();
        }

        /// <summary>
        /// Remove employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Employees/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmployee([FromRoute] Guid id)
        {
            // check if employee exists
            var employeeExists = _repo.EmployeeExists(id);

            if (!employeeExists)
                return NotFound();

            _repo.DeleteEmployee(id);
            return NoContent();
        }
    }
}