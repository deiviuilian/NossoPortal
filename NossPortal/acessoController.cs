using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NossoPortal;
[ApiController]
[Route("api/[controller]")]
public class acessoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public acessoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(new { Token = "fake-jwt-token" });
    }
}

public class LoginModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
