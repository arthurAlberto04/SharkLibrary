using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;
using SharkLibrary.Service;
namespace SharkLibrary.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase 
{
    private UsuarioService _usuarioService;
    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("Cadastro")]
    public async  Task<IActionResult> Cadastro([FromBody]CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastro(dto);
        return Ok("Usuario Cadastrado Com Sucesso");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }
}
