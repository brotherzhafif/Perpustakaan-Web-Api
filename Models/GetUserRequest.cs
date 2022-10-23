namespace Perpustakaan_Web_Api.Models
{
    public class GetUserRequest
    {
        public Guid ID { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
        public int Level { get; set; }
    }
}
