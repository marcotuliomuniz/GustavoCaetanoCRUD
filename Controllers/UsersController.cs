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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        var user = await _appDbContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound(new { message = "Usário não foi encontrado." });
        }

        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();

        return Ok(new { message = "Usuário removido com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindUserById(int id)
    {
        var user = await _appDbContext.Users.FindAsync(id);

        return Ok(user);
    }
}