using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoWeb.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
