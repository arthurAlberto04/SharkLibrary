using SharkLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class CreateLivroDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public DateTime DataDeLançamento { get; set; }
    [Required]
    public int AutorId { get; set; }
    [Required]
    public int GeneroId { get; set; }
    [Required]
    public int EditoraId { get; set; }
    [Required]
    public bool Disponivel { get; set; }
}
