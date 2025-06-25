using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;
using SharkLibrary.Service;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("[Controller]")]
public class EditoraController : ControllerBase
{
    private EditoraService _editoraService;

    public EditoraController(EditoraService editoraService)
    {
        _editoraService = editoraService;
    }

    [HttpPost]
    public IActionResult CreateEditora([FromBody] CreateEditoraDto dto)
    {
        var editora = _editoraService.CriaEditora(dto);
        return CreatedAtAction(nameof(ReadEditoraById), new { id = editora.Id }, editora);
    }
    [HttpGet("{id}")]
    public IActionResult ReadEditoraById(int id)
    {
        var editora = _editoraService.GetEditoraById(id);
        return Ok(editora);
    }
    [HttpGet]
    public IEnumerable<ReadEditoraDto> ReadEditora([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var editoras = _editoraService.GetEditora(skip, take);
        return editoras;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateEditora(int id, [FromBody] UpdateEditoraDto dto)
    {
        _editoraService.AtualizaEditora(id, dto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteEditora(int id)
    {
        _editoraService.DeletaEditora(id);
        return NoContent();
    }
}
