using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> getUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AppUser>> getUser(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }
    }
}
