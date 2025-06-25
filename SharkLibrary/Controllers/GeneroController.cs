using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;
using SharkLibrary.Service;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("[Controller]")]
public class GeneroController : ControllerBase
{
    private GeneroService _generoService;

    public GeneroController(GeneroService generoService)
    {
        _generoService = generoService;
    }

    [HttpPost]
    public IActionResult CreateGenero([FromBody] CreateGeneroDto dto)
    {
        var genero = _generoService.CriaGenero(dto);
        return CreatedAtAction(nameof(ReadGeneroById), new { id = genero.Id }, genero);
    }

    [HttpGet("{id}")]
    public IActionResult ReadGeneroById(int id)
    {
        var genero = _generoService.GetGeneroById(id);
        return Ok(genero);
    }
    [HttpGet]
    public IEnumerable<ReadGeneroDto> ReadGenero([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var generos = _generoService.GetGenero(skip, take);
        return generos;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateGenero(int id, [FromBody] UpdateGeneroDto dto)
    {
        _generoService.AtualizaGenero(id, dto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteGenero(int id)
    {
        _generoService.DeletaGenero(id);
        return NoContent();
    }
}
