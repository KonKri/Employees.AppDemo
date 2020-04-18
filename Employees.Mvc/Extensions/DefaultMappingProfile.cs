using AutoMapper;
using Employees.Mvc.Models;
using Employees.Mvc.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Mvc.Extensions
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Employee, NewOrUpdateEmployeeVM>().ReverseMap();
        }
    }
}
