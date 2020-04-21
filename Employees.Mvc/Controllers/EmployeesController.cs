using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Mvc.Models;
using Employees.Mvc.Repositories;
using Employees.Mvc.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Mvc.Controllers.MVC
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _repo;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// return a summarized list of all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Employees")]
        public ActionResult ListSummarized()
        {
            // get all employees summarized.
            var employees = _repo.GetAllEmployees();

            return View(employees);
        }

        [HttpGet]
        [Route("Employees/Details/{id}")]
        public ActionResult Details([FromRoute] Guid id)
        {
            // get employee's obj.
            var employeeDetails = _repo.GetEmployeeById(id);
            return View(employeeDetails);
        }

        [HttpGet]
        [Route("Employees/Create")]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Route("Employees/Create")]
        public ActionResult Create([FromForm] NewOrUpdateEmployeeVM newEmployeeVM)
        {
            try
            {
                // map vm to employee.
                var newEmployee = _mapper.Map<Employee>(newEmployeeVM);

                // create employee.
                _repo.CreateEmployee(newEmployee);

                // set temp data -> new employee created.
                TempData["NewEmployeeCreatedFullName"] = $"{newEmployee.FirstName} {newEmployee.LastName}";

                // redirect to main view
                return RedirectToAction(nameof(ListSummarized));
            }
            catch
            {
                return View();
            }
        }

        [Route("Employees/Delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                // delete employee by id.
                _repo.DeleteEmployee(id);

                // set temp data -> employee removed.
                TempData["DeletedEmployeeId"] = id.ToString();

                return RedirectToAction(nameof(ListSummarized));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Employees/Edit/{id}")]
        public ActionResult Edit([FromRoute] Guid id)
        {
            // get employee's obj.
            var employeeDetails = _repo.GetEmployeeById(id);
            return View(employeeDetails);
        }

        [HttpPost]
        [Route("Employees/Edit/{id}")]
        public ActionResult Edit([FromRoute] Guid id, [FromForm] NewOrUpdateEmployeeVM updatedEmployeeVM)
        {
            try
            {
                var updatedEmployee = _mapper.Map<Employee>(updatedEmployeeVM);
                updatedEmployee.Id = id;
                _repo.UpdateEmployee(updatedEmployee);

                // set temp data -> employee removed.
                TempData["UpdatedEmployeeId"] = id.ToString();

                return RedirectToAction(nameof(ListSummarized));
            }
            catch
            {
                return View();
            }
        }
        
    }
}