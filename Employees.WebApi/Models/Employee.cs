using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.WebApi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialty { get; set; }

        public Employee(Guid id)
        {
            Id = id;
        }

        public Employee()
        {

        }
    }
}