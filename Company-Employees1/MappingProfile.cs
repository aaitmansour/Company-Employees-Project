using AutoMapper;
using Entities.Modeles;
using Shared.DataTransferObject;

namespace Company_Employees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.fulladresse,
                    opt => opt.MapFrom(x => string.Join(' ', x.adresse, x.country)));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<CompanyForUpdateDto, Company>();
        }
    }
}
