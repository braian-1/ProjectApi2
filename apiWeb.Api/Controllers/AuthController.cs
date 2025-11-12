using apiWeb.Application.Services;
using apiWeb.Domain.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace apiWeb.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        var result = await _service.RefreshToken(request.RefreshToken);
        if (result == null)
            return Unauthorized(new { message = "Token invalido o expirado." });
        return Ok(result);
    }

    public record RefreshRequest(string RefreshToken);


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _service.Authenticate(request.Username, request.Password);
        if (token == null)
        {
            return Unauthorized(new { message = "El usuario o la contraseña no coinciden." });
        }
        return Ok(token);
    }
    
    public record LoginRequest(string Username, string Password);

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var sucess = await _service.Register(request.Username, request.Password,request.Role);
        if (!sucess)
            return BadRequest(new { message = "El usuario ya existe." });
        return Ok(new { message = "El usuario ha sido registrado con exito." });
    }
    
    public record RegisterRequest(string Username, string Password,string Role);

    [HttpPost("logout")]
    public async Task<IActionResult> Logout(string refreshToken)
    {
        var result = await _service.LogoutAsync(refreshToken);
        if (!result)
            return Unauthorized(new { message = "El token es invalido o ya expiro" });
        return Ok(new { message = "Se ha cerrado la sesion correctamente." });
    }
}