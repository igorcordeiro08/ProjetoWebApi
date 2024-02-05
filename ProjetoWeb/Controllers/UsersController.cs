//API de ecommerce

//- CRUD usuários
//    - Admin ou User
//    - Somente o endpoint de criação de usuário é livre de autenticação
//    - Se o usuário for admin vai poder editar/excluir/listar e obter dados de todos os usuários
//    - Se não for admin, ele só vai poder obter dados do seu próprio usuário
//- Login de usuário
//- CRUD produtos
//    - somente usuário Admin vai poder manipular os produtos
//    - Listagem e obter dados do produto não necessita de autenticação
//- endpoint de compra
//    - precisa estar autenticado

using Application.Services;
using Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult List()
    {
        var users = _service.List();
        return Ok(users);
    }

      
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = _service.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Post([FromBody] BaseUserRequest user)
    {
        var newUser = _service.Create(user);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateUserRequest user)
    {
        user.Id = id;
        var updatedUser = _service.Update(user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}