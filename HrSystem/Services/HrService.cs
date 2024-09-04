using HrSystem.Models;
using HrSystem.Repositories;

namespace HrSystem.Services
{
    public class HrService : ICRUDService<Hr>
    {
        private readonly ICRUDRepository<Hr> _repository;

        public HrService(CRUDRepository<Hr> repository)
        {
            _repository = repository;
        }

        public async Task<List<Hr>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Hr> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Hr hr)
        {
            await _repository.AddAsync(hr);
        }

        public async Task UpdateAsync(Hr hr)
        {
            await _repository.UpdateAsync(hr);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
