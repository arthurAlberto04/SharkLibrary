using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("Genero")]
public class GeneroController : ControllerBase
{
    private LibraryContext _ctx;

    public GeneroController(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public IActionResult CreateGenero([FromBody] CreateGeneroDto dto)
    {
        Genero genero = new Genero { Tipo = dto.Tipo };
        _ctx.Generos.Add(genero);
        _ctx.SaveChanges();
        return CreatedAtAction(nameof(ReadGeneroById), new { id = genero.Id }, genero);
    }

    [HttpGet("{id}")]
    public IActionResult ReadGeneroById(int id)
    {
        var genero = _ctx.Generos.FirstOrDefault(genero => genero.Id == id);
        if (genero == null) return NotFound();
        ReadGeneroDto generoDto = new ReadGeneroDto { Tipo = genero.Tipo };
        return Ok(generoDto);
    }
    [HttpGet]
    public IEnumerable<ReadGeneroDto> ReadGenero([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var generos = _ctx.Generos.Skip(skip).Take(take).ToList();
        List<ReadGeneroDto> generosDto = new List<ReadGeneroDto>();
        foreach (var genero in generos)
        {
            ReadGeneroDto generoDto = new ReadGeneroDto { Tipo = genero.Tipo };
            generosDto.Add(generoDto);
        }
        return generosDto;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateGenero(int id, [FromBody] UpdateGeneroDto dto)
    {
        var genero = _ctx.Generos.FirstOrDefault(genero=>genero.Id == id);
        if (genero == null) return NotFound();
        genero.Tipo = dto.Tipo;
        _ctx.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteGenero(int id)
    {
        var genero = _ctx.Generos.FirstOrDefault(genero => genero.Id == id);
        if (genero == null) return NotFound();
        _ctx.Generos.Remove(genero);
        _ctx.SaveChanges();
        return NoContent();
    }
}
