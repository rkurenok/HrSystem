using HrSystem.Models;
using HrSystem.Repositories;

namespace HrSystem.Services
{
    public class VacancyService : ICRUDService<Vacancy>
    {
        private readonly ICRUDRepository<Vacancy> _repository;

        public VacancyService(CRUDRepository<Vacancy> repository)
        {
            _repository = repository;
        }

        public async Task<List<Vacancy>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Vacancy vacancy)
        {
            await _repository.AddAsync(vacancy);
        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            await _repository.UpdateAsync(vacancy);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
