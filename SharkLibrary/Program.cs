using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharkLibrary.Data;
using SharkLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");
builder.Services.AddDbContext<LibraryContext> //banco de dados
    (opts => opts.UseSqlServer(connectionString));

builder.Services // Configs para utilizar o identity
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<LibraryContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
