using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Controller;
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    public readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var user = await _service.GetAllAsync();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        try
        {
            var request = await _service.CreateAsync(user);
            return Created(
                string.Empty,
                new
                {
                    message = $"user created with email {request.Email}"
                });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new {message = $"{ex.Message}"});
        }
        catch
        {
            return StatusCode(500, new {message = "internal server error"});
        }
    }

    [HttpPut]
    public async Task Update(User user)
    {
        try
        {
            await _service.UpdateAsync(user);
            Ok(new {message = "ok"});
        }
        catch 
        {
            StatusCode(500, new {message = "internal server error"});
        }
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            Ok(new {message = "ok"});
        }
        catch
        {
            StatusCode(500, new {message = "internal server error"});
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var request = await _service.GetByIdAsync(id);
            return Ok(new {request, message = "ok"});
        }
        catch
        {
            return StatusCode(500, new {message = "internal server error"});
        }
    }
}