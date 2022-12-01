using System.Data.SqlTypes;

namespace Perpustakaan_Web_Api.Models
{
    public class GetPeminjamanRequest
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public string Buku { get; set; }
        public string Pengawas { get; set; }
        public DateTime Tanggal { get; set; }
        public decimal Denda { get; set; }
        public string Status { get; set; }

    }
}
