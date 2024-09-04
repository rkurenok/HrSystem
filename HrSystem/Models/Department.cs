namespace HrSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
    }
}
