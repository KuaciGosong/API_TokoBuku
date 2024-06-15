namespace API_TokoBuku.Models
{
    public class Buku
    {
        public int Id { get; set; }
        public string Judul_Buku { get; set; }
        public string Penulis { get; set;}
        public int Harga_Satuan { get; set; }
        public ICollection<Pembelian> pembelians { get; set; }
    }
    public class CreateBuku
    {
        public string Judul_Buku { get; set; }
        public string Penulis { get; set; }
        public int Harga_Satuan { get; set; }
    }
}
