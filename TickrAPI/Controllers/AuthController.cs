using Microsoft.AspNetCore.Mvc;
using TickrAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly SupabaseService _supabase;

    public AuthController(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] LoginRequest request)
    {
        var session = await _supabase.SignIn(request.Email, request.Password);
        if (session == null) return Unauthorized();
        return Ok(new { Token = session.AccessToken });
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] LoginRequest request)
    {
        var user = await _supabase.SignUp(request.Email, request.Password);
        if (user == null) return BadRequest();
        return Ok(new { UserId = user.Id });
    }

    [HttpPost("signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _supabase.SignOut();
        return Ok();
    }
}

