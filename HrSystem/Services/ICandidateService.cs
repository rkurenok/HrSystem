using HrSystem.Models;
using Microsoft.AspNetCore.Routing.Matching;

namespace HrSystem.Services
{
    public interface ICandidateService : ICRUDService<Candidate>
    {
        Task<IEnumerable<Candidate>> SearchCandidatesOnHhRuAsync(string query);
    }
}
