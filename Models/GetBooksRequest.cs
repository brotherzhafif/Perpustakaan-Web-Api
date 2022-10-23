namespace Perpustakaan_Web_Api.Models
{
    public class GetBooksRequest
    {
        public Guid ID { get; set; }
        public string Nama { get; set; }
        public string Jenis { get; set; }
    }
}
