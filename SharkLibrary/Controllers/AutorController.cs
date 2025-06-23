using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;
using SharkLibrary.Service;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("[Controller]")]
public class AutorController : ControllerBase
{
    private AutorService _autorService;
    public AutorController(AutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpPost]
    public IActionResult CreateAutor([FromBody]CreateAutorDto dto)
    {
        var autor = _autorService.CadastroAutor(dto);
        return CreatedAtAction(nameof(ReadAutorById), new { id = autor.Id }, autor); //"Documenta" o caminho que voce ira encontrar o objeto criado
    }
    [HttpGet]
    public IEnumerable<ReadAutorDto> RedAutor([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var autores = _autorService.GetAutores(skip, take);
        return autores;
    }
    [HttpGet("{id}")]
    public IActionResult ReadAutorById(int id)
    {
        var autor = _autorService.GetAutorById(id);
        return Ok(autor);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAutor(int id, [FromBody] UpdateAutorDto dto)
    {
        _autorService.AtualizaAutor(id, dto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAutor(int id)
    {
        _autorService.DeletaAutor(id);
        return NoContent();
    }
}
