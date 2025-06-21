using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class UpdateEditoraDto
{
    [Required]
    public string Nome { get; set; }
}
