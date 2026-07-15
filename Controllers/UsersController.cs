using GustavoCaetanoCRUD.Data;
using GustavoCaetanoCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace GustavoCaetanoCRUD.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class UsersController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public UsersController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewUser(User user)
    {
        _appDbContext.Users.Add(user);
        var response = await _appDbContext.SaveChangesAsync();

        return Ok(response);
    }
}