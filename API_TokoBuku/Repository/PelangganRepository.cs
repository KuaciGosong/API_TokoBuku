using API_TokoBuku.Data;
using API_TokoBuku.Interfaces;
using API_TokoBuku.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TokoBuku.Repository
{
    public class PelangganRepository : IPelangganRepository
    {
        private readonly DataContext _context;
        public PelangganRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pelanggan> GetPelanggan()
        {
            return _context.Pelanggans.OrderBy(p => p.Id).ToList();
        }

        public Pelanggan GetPelanggan(int id)
        {
            return _context.Pelanggans.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> CreatePelanggan(CreatePelanggan pelanggan)
        {
            try
            {
                var newPelanggan = new Pelanggan
                {
                    Nama_Pelanggan = pelanggan.Nama_Pelanggan
                };

                _context.Pelanggans.Add(newPelanggan);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePelanggan(CreatePelanggan pelanggan, int idPelanggan)
        {
            var prevPelanggan = await _context.Pelanggans.FirstOrDefaultAsync(p => p.Id == idPelanggan);

            if (prevPelanggan == null)
                return false;

            prevPelanggan.Nama_Pelanggan = pelanggan.Nama_Pelanggan;

            try
            {
                _context.Pelanggans.Update(prevPelanggan);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePelanggan(int pelangganId)
        {
            try
            {
                var pelanggan = await _context.Pelanggans.FirstOrDefaultAsync(p => p.Id == pelangganId);
                if (pelanggan == null)
                {
                    return false;
                }

                _context.Pelanggans.Remove(pelanggan);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
