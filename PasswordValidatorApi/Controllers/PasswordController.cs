using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;


[ApiController]
[Route("[controller]")]
public class PasswordController : ControllerBase
{
    [HttpPost("{ValidatePassword}")]
  public ActionResult<bool> ValidatePassword([FromBody] PasswordRequestModel model)
    {
        if (model == null || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest(new
            {
                errors = new Dictionary<string, string[]>
                {
                    { "password", new[] { "The password field is required." } }
                },
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                title = "One or more validation errors occurred.",
                status = 400,
                traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        string password = model.Password;
        var validationErrors = new List<string>();

        
        if (password.Length < 9)
            validationErrors.Add("A senha deve ter nove ou mais caracteres.");

        
        if (!password.Any(char.IsDigit))
            validationErrors.Add("A senha deve conter pelo menos um dígito.");

        
        if (!password.Any(char.IsLower))
            validationErrors.Add("A senha deve conter pelo menos uma letra minúscula.");

        
        if (!password.Any(char.IsUpper))
            validationErrors.Add("A senha deve conter pelo menos uma letra maiúscula.");

        
        var specialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };
        if (!password.Any(c => specialCharacters.Contains(c)))
            validationErrors.Add("A senha deve conter pelo menos um caractere especial: !@#$%^&*()-+");

        
        if (password.Distinct().Count() != password.Length)
            validationErrors.Add("A senha não deve conter caracteres repetidos.");

        
        if (password.Contains(' '))
            validationErrors.Add("A senha não deve conter espaços em branco.");

        
         if (validationErrors.Any())
        {
            return BadRequest(new { errors = validationErrors });
        }
        else
        {
            return true;
        }
    }
}