using Microsoft.AspNetCore.Identity;
namespace SharkLibrary.Models;
public class Usuario : IdentityUser
{
    public ICollection<Livro> LivrosAlugados { get; set; }
    public string Telefone { get; set; }
    public Usuario() : base() { }

}
