namespace Perpustakaan_Web_Api.Models
{
    public class AddUserRequest
    {
        public string Nama { get; set; }
        public string Password { get; set; }
        public Int16 Level { get; set; }
    }
}
