using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Services
{
    public class ExamStudentService : IExamStudentService
    {
        private readonly IBaseRepository<ExamStudent> _eSRepo;
        private readonly IBaseRepository<ExamStudentAnswer> _examAnswerRepo;

        public ExamStudentService(IBaseRepository<ExamStudent> eSRepo, IBaseRepository<ExamStudentAnswer> examAnswerRepo)
        {
            _eSRepo = eSRepo;
            _examAnswerRepo = examAnswerRepo;
        }

        public async Task<int> AddExamStudent(ExamStudentCreateDto examStudentCreateDto)
        {
            var examStudent = await _eSRepo.AddAsync(examStudentCreateDto.Mapone<ExamStudent>());
            return examStudent.Id;
        }

        public async Task<ExamStudentDto> GetExamStudent(ExamStudentDto examStudentDto)
        {
            var examStudent = (await _eSRepo.GetAllByExpressionAsync(es => es.StudentId == examStudentDto.StudentId && es.ExamId == examStudentDto.ExamId)).FirstOrDefault();

            return examStudent.Mapone<ExamStudentDto>();
        }

        public async Task<ExamStudentDto> GetExamStudentById(int examStudentId)
        {
            var examStudent = await _eSRepo.GetByIdAsync(examStudentId);

            return examStudent.Mapone<ExamStudentDto>();
        }

        public async Task<ExamStudentDto> SubmitExam(ExamStudentDto examStudentDto)
        {
            var examStudent = await _eSRepo.GetByIdAsync(examStudentDto.Id);

            if(examStudent is not null && !examStudent.IsSubmitted)
            {
                examStudent.IsSubmitted = true;
                examStudent.SubmissionDate = DateTime.UtcNow;

                _eSRepo.update(examStudent);

                foreach (var answerDTO in examStudentDto.Answers)
                {
                    var answer = answerDTO.Mapone<ExamStudentAnswer>();
                    await _examAnswerRepo.AddAsync(answer);
                }
                await _eSRepo.SaveChangesAsync();
                await _examAnswerRepo.SaveChangesAsync();

            }

            return examStudentDto;

        }
    }
}
