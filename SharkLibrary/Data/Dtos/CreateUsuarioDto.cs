using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class CreateUsuarioDto
{
    [Required]
    public string Telefone { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")] // Exige que o usuario confirme a senha para cadastro, aqui sendo elas comparadas
    public string RePassword { get; set; }
}
