using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Mvc.View_Models
{
    public class EmployeeSummarizedVM
    {  
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }

        public EmployeeSummarizedVM(Guid id, string firstName, string lastName, string specialty)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
        }
    }
}
