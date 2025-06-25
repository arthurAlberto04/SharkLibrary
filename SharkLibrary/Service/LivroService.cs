using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SharkLibrary.Data;
using SharkLibrary.Data.Dtos;
using SharkLibrary.Models;

namespace SharkLibrary.Service;
public class LivroService
{
    private LibraryContext _ctx;
    public LivroService(LibraryContext ctx)
    {
        _ctx = ctx;
    }

    public Livro CadastraLivro(CreateLivroDto dto)
    {
        Livro livro = new Livro
        {
            Nome = dto.Nome,
            DataDeLançamento = dto.DataDeLançamento,
            AutorId = dto.AutorId,
            GeneroId = dto.GeneroId,
            EditoraId = dto.EditoraId,
            Disponivel = dto.Disponivel
        };
        _ctx.Livros.Add(livro);
        _ctx.SaveChanges();
        return livro;
    }
    public IEnumerable<ReadLivroDto> GetLivros(int skip, int take)
    {
        var livros = _ctx.Livros.Skip(skip).Take(take).ToList();
        List<ReadLivroDto> livrosDto = new List<ReadLivroDto>();
        foreach (var livro in livros)
        {
            ReadLivroDto livroDto = new ReadLivroDto
            {
                Nome = livro.Nome,
                DataDeLançamento = livro.DataDeLançamento,
                Autor = new ReadAutorDto { Nome = livro.Autor.Nome },
                Genero = new ReadGeneroDto { Tipo = livro.Genero.Tipo },
                Editora = new ReadEditoraDto { Nome = livro.Editora.Nome },
                Disponivel = livro.Disponivel
            };
            livrosDto.Add(livroDto);
        }
        return livrosDto;
    }
    public ReadLivroDto GetLivroById(int id)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) throw new ApplicationException("Livro não encontrado");
        ReadLivroDto livroDto = new ReadLivroDto
        {
            Nome = livro.Nome,
            DataDeLançamento = livro.DataDeLançamento,
            Autor = new ReadAutorDto { Nome = livro.Autor.Nome },
            Genero = new ReadGeneroDto { Tipo = livro.Genero.Tipo },
            Editora = new ReadEditoraDto { Nome = livro.Editora.Nome },
            Disponivel = livro.Disponivel
        };
        return livroDto;
    }
    public void AtualizaLivro(int id, UpdateLivroDto dto)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) throw new ApplicationException("Livro não Encontrado");
        livro.Nome = dto.Nome;
        livro.DataDeLançamento = dto.DataDeLançamento;
        livro.AutorId = dto.AutorId;
        livro.EditoraId = dto.EditoraId;
        livro.GeneroId = dto.GeneroId;
        livro.Disponivel = dto.Disponivel;
        _ctx.SaveChanges();
    }
    public void AtualizaLivroParcial(int id, JsonPatchDocument<UpdateLivroDto> dto)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) throw new ApplicationException("Livro não encontrado");
        var livroAtt = new UpdateLivroDto
        {
            Nome = livro.Nome,
            DataDeLançamento = livro.DataDeLançamento,
            GeneroId = livro.GeneroId,
            EditoraId = livro.EditoraId,
            AutorId = livro.AutorId
        };
        var modelState = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary();
        dto.ApplyTo(livroAtt, modelState);
        if (!modelState.IsValid)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            if (errors.Any())
            {
                throw new ValidationException($"Erros ao aplicar o patch: {string.Join("; ", errors)}");
            }
        }
        var validationContext = new ValidationContext(livroAtt, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(livroAtt, validationContext, validationResults, validateAllProperties: true);
        if (!isValid)
        {
            var errorMessages = validationResults.Select(r => r.ErrorMessage).ToList();
            throw new ValidationException($"Erro de validação: {string.Join("; ", errorMessages)}");
        }
        livro.Nome = livroAtt.Nome;
        livro.DataDeLançamento = livroAtt.DataDeLançamento;
        livro.GeneroId = livroAtt.GeneroId;
        livro.EditoraId = livroAtt.EditoraId;
        livro.AutorId = livroAtt.AutorId;
        _ctx.SaveChanges();
    }
    public void DeletaLivro(int id)
    {
        var livro = _ctx.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) throw new ApplicationException("Livro não encontrado");
        _ctx.Livros.Remove(livro);
        _ctx.SaveChanges();
    }
}
