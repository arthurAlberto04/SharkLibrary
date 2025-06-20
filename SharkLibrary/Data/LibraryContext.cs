using Microsoft.EntityFrameworkCore;
using SharkLibrary.Models;

namespace SharkLibrary.Data;
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> opts) : base()
    {

    }

    DbSet<Autor> Autores { get; set; }
    DbSet<Editora> Editoras { get; set; }
    DbSet<Genero> Generos { get; set; }
    DbSet<Livro> Livros { get; set; }
}
