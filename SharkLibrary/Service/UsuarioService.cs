using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Data;
using SharkLibrary.Models;

namespace SharkLibrary.Service;
public class UsuarioService
{
    private LibraryContext _ctx;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signManager;
    private TokenService _tokenService;

    public UsuarioService(LibraryContext ctx, UserManager<Usuario> userManager, SignInManager<Usuario> signManager, TokenService tokenService)
    {
        _ctx = ctx;
        _userManager = userManager;
        _signManager = signManager;
        _tokenService = tokenService;
    }

    public async Task Cadastro(CreateUsuarioDto dto)
    {
        Usuario usuario = new Usuario
        {
            UserName = dto.Username,
            Telefone = dto.Telefone,
        };
        var resultado = await _userManager.CreateAsync(usuario, dto.Password);
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao Cadastrar Usuario");
        }
    }

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var result = await _signManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
        if (!result.Succeeded)
        {
            throw new ApplicationException("Erro ao efetuar Login");
        }

        var usuario = _signManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario);
        return token;
    }
}
