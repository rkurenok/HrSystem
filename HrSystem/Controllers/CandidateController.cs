using HrSystem.Models;
using HrSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _service;

        public CandidateController(CandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidaties()
        {
            var candidaties = await _service.GetAllAsync();
            return Ok(candidaties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            var candidate = await _service.GetByIdAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> CreateCandidate(Candidate candidate)
        {
            await _service.AddAsync(candidate);
            return CreatedAtAction(nameof(GetCandidate), new { id = candidate.Id }, candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(candidate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateCandidateStatus(int id, int status)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            candidate.Status = status;
            await _service.UpdateAsync(candidate);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Candidate>>> SearchCandidaties([FromQuery] string query)
        {
            var candidates = await _service.SearchCandidatesOnHhRuAsync(query);
            return Ok(candidates);
        }
    }
}
