using API_TokoBuku.Data;
using API_TokoBuku.Interfaces;
using API_TokoBuku.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_TokoBuku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelangganController : ControllerBase
    {
        private readonly IPelangganRepository _pelangganRepository;
        private readonly DataContext _context;

        public PelangganController(IPelangganRepository pelangganRepository, DataContext context)
        {
            _pelangganRepository = pelangganRepository;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pelanggan>))]
        public IActionResult GetPelanggan()
        {
            var pelanggan = _pelangganRepository.GetPelanggan();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pelanggan);
        }

        [HttpGet("{id}", Name = "GetPelanggan")]
        [ProducesResponseType(200, Type = typeof(Pelanggan))]
        [ProducesResponseType(404)]
        public IActionResult GetPelanggan(int id)
        {
            if (!_pelangganRepository.GetPelanggan().Any(p => p.Id == id))
                return NotFound();

            var pelanggan = _pelangganRepository.GetPelanggan(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pelanggan);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePelanggan([FromBody] CreatePelanggan pelanggan)
        {
            if (pelanggan == null)
                return BadRequest(ModelState);

            if (!await _pelangganRepository.CreatePelanggan(pelanggan))
            {
                ModelState.AddModelError("", "Something went wrong while saving the customer");
                return StatusCode(500, ModelState);
            }

            var newPelanggan = _context.Pelanggans.OrderByDescending(p => p.Id).FirstOrDefault();

            return CreatedAtRoute("GetPelanggan", new { id = newPelanggan.Id }, newPelanggan);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePelanggan(int id, [FromBody] CreatePelanggan pelanggan)
        {
            if (!_pelangganRepository.GetPelanggan().Any(p => p.Id == id))
                return NotFound();

            if (!await _pelangganRepository.UpdatePelanggan(pelanggan, id))
            {
                ModelState.AddModelError("", "Something went wrong while updating the customer");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePelanggan(int id)
        {
            var pelanggan = _pelangganRepository.GetPelanggan(id);
            if (pelanggan == null)
                return NotFound();

            if (!await _pelangganRepository.DeletePelanggan(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the customer");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
