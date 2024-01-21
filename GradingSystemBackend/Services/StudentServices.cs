using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = _unitOfWork.StudentRepository;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> AddStudent(StudentDTO studentDTO)
        {
            var student = await _studentRepository.AddAsync(_mapper.Map<Student>(studentDTO));

            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync(
                o => o.StrandCode == studentDTO.StrandCode &&
                o.YearLevelKey == studentDTO.YearLevelKey &&
                o.SemesterKey == studentDTO.SemesterKey);

            var grades = subjects.Select(o => new Grade
            {
                Average = 0,
                Q1 = 0,
                Q2 = 0,
                Q3 = 0,
                Q4 = 0,
                Remarks = "",
                StudentId = student.Id,
                SubjectId = o.Id
            });

            _unitOfWork.GradeRepository.AddRange(grades);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "New Student Created",
                Success = true
            };
        }

        public IEnumerable<StudentResponse> GetStudents()
        {
            return _mapper.Map<IEnumerable<StudentResponse>>(_studentRepository.GetAll(o => o.Strand, o => o.YearLevel, o => o.Semester));
        }

        public async Task<StudentResponse> GetStudent(Guid id)
        {
            return _mapper.Map<StudentResponse>(await _studentRepository.Get(o => o.Id == id, o => o.Strand, o => o.YearLevel, o => o.Semester));
        }

        public async Task<DefaultResponse> UpdateStudent (Guid id, StudentDTO studentDTO)
        {
            var updatedStudent = _mapper.Map<Student>(studentDTO);
            updatedStudent.Id = id;

            _studentRepository.UpdateAsync(updatedStudent);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Student updated",
                Success = true
            };
        }

        public async Task<DefaultResponse> DeleteStudent(Guid id)
        {
            var student = await _studentRepository.Get(o => o.Id == id);
            if (student == null)
                throw new NotFoundException("Student not found");

            _studentRepository.Delete(student);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Student deleted",
                Success = true
            };
        }
    }
}
