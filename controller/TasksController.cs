using Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{

    private readonly TaskRepository _taskRepository;

    public TasksController(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello");
    }

    [HttpPost("increment")]
    public async Task<IActionResult> IncrementNumber()
    {
        await _taskRepository.IncrementNumberAsync();
        return Ok("Number incremented successfully.");
    }

    [HttpGet("getNumber")]
    public async Task<IActionResult> GetNumber()
    {
        var number = await _taskRepository.GetNumberAsync();
        return Ok(number);
    }
}

