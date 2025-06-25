using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;
using SharkLibrary.Service;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("[Controller]")]
public class LivroController : Controller
{
    private LivroService _livroService;

    public LivroController(LivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpPost]
    public IActionResult CadastroLivro([FromBody] CreateLivroDto dto)
    {
        var livro = _livroService.CadastraLivro(dto);
        return CreatedAtAction(nameof(ReadLivroById), new { id = livro.Id }, livro);
    }
    [HttpGet]
    public IEnumerable<ReadLivroDto> ReadLivros([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var livros = _livroService.GetLivros(skip, take);
        return livros;
    }
    [HttpGet("{id}")]
    public IActionResult ReadLivroById(int id)
    {
        var livro = _livroService.GetLivroById(id);
        return Ok(livro);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateLivroFull(int id, [FromBody] UpdateLivroDto dto)
    {
        _livroService.AtualizaLivro(id, dto);
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateLivro(int id, JsonPatchDocument<UpdateLivroDto> dto)
    {
        _livroService.AtualizaLivroParcial(id, dto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteLivro(int id)
    {
        _livroService.DeletaLivro(id);
        return NoContent();
    }
}
