﻿using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GradingSystemBackend.Services
{
    public class GradeManagementServices : IGradeManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGradeRepository _gradeRepository;

        public GradeManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _gradeRepository = unitOfWork.GradeRepository;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> UpdateGrades(Guid id, GradesUpdateDTO gradeUpdateDTO)
        {
            var grade = await _gradeRepository.Get(o => o.Id == id);

            if (grade == null)
                throw new NotFoundException("Grade not found");

            grade.Q1 = gradeUpdateDTO.Q1;
            grade.Q2 = gradeUpdateDTO.Q2;
            grade.Q3 = gradeUpdateDTO.Q3;
            grade.Q4 = gradeUpdateDTO.Q4;
            grade.Average = gradeUpdateDTO.Average;
            grade.Remarks = gradeUpdateDTO.Remarks;

            _gradeRepository.UpdateAsync(_mapper.Map<Grade>(grade));
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Success = true,
                Message = "Grade Updated"
            };
        }

        public IEnumerable<StudentGradeResponse> GetStudentGrades(Guid subjectId)
        {
            var grades = _unitOfWork.GradeRepository.Query(o => o.SubjectId == subjectId, o => o.Student);
            return _mapper.Map <IEnumerable<StudentGradeResponse>>(grades.ToList());
        }

        public IEnumerable<StudentGradeResponse> GetGradesByStudentId(Guid studentId)
        {
            var grades = _unitOfWork.GradeRepository.Query(o => o.StudentId == studentId, o => o.Student, o => o.Subject, o => o.Subject.Faculty);
            return _mapper.Map<IEnumerable<StudentGradeResponse>>(grades.ToList());
        }
    }
}
