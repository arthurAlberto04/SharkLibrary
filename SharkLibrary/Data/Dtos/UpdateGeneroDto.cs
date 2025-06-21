using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class UpdateGeneroDto
{
    [Required]
    public string Tipo { get; set; }
}
