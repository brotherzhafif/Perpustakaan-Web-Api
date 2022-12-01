using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Data;
using Perpustakaan_Web_Api.Models;

namespace Perpustakaan_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class User : Controller
    {
        private readonly PerpustakaanDbContext dbContext;

        public User(PerpustakaanDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await dbContext.User.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUser)
        {
            var user = new GetUserRequest()
            {
                ID = Guid.NewGuid(),
                Nama = addUser.Nama,
                Password = addUser.Password,
                Level = addUser.Level,
            };

            await dbContext.User.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUserRequest([FromRoute] Guid id, UpdateUserRequest updateUser)
        {
            var user = await dbContext.User.FindAsync(id);

            if(user != null)
            {
                user.Nama = updateUser.Nama;
                user.Password = updateUser.Password;
                user.Level = updateUser.Level;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }

            return NotFound();

        }
     

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id, GetUserRequest getUser)
        {
            var user = await dbContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
           
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUserRequest([FromRoute] Guid id)
        {
            var user = await dbContext.User.FindAsync(id);

            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }
    }
}
