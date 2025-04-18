using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Services
{
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly IBaseRepository<ExamQuestion> _eQRepo;

        public ExamQuestionService(IBaseRepository<ExamQuestion> EQRepo)
        {
            _eQRepo = EQRepo;
        }

        public async Task<IEnumerable<ExamQuestionDto>> Get(Expression<Func<ExamQuestion, bool>> predicate)
        {
            return (await _eQRepo.GetAllByExpressionAsync(predicate)).Map<ExamQuestionDto>().ToList();
        }

        public async Task Add(ExamQuestionCreateDto examQuestionCreateDto)
        {
            await _eQRepo.AddAsync(new ExamQuestion
            {
                ExamId = examQuestionCreateDto.ExamId,
                QuestionId = examQuestionCreateDto.QuestionId,
            });

            await _eQRepo.SaveChangesAsync();
        }

        public async Task AddRange(int examId, IEnumerable<int> QuestionIDs)
        {
            foreach (int Id in QuestionIDs)
            {
                await _eQRepo.AddAsync(new ExamQuestion
                {
                    ExamId = examId,
                    QuestionId = Id
                });
            }

            await _eQRepo.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<ExamQuestionDto> examQuestions)
        {
            _eQRepo.DeleteRange(examQuestions.AsQueryable().Map<ExamQuestion>());
            await _eQRepo.SaveChangesAsync();
        }

        
    }
}
