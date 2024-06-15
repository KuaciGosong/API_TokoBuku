using API_TokoBuku.Models;

namespace API_TokoBuku.Interfaces
{
    public interface IBukuRepository
    {
        ICollection<Buku> GetBuku();
        Buku GetBuku(int id);
        Task<bool> CreateBuku(CreateBuku buku);
        Task<bool> UpdateBuku(CreateBuku buku, int idBuku);
        Task<bool> DeleteBuku(int bukuId);
    }
}
