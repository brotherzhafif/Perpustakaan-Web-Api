namespace Perpustakaan_Web_Api.Models
{
    public class AddUserRequest
    {
        public string Nama { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
        public int Level { get; set; }
    }
}
