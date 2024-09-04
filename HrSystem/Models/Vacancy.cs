namespace HrSystem.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public required string Position { get; set; }
        public int DepartmentId { get; set; }
        public required Department Department { get; set; }
        public List<Candidate>? Candidates { get; set; }
    }
}
