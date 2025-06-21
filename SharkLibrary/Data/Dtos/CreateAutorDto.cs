using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class CreateAutorDto
{
    [Required]
    public string Nome { get; set; }
}
