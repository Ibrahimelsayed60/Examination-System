using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Domain.Dtos.Exam;
using ExaminationSystem.Domain.Mediators.contract;
using ExaminationSystem.Domain.Services.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Mediators
{
    public class ExamMediator : IExamMediator
    {
        private readonly IExamService _examService;
        private readonly IExamQuestionService _examQuestionService;
        private readonly IExamStudentService _examStudentService;
        private readonly ICourseService _courseService;
        private readonly ICourseStudentService _courseStudentService;

        public ExamMediator(IExamService examService,
            IExamQuestionService examQuestionService,
            IExamStudentService examStudentService,
            ICourseService courseService,
            ICourseStudentService courseStudentService)
        {
            _examService = examService;
            _examQuestionService = examQuestionService;
            _examStudentService = examStudentService;
            _courseService = courseService;
            _courseStudentService = courseStudentService;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExams()
        {
            return await _examService.GetAllExams();
        }

        public async Task<ExamDto> GetExamById(int id)
        {
            return await _examService.GetExamById(id);
        }

        public async Task<int> AddExam(ExamCreateDto examCreateDto)
        {
            return await _examService.CreateExam(examCreateDto);
        }

        public async Task UpdateExam(ExamUpdateDto updateDto)
        {
            await _examService.UpdateExam(updateDto);
        }

        public async Task DeleteExam(int id)
        {
            var exam = _examService.GetExamById(id);

            if(exam is not null)
            {
                await _examService.DeleteExam(id);

                var examQuestions = await _examQuestionService.Get(e => e.ExamId == id);

                if(examQuestions is not null)
                {
                    await _examQuestionService.DeleteRange(examQuestions);
                }
            }
        }

        public async Task<bool> SubmitExam(ExamStudentDto examStudentDto)
        {
            var examStudent = await _examStudentService.SubmitExam(examStudentDto);

            return true;
        }

        public async Task<bool> TakeExam(ExamStudentCreateDto examStudentCreateDto)
        {
            var exam = await _examService.GetExamById(examStudentCreateDto.ExamId);

            if (exam is not null)
            {
                throw new Exception("Exam is not found");
            }

            var course = await _courseService.GetByIdAsync(exam.CourseId);

            if(course is not null)
            {
                throw new Exception("Course is not found");
            }

            var isEnrolled = (await _courseStudentService.Get(c => c.CourseId == course.Id && c.StudentId == examStudentCreateDto.StudentId)).Any();

            if (!isEnrolled)
            {
                throw new Exception("Student is not enroll in this course");
            }

            if (DateTime.Now < exam.StartDate || DateTime.Now > exam.Duration)
            {
                throw new Exception("Exam is not available at this time.");
            }


            var examStudent = _examStudentService.GetExamStudent(examStudentCreateDto.Mapone<ExamStudentDto>());

            if (examStudent is null)
            {
                return false;
            }

            return true;


        }
    }
}
