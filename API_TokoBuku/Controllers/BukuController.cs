using API_TokoBuku.Data;
using API_TokoBuku.Interfaces;
using API_TokoBuku.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_TokoBuku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : ControllerBase
    {
        private readonly IBukuRepository _bukuRepository;
        private readonly DataContext _context;

        public BukuController(IBukuRepository bukuRepository, DataContext context)
        {
            _bukuRepository = bukuRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBuku()
        {
            var buku = _bukuRepository.GetBuku();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(buku);
        }

        [HttpGet("{id}", Name = "GetBuku")]
        public IActionResult GetBuku(int id)
        {
            if (!_bukuRepository.GetBuku().Any(b => b.Id == id))
                return NotFound();

            var buku = _bukuRepository.GetBuku(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(buku);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuku([FromBody] CreateBuku buku)
        {
            if (buku == null)
                return BadRequest(ModelState);

            if (!await _bukuRepository.CreateBuku(buku))
            {
                ModelState.AddModelError("", "Something went wrong while saving the book");
                return StatusCode(500, ModelState);
            }

            var newBuku = _context.Bukus.OrderByDescending(b => b.Id).FirstOrDefault();

            return CreatedAtRoute("GetBuku", new { id = newBuku.Id }, newBuku);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBuku(int id, [FromBody] CreateBuku buku)
        {
            if (!await _bukuRepository.UpdateBuku(buku, id))
            {
                ModelState.AddModelError("", "Something went wrong while updating the book");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuku(int id)
        {
            var buku = _bukuRepository.GetBuku(id);
            if (buku == null)
                return NotFound();

            if (!await _bukuRepository.DeleteBuku(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the book");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
