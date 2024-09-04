using HrSystem.Configurations;
using HrSystem.DTOs;
using HrSystem.Models;
using HrSystem.Repositories;
using Microsoft.Extensions.Options;

namespace HrSystem.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICRUDRepository<Candidate> _repository;
        private readonly HttpClient _httpClient;
        private readonly string _hhApiBaseUrl;

        public CandidateService(CRUDRepository<Candidate> repository, HttpClient httpClient, IOptions<HhApiSettings> hhApiSettings)
        {
            _repository = repository;
            _httpClient = httpClient;
            _hhApiBaseUrl = hhApiSettings.Value.BaseUrl;
        }

        public async Task<List<Candidate>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Candidate> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _repository.AddAsync(candidate);
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            await _repository.UpdateAsync(candidate);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task<IEnumerable<Candidate>> SearchCandidatesOnHhRuAsync(string query)
        {
            var url = $"{_hhApiBaseUrl}?text={query}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Candidate>();
            }

            var responseData = await response.Content.ReadFromJsonAsync<HhApiResponse>();

            var candidates = responseData.Items.Select(v => new Candidate
            {
                Name = v.Name,
                Email = v.Email,
            });

            return candidates;
        }
    }
}
