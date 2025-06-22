using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("Livro")]
public class LivroController : Controller
{
    private LibraryContext _ctx;

    public LivroController(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public IActionResult CadastroLivro([FromBody] CreateLivroDto dto)
    {
        Livro livro = new Livro 
        {
            Nome = dto.Nome,
            DataDeLançamento = dto.DataDeLançamento,
            AutorId = dto.AutorId,
            GeneroId = dto.GeneroId,
            EditoraId = dto.EditoraId,
            Disponivel = dto.Disponivel
        };
        _ctx.Livros.Add(livro);
        _ctx.SaveChanges();
        return CreatedAtAction(nameof(ReadLivroById), new { id = livro.Id }, livro);
    }
    [HttpGet]
    public IEnumerable<ReadLivroDto> ReadLivros([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var livros = _ctx.Livros.Skip(skip).Take(take).ToList();
        List<ReadLivroDto> livrosDto = new List<ReadLivroDto>();
        foreach(var livro in livros)
        {
            ReadLivroDto livroDto = new ReadLivroDto 
            {
                Nome = livro.Nome,
                DataDeLançamento = livro.DataDeLançamento,
                Autor = new ReadAutorDto { Nome = livro.Autor.Nome },
                Genero = new ReadGeneroDto { Tipo = livro.Genero.Tipo },
                Editora = new ReadEditoraDto { Nome = livro.Editora.Nome },
                Disponivel = livro.Disponivel
            };
            livrosDto.Add(livroDto);
        }
        return livrosDto;
    }
    [HttpGet("{id}")]
    public IActionResult ReadLivroById(int id) 
    { 
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        ReadLivroDto livroDto = new ReadLivroDto
        {
            Nome = livro.Nome,
            DataDeLançamento = livro.DataDeLançamento,
            Autor = new ReadAutorDto { Nome = livro.Autor.Nome },
            Genero = new ReadGeneroDto { Tipo = livro.Genero.Tipo},
            Editora = new ReadEditoraDto { Nome = livro.Editora.Nome },
            Disponivel = livro.Disponivel
        };
        return Ok(livroDto);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateLivroFull(int id, [FromBody] UpdateLivroDto dto)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        livro.Nome= dto.Nome;
        livro.DataDeLançamento = dto.DataDeLançamento;
        livro.AutorId = dto.AutorId;
        livro.EditoraId = dto.EditoraId;
        livro.GeneroId = dto.GeneroId;
        livro.Disponivel = dto.Disponivel;
        _ctx.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateLivro(int id, JsonPatchDocument<UpdateLivroDto> dto)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        var livroAtt = new UpdateLivroDto
        {
            Nome = livro.Nome,
            DataDeLançamento = livro.DataDeLançamento,
            GeneroId = livro.GeneroId,
            EditoraId = livro.EditoraId,
            AutorId = livro.AutorId
        };
        dto.ApplyTo(livroAtt, ModelState);
        if (!TryValidateModel(livroAtt))
        {
            return ValidationProblem();
        }
        livro.Nome = livroAtt.Nome;
        livro.DataDeLançamento = livroAtt.DataDeLançamento;
        livro.GeneroId = livroAtt.GeneroId;
        livro.EditoraId = livroAtt.EditoraId;
        livro.AutorId = livroAtt.AutorId;
        _ctx.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteLivro(int id)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        _ctx.Livros.Remove(livro);
        _ctx.SaveChanges();
        return NoContent();
    }
}
