using AutoMapper;
using Employees.WebApi.Models;
using Employees.WebApi.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.WebApi.Extensions
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Employee, NewOrUpdateEmployeeVM>().ReverseMap();
        }
    }
}
