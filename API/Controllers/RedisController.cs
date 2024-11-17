using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RedisController(IRedisService redisService) : ControllerBase
{
    [HttpPost("set")]
    public async Task<IActionResult> SetAsync(string key, string value)
    {
        await redisService.SetAsync(key, value);
        return Ok($"Key '{key}' set to '{value}'");
    }

    [HttpGet("get-master")]
    public async Task<IActionResult> GetFromMasterAsync(string key)
    {
        var value = await redisService.GetFromMasterAsync(key);
        return value != null ? Ok(value) : NotFound($"Key '{key}' not found");
    }

    [HttpGet("get-slave")]
    public async Task<IActionResult> GetFromSlaveAsync(string key)
    {
        var value = await redisService.GetFromSlaveAsync(key);
        return value != null ? Ok(value) : NotFound($"Key '{key}' not found");
    }
}