using HrSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HrSystem.Data
{
    public class HrContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Hr> Hrs { get; set; }

        public HrContext(DbContextOptions<HrContext> options) : base(options)
        {
        }
    }
}
