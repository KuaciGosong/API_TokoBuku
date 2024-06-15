namespace API_TokoBuku.Models
{
    public class Pelanggan
    {
        public int Id { get; set; }
        public string Nama_Pelanggan { get; set; }
        public ICollection<Pembelian> pembelians { get; set; }
    }

    public class CreatePelanggan
    {
        public string Nama_Pelanggan { get; set; }
    }
}
