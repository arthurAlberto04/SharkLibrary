using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Models;
public class Editora
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
}
