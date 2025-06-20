using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SharkLibrary.Data.Dtos;

namespace SharkLibrary.Controllers;

[ApiController]
[Route("Controller")]
public class LivroController : Controller
{
    [HttpPost]
    public void CadastroLivro(CreateLivroDto dto)
    {
        
    }
    [HttpGet]
    public void RecuperaLivros()
    {

    }
    [HttpGet("id")]
    public void RecuperaLivrosId(int id) 
    { 
        
    }
    [HttpPut]
    public void UpdateLivroFull(CreateLivroDto dto)
    {

    }
    [HttpPatch]
    public void UptadeLivro(UpdateLivroDto dto)
    {

    }
}
