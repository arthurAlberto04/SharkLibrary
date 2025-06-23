using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;

namespace SharkLibrary.Service;
public class AutorService
{
    private LibraryContext _ctx;

    public AutorService(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    public Autor CadastroAutor(CreateAutorDto dto)
    {
        Autor autor = new Autor { Nome = dto.Nome };
        _ctx.Autores.Add(autor);
        _ctx.SaveChanges();
        return autor;
    }
    public IEnumerable<ReadAutorDto> GetAutores(int skip = 0, int take = 30)
    {
        var autores = _ctx.Autores.Skip(skip).Take(take).ToList();
        List<ReadAutorDto> autoresDto = new List<ReadAutorDto>();
        foreach (var autor in autores)
        {
            ReadAutorDto autorDto = new ReadAutorDto { Nome = autor.Nome };
            autoresDto.Add(autorDto);
        }
        return autoresDto;
    }
    public ReadAutorDto GetAutorById(int id)
    {
        var autor = _ctx.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor == null) throw new ApplicationException("Autor não Encontrado");
        ReadAutorDto dto = new ReadAutorDto { Nome = autor.Nome };
        return dto;
    }
    public void AtualizaAutor(int id, UpdateAutorDto dto)
    {
        var autor = _ctx.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor == null) throw new ApplicationException("Autor não Encontrado");
        autor.Nome = dto.Nome;
        _ctx.SaveChanges();
    }
    public void DeletaAutor(int id)
    {
        var autor = _ctx.Autores.FirstOrDefault(autor => autor.Id == id);
        if (autor == null) throw new ApplicationException("Autor não Encontrado");
        _ctx.Autores.Remove(autor);
        _ctx.SaveChanges();
    }
}
