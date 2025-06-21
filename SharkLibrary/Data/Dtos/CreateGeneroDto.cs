using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class CreateGeneroDto
{
    [Required]
    public string Tipo { get; set; }
}
