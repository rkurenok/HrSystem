using HrSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HrSystem.Data
{
    public class HrContext: DbContext
    {
        public HrContext(DbContextOptions<HrContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Hr> Hrs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Vacancy)
                .WithMany(v => v.Candidates)
                .HasForeignKey(c => c.VacancyId);

            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Department)
                .WithMany(d => d.Vacancies)
                .HasForeignKey(v => v.DepartmentId);
        }
    }
}
