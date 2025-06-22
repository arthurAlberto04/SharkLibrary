using SharkLibrary.Models;
using System.ComponentModel.DataAnnotations;
namespace SharkLibrary.Data.Dtos;
public class ReadLivroDto
{
    public string Nome { get; set; }
    public DateOnly DataDeLançamento { get; set; }
    public virtual ReadAutorDto Autor { get; set; }
    public virtual ReadGeneroDto Genero { get; set; }
    public virtual ReadEditoraDto Editora { get; set; }
    public bool Disponivel { get; set; }
}
