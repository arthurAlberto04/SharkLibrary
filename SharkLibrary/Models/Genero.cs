using System.ComponentModel.DataAnnotations;
namespace SharkLibrary.Models;
public class Genero
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Tipo { get; set; }
}
