using Application.Services;
using Domain.Entities;
using Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoWeb.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserServices _service;

    public UsersController(IUserServices service) {
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
        var user=_service.GetById(id);
        return user is null? NotFound() : Ok(user);
    }
    [HttpPost]
    public IActionResult Post([FromBody]BaseUserRequest user)
    {
        var newUser= _service.Create(user);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    
    public IActionResult Put(int id,[FromBody]UpdateUserRequest user)
    {
        user.Id= id;
        //var updatedUser = _service.Update(id,user);
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



