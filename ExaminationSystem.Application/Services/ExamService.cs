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
    public class ExamService : IExamService
    {
        private readonly IBaseRepository<Exam> _examRepo;

        public ExamService(IBaseRepository<Exam> examRepo) 
        {
            _examRepo = examRepo;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExams()
        {
            return (await _examRepo.GetAllAsync()).Map<ExamDto>().ToList();
        }

        public async Task<ExamDto> GetExamById(int id)
        {
            return (await _examRepo.GetByIdAsync(id)).Mapone<ExamDto>();
        }

        public async Task<int> CreateExam(ExamCreateDto examCreateDto)
        {
            var exam = await _examRepo.AddAsync(examCreateDto.Mapone<Exam>());

            await _examRepo.SaveChangesAsync();

            return exam.Id;
        }


        public async Task UpdateExam(ExamUpdateDto examUpdateDto)
        {
            var exam = await _examRepo.GetByIdAsync(examUpdateDto.Id);

            if (exam is null)
            {
                throw new Exception("Exam Not Found");
            }

            exam = examUpdateDto.Mapone<Exam>();

            _examRepo.update(exam);

            await _examRepo.SaveChangesAsync();
        }

        public async Task DeleteExam(int id)
        {
            var exam = await _examRepo.getWithTrackingByIdAsync(id);

            if(exam is null)
            {
                throw new Exception("Exam is Not found");
            }

            _examRepo.Delete(exam);

            await _examRepo.SaveChangesAsync();

        }

        
    }
}
