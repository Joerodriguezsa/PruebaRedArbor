using AutoMapper;
using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.Infrastructure.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {

            CreateMap<Status, StatusConsultarDTO>().ReverseMap();
            CreateMap<StatusCrearDTO, Status>();
            CreateMap<StatusActualizarDTO, Status>();

            CreateMap<Role, RoleConsultarDTO>().ReverseMap();
            CreateMap<RoleCrearDTO, Role>();
            CreateMap<RoleActualizarDTO, Role>();

            CreateMap<Portal, PortalConsultarDTO>().ReverseMap();
            CreateMap<PortalCrearDTO, Portal>();
            CreateMap<PortalActualizarDTO, Portal>();

            CreateMap<Company, CompanyConsultarDTO>().ReverseMap();
            CreateMap<CompanyCrearDTO, Company>();
            CreateMap<CompanyActualizarDTO, Company>();

            CreateMap<Employee, EmployeeConsultarDTO>().ReverseMap();
            CreateMap<EmployeeCrearDTO, Employee>();
            CreateMap<EmployeeActualizarDTO, Employee>();
            CreateMap<EmployeeFiltrarDTO, Employee>();
        }
    }
}
