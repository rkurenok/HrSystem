using HrSystem.Models;
using HrSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : ControllerBase
    {
        private readonly HrService _service;

        public HrController(HrService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hr>>> GetHrs()
        {
            var hrs = await _service.GetAllAsync();
            return Ok(hrs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hr>> GetHr(int id)
        {
            var hr = await _service.GetByIdAsync(id);

            if (hr == null)
            {
                return NotFound();
            }

            return Ok(hr);
        }

        [HttpPost]
        public async Task<ActionResult<Hr>> CreateHr(Hr hr)
        {
            await _service.AddAsync(hr);
            return CreatedAtAction(nameof(GetHr), new { id = hr.Id }, hr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHr(int id, Hr hr)
        {
            if (id != hr.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(hr);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHr(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
