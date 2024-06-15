using API_TokoBuku.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_TokoBuku.Interfaces
{
    public interface IPelangganRepository
    {
        ICollection<Pelanggan> GetPelanggan();
        Pelanggan GetPelanggan(int id);
        Task<bool> CreatePelanggan(CreatePelanggan pelanggan);
        Task<bool> UpdatePelanggan(CreatePelanggan pelanggan, int idPelanggan);
        Task<bool> DeletePelanggan(int pelangganId);
    }
}
