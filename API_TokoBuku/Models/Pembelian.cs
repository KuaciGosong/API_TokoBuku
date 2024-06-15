using System;

namespace API_TokoBuku.Models
{
    public class Pembelian
    {
        public int Id { get; set; }
        public int Jumlah_Beli { get; set; }
        public DateTime Tanggal_Pembelian { get; set; }
        public int BukuID { get; set; }
        public Buku Buku { get; set; }
        public int PelangganID { get; set; }
        public Pelanggan Pelanggan { get; set; }
    }

    public class CreatePembelian
    {
        public int Jumlah_Beli { get; set; }
        public DateTime Tanggal_Pembelian { get; set; }
        public int BukuID { get; set; }
        public int PelangganID { get; set; }
    }
}
