using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;

public class UpdateLivroDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public DateOnly DataDeLançamento { get; set; }
    [Required]
    public int AutorId { get; set; }
    [Required]
    public int GeneroId { get; set; }
    [Required]
    public int EditoraId { get; set; }
    [Required]
    public bool Disponivel { get; set; }

}
