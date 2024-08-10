using AutoMapper;
using MVC_project.PL.ViewModels;
using MVC_Project.DAL.Models;

namespace MVC_project.PL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel,Employee>().ReverseMap();
           CreateMap<DepartmentViewModel,Department>().ReverseMap();
            
        }
    }

  
}
