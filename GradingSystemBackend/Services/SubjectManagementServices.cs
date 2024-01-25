using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class SubjectManagementServices : ISubjectManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> AddSubject(SubjectDTO subjectDTO)
        {
            var subject = await _unitOfWork.SubjectRepository.AddAsync(_mapper.Map<Subject>(subjectDTO));

            var students = await _unitOfWork.StudentRepository.GetAllAsync(o => 
            o.StrandCode == subjectDTO.StrandCode &&
            o.YearLevelKey == subjectDTO.YearLevelKey &&
            o.SemesterKey == subjectDTO.SemesterKey);

            var grades = students.Select(o => new Grade
            {
                Q1 = 0,
                Q2 = 0,
                Q3 = 0,
                Q4 = 0,
                Average = 0,
                Remarks = "",
                SubjectId = subject.Id,
                StudentId = o.Id
            });

            _unitOfWork.GradeRepository.AddRange(grades);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Subject Created",
                Success = true
            };
        }

        public DefaultResponse UpdateSubject(Guid id, SubjectDTO subjectDTO)
        {
            var subject = _mapper.Map<Subject>(subjectDTO);
            subject.Id = id;

            _unitOfWork.SubjectRepository.UpdateAsync(subject);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Subject Updated",
                Success = true
            };
        }

        public IEnumerable<SubjectResponse> GetAllSubjects()
        {
            return _mapper.Map<IEnumerable<SubjectResponse>>(_unitOfWork.SubjectRepository
                .GetAll(o => o.Faculty, o => o.YearLevel, o => o.Semester, o => o.Strand).ToList());
        }

        public IEnumerable<SubjectResponse> GetAllSubjects(FilterDTO filterDTO)
        {
            var subjects = _unitOfWork.SubjectRepository.Query(o => o.YearLevelKey == filterDTO.YearLevel
            && o.SemesterKey == filterDTO.Semester
            && o.StrandCode == filterDTO.Strand, c => c.YearLevel, c => c.Semester, c => c.Strand, c => c.Faculty).ToList();

            return _mapper.Map<IEnumerable<SubjectResponse>>(subjects);
        }

        public async Task<SubjectResponse> GetSubject(Guid id)
        {
            var subject = await _unitOfWork.SubjectRepository
                .Get(o => o.Id == id, o => o.Faculty, o => o.YearLevel, o => o.Semester, o => o.Strand);

            return _mapper.Map<SubjectResponse>(subject);
        }

        public async Task<DefaultResponse> DeleteSubject(Guid id)
        {
            var subject = await _unitOfWork.SubjectRepository.Get(o => o.Id == id);
            if (subject == null)
                throw new NotFoundException("Subject not found");

            _unitOfWork.SubjectRepository.Delete(subject);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Subject Deleted Successfully",
                Success = true
            };
        }
    }
}
