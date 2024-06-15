using API_TokoBuku.Data;
using API_TokoBuku.Interfaces;
using API_TokoBuku.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_TokoBuku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PembelianController : ControllerBase
    {
        private readonly IPembelianRepository _pembelianRepository;
        private readonly DataContext _context;

        public PembelianController(IPembelianRepository pembelianRepository, DataContext context)
        {
            _pembelianRepository = pembelianRepository;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pembelian>))]
        public IActionResult GetPembelian()
        {
            var pembelian = _pembelianRepository.GetPembelian();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pembelian);
        }

        [HttpGet("{id}", Name = "GetPembelian")]
        [ProducesResponseType(200, Type = typeof(Pembelian))]
        [ProducesResponseType(404)]
        public IActionResult GetPembelian(int id)
        {
            if (!_pembelianRepository.GetPembelian().Any(p => p.Id == id))
                return NotFound();

            var pembelian = _pembelianRepository.GetPembelian(id);

            if (pembelian == null)
                return NotFound();

            return Ok(pembelian);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePembelian([FromBody] CreatePembelian pembelian)
        {
            if (pembelian == null)
                return BadRequest(ModelState);

            if (!await _pembelianRepository.CreatePembelian(pembelian))
            {
                ModelState.AddModelError("", "Something went wrong while saving the purchase");
                return StatusCode(500, ModelState);
            }

            var newPembelian = _context.Pembelians.OrderByDescending(p => p.Id).FirstOrDefault();

            return CreatedAtRoute("GetPembelian", new { id = newPembelian.Id }, newPembelian);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePembelian(int id, [FromBody] CreatePembelian pembelian)
        {
            if (!_pembelianRepository.GetPembelian().Any(p => p.Id == id))
                return NotFound();

            if (!await _pembelianRepository.UpdatePembelian(pembelian, id))
            {
                ModelState.AddModelError("", "Something went wrong while updating the purchase");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePembelian(int id)
        {
            var pembelian = _pembelianRepository.GetPembelian(id);
            if (pembelian == null)
                return NotFound();

            if (!await _pembelianRepository.DeletePembelian(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the purchase");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
