namespace Perpustakaan_Web_Api.Models
{
    public class GetUserRequest
    {
        public Guid ID { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public Int16 Level { get; set; }
    }
}
