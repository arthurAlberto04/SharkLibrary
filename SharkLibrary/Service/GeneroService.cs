using SharkLibrary.Data.Dtos;
using SharkLibrary.Data;
using SharkLibrary.Models;

namespace SharkLibrary.Service;
public class GeneroService
{
    private LibraryContext _ctx;
    public GeneroService(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    public Genero CriaGenero(CreateGeneroDto dto)
    {
        Genero genero = new Genero { Tipo = dto.Tipo };
        _ctx.Generos.Add(genero);
        _ctx.SaveChanges();
        return genero;
    }
    public ReadGeneroDto GetGeneroById(int id)
    {
        var genero = _ctx.Generos.FirstOrDefault(genero => genero.Id == id);
        if (genero == null) throw new ApplicationException("Genero não Encontrado");
        ReadGeneroDto generoDto = new ReadGeneroDto { Tipo = genero.Tipo };
        return generoDto;
    }
    public IEnumerable<ReadGeneroDto> GetGenero(int skip, int take)
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
    public void AtualizaGenero(int id, UpdateGeneroDto dto)
    {
        var genero = _ctx.Generos.FirstOrDefault(genero => genero.Id == id);
        if (genero == null) throw new ApplicationException("Genero não encotrado");
        genero.Tipo = dto.Tipo;
        _ctx.SaveChanges();
    }
    public void DeletaGenero(int id)
    {
        var genero = _ctx.Generos.FirstOrDefault(genero => genero.Id == id);
        if (genero == null) throw new ApplicationException("Genero não encontrado");
        _ctx.Generos.Remove(genero);
        _ctx.SaveChanges();
    }
}
