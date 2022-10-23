namespace Perpustakaan_Web_Api.Models
{
    public class UpdatePeminjamanRequest
    {
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public string Buku { get; set; }
        public string Pengawas { get; set; }
        public string Tanggal { get; set; }
        public int Denda { get; set; }
        public string Status { get; set; }
    }
}
