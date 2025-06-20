using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Models;
public class Livro
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public DateTime DataDeLançamento { get; set; }
    [Required]
    public int AutorId { get; set; }
    public Autor Autor { get; set; }
    [Required]
    public int GeneroId { get; set; }
    public Genero Genero { get; set; }
    [Required]
    public int EditoraId { get; set; }
    public Editora Editora { get; set; }
    [Required]
    public bool Disponivel { get; set; }
}
