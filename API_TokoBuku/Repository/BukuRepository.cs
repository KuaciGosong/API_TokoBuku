using API_TokoBuku.Data;
using API_TokoBuku.Interfaces;
using API_TokoBuku.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;

namespace API_TokoBuku.Repository
{
    public class BukuRepository : IBukuRepository
    {
        private readonly DataContext _context;
        public BukuRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Buku> GetBuku()
        {
            return _context.Bukus.OrderBy(p => p.Id).ToList();
        }

        public Buku GetBuku(int id)
        {
            return _context.Bukus.FirstOrDefault(b => b.Id == id);
        }

        public async Task<bool> CreateBuku(CreateBuku buku)
        {
            try
            {
                var Buku = new Buku
                {
                    Judul_Buku = buku.Judul_Buku,
                    Penulis = buku.Penulis,
                    Harga_Satuan = buku.Harga_Satuan
                };

                _context.Bukus.Add(Buku);
                await _context.SaveChangesAsync();
                return true;

            } catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateBuku(CreateBuku buku, int idBuku)
        {
            var prevBuku = await _context.Bukus.FirstOrDefaultAsync(b => b.Id == idBuku);

            if (prevBuku == null)
                return false;

            prevBuku.Judul_Buku = buku.Judul_Buku;
            prevBuku.Harga_Satuan = buku.Harga_Satuan;
            prevBuku.Penulis = buku.Penulis;

            try
            {
                _context.Bukus.Update(prevBuku);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBuku(int bukuId)
        {
            try
            {
                var buku = await _context.Bukus.FirstOrDefaultAsync(b => b.Id == bukuId);
                if (buku == null)
                {
                    return false;
                }

                _context.Bukus.Remove(buku);
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
