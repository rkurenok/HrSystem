using HrSystem.Models;
using HrSystem.Repositories;

namespace HrSystem.Services
{
    public class DepartmentService : ICRUDService<Department>
    {
        private readonly ICRUDRepository<Department> _repository;

        public DepartmentService(CRUDRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Department department)
        {
            await _repository.AddAsync(department);
        }

        public async Task UpdateAsync(Department department)
        {
            await _repository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
