using HrSystem.Models;
using HrSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly VacancyService _service;

        public VacancyController(VacancyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacancy>>> GetVacancies()
        {
            var vacancies = await _service.GetAllAsync();
            return Ok(vacancies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> GetVacancy(int id)
        {
            var vacancy = await _service.GetByIdAsync(id);

            if (vacancy == null)
            {
                return NotFound();
            }

            return Ok(vacancy);
        }

        [HttpPost]
        public async Task<ActionResult<Vacancy>> CreateVacancy(Vacancy vacancy)
        {
            await _service.AddAsync(vacancy);
            return CreatedAtAction(nameof(GetVacancy), new { id = vacancy.Id }, vacancy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacancy(int id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(vacancy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
