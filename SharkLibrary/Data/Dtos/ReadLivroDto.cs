using SharkLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class ReadLivroDto
{
    public string Nome { get; set; }
    public DateTime DataDeLançamento { get; set; }
    public int AutorId { get; set; }
    public Autor Autor { get; set; }
    public int GeneroId { get; set; }
    public Genero Genero { get; set; }
    public int EditoraId { get; set; }
    public Editora Editora { get; set; }
    public bool Disponivel { get; set; }
}
