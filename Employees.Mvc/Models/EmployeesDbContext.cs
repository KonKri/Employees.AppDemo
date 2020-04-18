using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Mvc.Models
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
