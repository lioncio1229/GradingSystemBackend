using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Configurations
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<SubjectDTO, Subject>();
        }
    }
}
