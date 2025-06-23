﻿using System.ComponentModel.DataAnnotations;

namespace SharkLibrary.Data.Dtos;
public class LoginUsuarioDto
{
    [Required]
    public string Username { get; set; }
    [Required] 
    public string Password { get; set; }
}
