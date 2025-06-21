using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class UpdateAutorDto
{
    [Required]
    public string Nome { get; set; }
}
