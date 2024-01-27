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
            CreateMap<Student, StudentResponse>();

            CreateMap<GradesUpdateDTO, Grade>();

            CreateMap<LectureDTO, Lecture>();
            CreateMap<Lecture, LectureResponse>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserResponse>();
            CreateMap<User, UserData>();

            CreateMap<Role, RoleResponse>();

            CreateMap<Semester, SemesterResponse>();
            CreateMap<Strand, StrandResponse>();
            CreateMap<YearLevel, YearLevelResponse>();

            CreateMap<Grade, StudentGradeResponse>();
        }
    }
}
