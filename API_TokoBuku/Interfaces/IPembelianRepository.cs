using API_TokoBuku.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_TokoBuku.Interfaces
{
    public interface IPembelianRepository
    {
        ICollection<Pembelian> GetPembelian();
        Pembelian GetPembelian(int id);
        Task<bool> CreatePembelian(CreatePembelian pembelian);
        Task<bool> UpdatePembelian(CreatePembelian pembelian, int idPembelian);
        Task<bool> DeletePembelian(int pembelianId);
    }
}
