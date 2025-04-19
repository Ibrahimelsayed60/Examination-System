namespace ExaminationSystem.API.ViewModels.Course
{
    public class CourseUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int CreditHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<int> InstructorIDs { get; set; }
        public ICollection<int> StudentsIDs { get; set; }
    }
}
