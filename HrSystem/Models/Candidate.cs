namespace HrSystem.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int Status { get; set; }
        public int VacancyId { get; set; }
        public Vacancy? Vacancy { get; set; }
    }
}
