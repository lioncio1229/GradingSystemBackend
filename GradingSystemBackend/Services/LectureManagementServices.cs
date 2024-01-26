using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class LectureManagementServices : ILectureManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILectureRepository _lectureRepository;
        private readonly IMapper _mapper;

        public LectureManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _lectureRepository = unitOfWork.LectureRepository;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> AddLecture(LectureDTO lectureDTO)
        {
            await _lectureRepository.AddAsync(_mapper.Map<Lecture>(lectureDTO));
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Lecture added",
                Success = true,
            };
        }

        public IEnumerable<LectureResponse> GetAllLecture()
        {
            return _mapper.Map<IEnumerable<LectureResponse>>(_lectureRepository.GetAll(o => o.Subject, 
                o => o.Subject.YearLevel, o => o.Subject.Strand, o => o.Subject.Semester));
        }

        public IEnumerable<LectureResponse> GetAllLecture(FilterDTO filterDTO)
        {
            var lectures = _lectureRepository.Query(o => o.Subject.YearLevelKey == filterDTO.YearLevel
            && o.Subject.SemesterKey == filterDTO.Semester && o.Subject.StrandCode == filterDTO.Strand, 
            o => o.Subject, o => o.Subject.YearLevel, o => o.Subject.Strand, o => o.Subject.Semester);

            return _mapper.Map<IEnumerable<LectureResponse>>(lectures);
        }

        public async Task<LectureResponse> GetLecture(Guid id)
        {
            return _mapper.Map<LectureResponse>(await _lectureRepository.Get(o => o.Id == id, o => o.Subject, 
                o => o.Subject.YearLevel, o => o.Subject.Strand, o => o.Subject.Semester));
        }

        public async Task<DefaultResponse> UpdateLecture(Guid id, LectureDTO lectureDTO)
        {
            var lecture = await _lectureRepository.Get(o => o.Id == id);
            if (lecture == null)
                throw new NotFoundException("Lecture not found");

            lecture.LectureDate = lectureDTO.LectureDate;
            lecture.From = lectureDTO.From;
            lecture.To = lectureDTO.To;
            lecture.SubjectId1 = lectureDTO.SubjectId1;

            _lectureRepository.UpdateAsync(lecture);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Lecture updated",
                Success = true
            };
        }

        public async Task<DefaultResponse> DeleteLecture(Guid id)
        {
            var lecture = await _lectureRepository.Get(o => o.Id == id);
            if (lecture == null)
                throw new NotFoundException("Lecture not found");

            _lectureRepository.Delete(lecture);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Lecture deleted",
                Success = true
            };
        }
    }
}
