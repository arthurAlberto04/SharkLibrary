using SharkLibrary.Data.Dtos;
using SharkLibrary.Data;
using SharkLibrary.Models;

namespace SharkLibrary.Service;
public class EditoraService
{
    private LibraryContext _ctx;

    public EditoraService(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    public Editora CriaEditora(CreateEditoraDto dto)
    {
        Editora editora = new Editora { Nome = dto.Nome };
        _ctx.Editoras.Add(editora);
        _ctx.SaveChanges();
        return editora;
    }
    public ReadEditoraDto GetEditoraById(int id)
    {
        var editora = _ctx.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora == null) throw new ApplicationException("Editora não encontrada");
        ReadEditoraDto editoraDto = new ReadEditoraDto { Nome = editora.Nome };
        return editoraDto;
    }
    public IEnumerable<ReadEditoraDto> GetEditora(int skip, int take)
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
    public void AtualizaEditora(int id, UpdateEditoraDto dto)
    {
        var editora = _ctx.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora == null) throw new ApplicationException("Editora não encontrada");
        editora.Nome = dto.Nome;
        _ctx.SaveChanges();
    }
    public void DeletaEditora(int id)
    {
        var editora = _ctx.Editoras.FirstOrDefault(editora => editora.Id == id);
        if (editora == null) throw new ApplicationException("Editora não encontrada");
        _ctx.Editoras.Remove(editora);
        _ctx.SaveChanges();
    }
}
