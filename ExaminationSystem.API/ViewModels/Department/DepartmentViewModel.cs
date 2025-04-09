namespace ExaminationSystem.API.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public ICollection<int> CoursesIDs { get; set; }
        public ICollection<int> InstructorsIDs { get; set; }
        public ICollection<int> StudentsIDs { get; set; }
    }
}
