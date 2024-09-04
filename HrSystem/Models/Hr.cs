namespace HrSystem.Models
{
    public class Hr
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
    }
}
