using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Configurations
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<SubjectDTO, Subject>();
            CreateMap<Subject, SubjectResponse>();

            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentResponse>()
                .ForMember(d => d.Strand, o => o.MapFrom(s => s.Strand != null ? s.Strand.Description : ""))
                .ForMember(d => d.YearLevel, o => o.MapFrom(s => s.YearLevel != null ? s.YearLevel.Name : ""))
                .ForMember(d => d.Semester, o => o.MapFrom(s => s.Semester != null ? s.Semester.Name : ""));

            CreateMap<GradesUpdateDTO, Grade>();

            CreateMap<LectureDTO, Lecture>();
            CreateMap<Lecture, LectureResponse>();
        }
    }
}
