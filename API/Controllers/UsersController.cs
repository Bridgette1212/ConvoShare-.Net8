using API.Data;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UsersController: ControllerBase
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){

        var users = await  _context.Users.ToListAsync();
        return users;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int Id){
         var user = await _context.Users.FindAsync(Id);
         if(user == null) return NotFound();
        return user;
    }
}
