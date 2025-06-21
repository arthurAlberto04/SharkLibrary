using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("Editora")]
public class EditoraController : ControllerBase
{
    private LibraryContext _ctx;

    public EditoraController(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public IActionResult CreateEditora([FromBody] CreateEditoraDto dto)
    {
        Editora editora = new Editora { Nome = dto.Nome };
        _ctx.Editoras.Add(editora);
        _ctx.SaveChanges();
        return CreatedAtAction(nameof(ReadEditoraById), new { id = editora.Id }, editora);
    }
    [HttpGet("{id}")]
    public IActionResult ReadEditoraById(int id)
    {
        var editora = _ctx.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora == null) return NotFound();
        ReadEditoraDto editoraDto = new ReadEditoraDto { Nome = editora.Nome };
        return Ok(editoraDto);
    }
    [HttpGet]
    public IEnumerable<ReadEditoraDto> ReadEditora([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var editoras = _ctx.Editoras.Skip(skip).Take(take).ToList();
        List<ReadEditoraDto> editorasDto = new List<ReadEditoraDto>();
        foreach (var editora in editoras)
        {
            ReadEditoraDto editor = new ReadEditoraDto { Nome = editora.Nome };
            editorasDto.Add(editor);
        }
        return editorasDto;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateEditora(int id, [FromBody] UpdateEditoraDto dto)
    {
        var editora = _ctx.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora == null) return NotFound();
        editora.Nome = dto.Nome;
        _ctx.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteEditora(int id)
    {
        var editora = _ctx.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora == null) return NotFound();
        _ctx.Editoras.Remove(editora);
        _ctx.SaveChanges();
        return NoContent();
    }


}
