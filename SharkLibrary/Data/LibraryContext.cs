using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharkLibrary.Models;

namespace SharkLibrary.Data;
public class LibraryContext : IdentityDbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> opts) : base(opts)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Editora> Editoras { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
