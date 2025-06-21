using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("Autor")]
public class AutorController : ControllerBase
{
    private LibraryContext _ctx;
    public AutorController(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public IActionResult CreateAutor([FromBody]CreateAutorDto dto)
    {
        Autor autor = new Autor { Nome = dto.Nome };
        _ctx.Autores.Add(autor);
        _ctx.SaveChanges();
        return CreatedAtAction(nameof(ReadAutorById), new { id = autor.Id }, autor); //"Documenta" o caminho que voce ira encontrar o objeto criado
    }
    [HttpGet]
    public IEnumerable<ReadAutorDto> RedAutor([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
         var autores = _ctx.Autores.Skip(skip).Take(take).ToList();
        List<ReadAutorDto> autoresDto = new List<ReadAutorDto>();
        foreach( var autor in autores)
        {
            ReadAutorDto autorDto = new ReadAutorDto { Nome = autor.Nome };
            autoresDto.Add(autorDto);
        }
        return autoresDto;
    }
    [HttpGet("{id}")]
    public IActionResult ReadAutorById(int id)
    {
        var autor = _ctx.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor == null) return NotFound();
        ReadAutorDto dto = new ReadAutorDto { Nome = autor.Nome };
        return Ok(dto);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAutor(int id, [FromBody] UpdateAutorDto dto)
    {
        var autor = _ctx.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor == null) return NotFound();
        autor.Nome = dto.Nome;
        _ctx.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAutor(int id)
    {
        var autor = _ctx.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor == null) return NotFound();
        _ctx.Autores.Remove(autor);
        _ctx.SaveChanges();
        return NoContent();
    }
}
