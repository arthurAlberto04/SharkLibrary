using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class CreateEditoraDto
{
    [Required]
    public string Nome { get; set; }
}
