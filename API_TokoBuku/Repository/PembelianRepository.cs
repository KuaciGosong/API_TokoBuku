using API_TokoBuku.Data;
using API_TokoBuku.Interfaces;
using API_TokoBuku.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_TokoBuku.Repository
{
    public class PembelianRepository : IPembelianRepository
    {
        private readonly DataContext _context;
        public PembelianRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pembelian> GetPembelian()
        {
            return _context.Pembelians.OrderBy(p => p.Id).ToList();
        }

        public Pembelian GetPembelian(int id)
        {
            return _context.Pembelians.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> CreatePembelian(CreatePembelian pembelian)
        {
            try
            {
                var newPembelian = new Pembelian
                {
                    Jumlah_Beli = pembelian.Jumlah_Beli,
                    Tanggal_Pembelian = pembelian.Tanggal_Pembelian,
                    BukuID = pembelian.BukuID,
                    PelangganID = pembelian.PelangganID
                };

                _context.Pembelians.Add(newPembelian);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePembelian(CreatePembelian pembelian, int idPembelian)
        {
            var prevPembelian = await _context.Pembelians.FirstOrDefaultAsync(p => p.Id == idPembelian);

            if (prevPembelian == null)
                return false;

            prevPembelian.Jumlah_Beli = pembelian.Jumlah_Beli;
            prevPembelian.Tanggal_Pembelian = pembelian.Tanggal_Pembelian;
            prevPembelian.BukuID = pembelian.BukuID;
            prevPembelian.PelangganID = pembelian.PelangganID;

            try
            {
                _context.Pembelians.Update(prevPembelian);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePembelian(int pembelianId)
        {
            try
            {
                var pembelian = await _context.Pembelians.FirstOrDefaultAsync(p => p.Id == pembelianId);
                if (pembelian == null)
                {
                    return false;
                }

                _context.Pembelians.Remove(pembelian);
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
